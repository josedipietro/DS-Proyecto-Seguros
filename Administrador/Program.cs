using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Administrador.Persistence.Database;
using Administrador.Persistence.DAOs;
using Base.Services.RabbitMQ;
using MassTransit;
using Administrador.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add  a DB context to the container.
builder.Services.AddDbContext<AdministradorDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IAdministradorDbContext, AdministradorDbContext>();
builder.Services.AddTransient<IBrandDAO, BrandDAO>();
builder.Services.AddTransient<IEnterpriseDAO, EnterpriseDAO>();
builder.Services.AddTransient<IInsuredDAO, InsuredDAO>();
builder.Services.AddTransient<IMunicipalityDAO, MunicipalityDAO>();
builder.Services.AddTransient<IUserDAO, UserDAO>();
builder.Services.AddTransient<IStateDAO, StateDAO>();
builder.Services.AddTransient<IParishDAO, ParishDAO>();
builder.Services.AddTransient<IVehicleDAO, VehicleDAO>();
builder.Services.AddTransient<IPolicyDAO, PolicyDAO>();
builder.Services.AddTransient<IIncidentDAO, IncidentDAO>();
builder.Services.AddTransient<IRepairRequestDAO, RepairRequestDAO>();
builder.Services.AddTransient<IPartDAO, PartDAO>();
builder.Services.AddTransient<IPartQuotationDAO, PartQuotationDAO>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Administrator API",
            Description = "An ASP.NET Core Web API for managing Administrator Platform",
        }
    );
});

// Configure RabbitMQ
builder.Services.Configure<AmqpInfo>(builder.Configuration.GetSection("amqp"));
builder.Services.AddSingleton<AmqpService>();

// Configure MassTransit RabbitMQ
builder.Services.AddMassTransit(configurator =>
{
    configurator.UsingRabbitMq(
        (context, cfg) =>
        {
            cfg.Host(
                new Uri(builder.Configuration["amqp:uri"]),
                hostConfigurator =>
                {
                    hostConfigurator.Username(builder.Configuration["amqp:username"]);
                    hostConfigurator.Password(builder.Configuration["amqp:password"]);
                }
            );
            // configure endpoints
            cfg.ReceiveEndpoint(
                "administrador-incident-update",
                endpointConfigurator =>
                {
                    endpointConfigurator.ClearSerialization();
                    endpointConfigurator.UseRawJsonSerializer();
                    endpointConfigurator.Consumer<IncidentConsumer>();
                }
            );
            cfg.ReceiveEndpoint(
                "administrador-repair-request-create",
                endpointConfigurator =>
                {
                    endpointConfigurator.ClearSerialization();
                    endpointConfigurator.UseRawJsonSerializer();
                    endpointConfigurator.Consumer<RepairRequestConsumer>();
                }
            );
            cfg.ReceiveEndpoint(
                "administrador-part-quotation-create",
                endpointConfigurator =>
                {
                    endpointConfigurator.ClearSerialization();
                    endpointConfigurator.UseRawJsonSerializer();
                    endpointConfigurator.Consumer<PartQuotationConsumer>();
                }
            );
            cfg.ReceiveEndpoint(
                "administrador-part-create",
                endpointConfigurator =>
                {
                    endpointConfigurator.ClearSerialization();
                    endpointConfigurator.UseRawJsonSerializer();
                    endpointConfigurator.Consumer<PartConsumer>();
                }
            );
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
