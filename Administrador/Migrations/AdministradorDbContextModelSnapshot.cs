﻿// <auto-generated />
using System;
using Administrador.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Administrador.Migrations
{
    [DbContext(typeof(AdministradorDbContext))]
    partial class AdministradorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Administrador.Persistence.Entities.Brand", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Enterprise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EnterpriseType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParishId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rif")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ParishId");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("Rif")
                        .IsUnique();

                    b.ToTable("Enterprises");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Incident", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ParishId")
                        .HasColumnType("int");

                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("ThirdPolicyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParishId");

                    b.HasIndex("PolicyId");

                    b.HasIndex("ThirdPolicyId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Insured", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InsuredTypeIdentification")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.HasIndex(new[] { "Identification", "InsuredTypeIdentification" }, "IX_Insured_Identification_IdentificationType")
                        .IsUnique();

                    b.ToTable("Insureds");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Parish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Parishes");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RepairRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RepairRequestId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.PartQuotation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DeliveryTime")
                        .HasColumnType("int");

                    b.Property<Guid>("EnterpriseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Original")
                        .HasColumnType("bit");

                    b.Property<Guid>("PartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("discount_percentage")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("EnterpriseId");

                    b.HasIndex("PartId");

                    b.ToTable("PartQuotations");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("InsuredId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PolicyType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InsuredId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.RepairRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EnterpriseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IncidentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuotationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EnterpriseId");

                    b.HasIndex("IncidentId");

                    b.HasIndex("VehicleId");

                    b.ToTable("RepairRequests");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("EnterpriseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdentificationType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LdapID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EnterpriseId");

                    b.HasIndex("LdapID")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex(new[] { "Identification", "IdentificationType" }, "IX_Identification_IdentificationType")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BodyworkType")
                        .HasColumnType("int");

                    b.Property<string>("BrandCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InsuredId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SerialChasisNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SerialMotorNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandCode");

                    b.HasIndex("InsuredId");

                    b.HasIndex("Plate")
                        .IsUnique();

                    b.HasIndex("SerialChasisNumber")
                        .IsUnique();

                    b.HasIndex("SerialMotorNumber")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("BrandEnterprise", b =>
                {
                    b.Property<string>("BrandsCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("EnterprisesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BrandsCode", "EnterprisesId");

                    b.HasIndex("EnterprisesId");

                    b.ToTable("BrandEnterprise");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Enterprise", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Parish", "Parish")
                        .WithMany("Enterprises")
                        .HasForeignKey("ParishId");

                    b.Navigation("Parish");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Incident", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Parish", "Parish")
                        .WithMany("Incidents")
                        .HasForeignKey("ParishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Administrador.Persistence.Entities.Policy", "Policy")
                        .WithMany("Incidents")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Administrador.Persistence.Entities.Policy", "ThirdPolicy")
                        .WithMany("ThirdIncidents")
                        .HasForeignKey("ThirdPolicyId");

                    b.Navigation("Parish");

                    b.Navigation("Policy");

                    b.Navigation("ThirdPolicy");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Municipality", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.State", "State")
                        .WithMany("Municipalities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Parish", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Municipality", "Municipality")
                        .WithMany()
                        .HasForeignKey("MunicipalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Part", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.RepairRequest", "RepairRequest")
                        .WithMany("Parts")
                        .HasForeignKey("RepairRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RepairRequest");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.PartQuotation", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Enterprise", "Enterprise")
                        .WithMany("PartQuotations")
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Administrador.Persistence.Entities.Part", "Part")
                        .WithMany("PartQuotations")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enterprise");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Policy", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Insured", null)
                        .WithMany("Policies")
                        .HasForeignKey("InsuredId");

                    b.HasOne("Administrador.Persistence.Entities.Vehicle", "Vehicle")
                        .WithMany("Policies")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.RepairRequest", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Enterprise", null)
                        .WithMany("RepairRequests")
                        .HasForeignKey("EnterpriseId");

                    b.HasOne("Administrador.Persistence.Entities.Incident", "Incident")
                        .WithMany("RepairRequests")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Administrador.Persistence.Entities.Vehicle", "Vehicle")
                        .WithMany("RepairRequests")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.User", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Enterprise", "Enterprise")
                        .WithMany("Users")
                        .HasForeignKey("EnterpriseId");

                    b.Navigation("Enterprise");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Vehicle", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Administrador.Persistence.Entities.Insured", "Insured")
                        .WithMany("Vehicles")
                        .HasForeignKey("InsuredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Insured");
                });

            modelBuilder.Entity("BrandEnterprise", b =>
                {
                    b.HasOne("Administrador.Persistence.Entities.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Administrador.Persistence.Entities.Enterprise", null)
                        .WithMany()
                        .HasForeignKey("EnterprisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Enterprise", b =>
                {
                    b.Navigation("PartQuotations");

                    b.Navigation("RepairRequests");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Incident", b =>
                {
                    b.Navigation("RepairRequests");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Insured", b =>
                {
                    b.Navigation("Policies");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Parish", b =>
                {
                    b.Navigation("Enterprises");

                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Part", b =>
                {
                    b.Navigation("PartQuotations");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Policy", b =>
                {
                    b.Navigation("Incidents");

                    b.Navigation("ThirdIncidents");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.RepairRequest", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.State", b =>
                {
                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("Administrador.Persistence.Entities.Vehicle", b =>
                {
                    b.Navigation("Policies");

                    b.Navigation("RepairRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
