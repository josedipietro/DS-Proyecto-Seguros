using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Taller.Persistence.Database;
using Base.Services.RabbitMQ;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add  a DB context to the container.
builder.Services.AddDbContext<TallerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Workshop API",
            Description = "An ASP.NET Core Web API for managing Workshop Platform",
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
            // cfg.ReceiveEndpoint(
            //     "administrador-user",
            //     endpointConfigurator =>
            //     {
            //         endpointConfigurator.ClearSerialization();
            //         endpointConfigurator.UseRawJsonSerializer();
            //         endpointConfigurator.Consumer<UserConsumer>();
            //     }
            // );
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
