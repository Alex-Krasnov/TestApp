﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestApp.Data;

#nullable disable

namespace TestApp.Migrations
{
    [DbContext(typeof(TestAppContext))]
    [Migration("20231127135246_InitialMigration3")]
    partial class InitialMigration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CalculationDeviceCheckPoint", b =>
                {
                    b.Property<int>("DeviceCalculationDeviceId")
                        .HasColumnType("integer");

                    b.Property<int>("PointCheckPointId")
                        .HasColumnType("integer");

                    b.HasKey("DeviceCalculationDeviceId", "PointCheckPointId");

                    b.HasIndex("PointCheckPointId");

                    b.ToTable("CalculationDeviceCheckPoint");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.CalculationDevice", b =>
                {
                    b.Property<int>("CalculationDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CalculationDeviceId"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CalculationDeviceId");

                    b.ToTable("CalculationDevices");

                    b.HasData(
                        new
                        {
                            CalculationDeviceId = 1,
                            Date = new DateOnly(1900, 1, 1),
                            Name = "CalculationDevice1"
                        },
                        new
                        {
                            CalculationDeviceId = 2,
                            Date = new DateOnly(2023, 11, 27),
                            Name = "CalculationDevice2"
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.CheckPoint", b =>
                {
                    b.Property<int>("CheckPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CheckPointId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ObjConsumptionId")
                        .HasColumnType("integer");

                    b.HasKey("CheckPointId");

                    b.HasIndex("ObjConsumptionId");

                    b.ToTable("CheckPoints");

                    b.HasData(
                        new
                        {
                            CheckPointId = 1,
                            Name = "CheckPoint1",
                            ObjConsumptionId = 1
                        },
                        new
                        {
                            CheckPointId = 2,
                            Name = "CheckPoint2",
                            ObjConsumptionId = 1
                        },
                        new
                        {
                            CheckPointId = 3,
                            Name = "CheckPoint3",
                            ObjConsumptionId = 2
                        },
                        new
                        {
                            CheckPointId = 4,
                            Name = "CheckPoint4",
                            ObjConsumptionId = 3
                        },
                        new
                        {
                            CheckPointId = 5,
                            Name = "CheckPoint5",
                            ObjConsumptionId = 3
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ChildOrganization", b =>
                {
                    b.Property<int>("ChildOrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChildOrganizationId"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("ChildOrganizationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("ChildOrganizations");

                    b.HasData(
                        new
                        {
                            ChildOrganizationId = 1,
                            Addres = "Street1",
                            Name = "ChildOrganization1",
                            OrganizationId = 1
                        },
                        new
                        {
                            ChildOrganizationId = 2,
                            Addres = "Street2",
                            Name = "ChildOrganization2",
                            OrganizationId = 1
                        },
                        new
                        {
                            ChildOrganizationId = 3,
                            Addres = "Street3",
                            Name = "ChildOrganization3",
                            OrganizationId = 2
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.CurrentTransformer", b =>
                {
                    b.Property<int>("CurrentTransformerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CurrentTransformerId"));

                    b.Property<DateOnly>("CheckDate")
                        .HasColumnType("date");

                    b.Property<int>("CheckPointId")
                        .HasColumnType("integer");

                    b.Property<string>("CurrentTransformerType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("TransformationCoefficient")
                        .HasColumnType("integer");

                    b.HasKey("CurrentTransformerId");

                    b.HasIndex("CheckPointId")
                        .IsUnique();

                    b.ToTable("CurrentTransformers");

                    b.HasData(
                        new
                        {
                            CurrentTransformerId = 1,
                            CheckDate = new DateOnly(1900, 1, 1),
                            CheckPointId = 1,
                            CurrentTransformerType = "Type1",
                            Number = 1,
                            TransformationCoefficient = 0
                        },
                        new
                        {
                            CurrentTransformerId = 2,
                            CheckDate = new DateOnly(1900, 1, 1),
                            CheckPointId = 2,
                            CurrentTransformerType = "Type2",
                            Number = 2,
                            TransformationCoefficient = 0
                        },
                        new
                        {
                            CurrentTransformerId = 3,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 3,
                            CurrentTransformerType = "Type3",
                            Number = 3,
                            TransformationCoefficient = 0
                        },
                        new
                        {
                            CurrentTransformerId = 4,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 4,
                            CurrentTransformerType = "Type4",
                            Number = 4,
                            TransformationCoefficient = 0
                        },
                        new
                        {
                            CurrentTransformerId = 5,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 5,
                            CurrentTransformerType = "Type3",
                            Number = 5,
                            TransformationCoefficient = 0
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ElectricityMeter", b =>
                {
                    b.Property<int>("ElectricityMeterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ElectricityMeterId"));

                    b.Property<DateOnly>("CheckDate")
                        .HasColumnType("date");

                    b.Property<int>("CheckPointId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("ElectricityMeterId");

                    b.HasIndex("CheckPointId")
                        .IsUnique();

                    b.ToTable("ElectricityMeters");

                    b.HasData(
                        new
                        {
                            ElectricityMeterId = 1,
                            CheckDate = new DateOnly(1900, 1, 1),
                            CheckPointId = 1,
                            Number = 1
                        },
                        new
                        {
                            ElectricityMeterId = 2,
                            CheckDate = new DateOnly(1900, 1, 1),
                            CheckPointId = 2,
                            Number = 2
                        },
                        new
                        {
                            ElectricityMeterId = 3,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 3,
                            Number = 3
                        },
                        new
                        {
                            ElectricityMeterId = 4,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 4,
                            Number = 4
                        },
                        new
                        {
                            ElectricityMeterId = 5,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 5,
                            Number = 5
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ElectricitySupplyPoint", b =>
                {
                    b.Property<int>("ElectricitySupplyPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ElectricitySupplyPointId"));

                    b.Property<int>("MaxPower")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ObjConsumptionId")
                        .HasColumnType("integer");

                    b.HasKey("ElectricitySupplyPointId");

                    b.HasIndex("ObjConsumptionId");

                    b.ToTable("ElectricitySupplyPoints");

                    b.HasData(
                        new
                        {
                            ElectricitySupplyPointId = 1,
                            MaxPower = 1,
                            Name = "ElectricitySupplyPoint1",
                            ObjConsumptionId = 1
                        },
                        new
                        {
                            ElectricitySupplyPointId = 2,
                            MaxPower = 2,
                            Name = "ElectricitySupplyPoint2",
                            ObjConsumptionId = 1
                        },
                        new
                        {
                            ElectricitySupplyPointId = 3,
                            MaxPower = 3,
                            Name = "ElectricitySupplyPoint3",
                            ObjConsumptionId = 2
                        },
                        new
                        {
                            ElectricitySupplyPointId = 4,
                            MaxPower = 4,
                            Name = "ElectricitySupplyPoint4",
                            ObjConsumptionId = 3
                        },
                        new
                        {
                            ElectricitySupplyPointId = 5,
                            MaxPower = 3,
                            Name = "ElectricitySupplyPoint5",
                            ObjConsumptionId = 4
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ObjConsumption", b =>
                {
                    b.Property<int>("ObjConsumptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ObjConsumptionId"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ChildOrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ObjConsumptionId");

                    b.HasIndex("ChildOrganizationId");

                    b.ToTable("ObjConsumptions");

                    b.HasData(
                        new
                        {
                            ObjConsumptionId = 1,
                            Addres = "Street1",
                            ChildOrganizationId = 1,
                            Name = "ObjConsumption1"
                        },
                        new
                        {
                            ObjConsumptionId = 2,
                            Addres = "Street2",
                            ChildOrganizationId = 2,
                            Name = "ObjConsumption2"
                        },
                        new
                        {
                            ObjConsumptionId = 3,
                            Addres = "Street3",
                            ChildOrganizationId = 3,
                            Name = "ObjConsumption3"
                        },
                        new
                        {
                            ObjConsumptionId = 4,
                            Addres = "Street4",
                            ChildOrganizationId = 3,
                            Name = "ObjConsumption4"
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrganizationId"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            OrganizationId = 1,
                            Addres = "Street1",
                            Name = "Organization1"
                        },
                        new
                        {
                            OrganizationId = 2,
                            Addres = "Street2",
                            Name = "Organization2"
                        });
                });

            modelBuilder.Entity("TestApp.Models.DbModels.VoltageTransformer", b =>
                {
                    b.Property<int>("VoltageTransformerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VoltageTransformerId"));

                    b.Property<DateOnly>("CheckDate")
                        .HasColumnType("date");

                    b.Property<int>("CheckPointId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("TransformationCoefficient")
                        .HasColumnType("integer");

                    b.Property<string>("VoltageTransformerType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VoltageTransformerId");

                    b.HasIndex("CheckPointId")
                        .IsUnique();

                    b.ToTable("VoltageTransformers");

                    b.HasData(
                        new
                        {
                            VoltageTransformerId = 1,
                            CheckDate = new DateOnly(1900, 1, 1),
                            CheckPointId = 1,
                            Number = 1,
                            TransformationCoefficient = 0,
                            VoltageTransformerType = "Type1"
                        },
                        new
                        {
                            VoltageTransformerId = 2,
                            CheckDate = new DateOnly(1900, 1, 1),
                            CheckPointId = 2,
                            Number = 2,
                            TransformationCoefficient = 0,
                            VoltageTransformerType = "Type2"
                        },
                        new
                        {
                            VoltageTransformerId = 3,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 3,
                            Number = 3,
                            TransformationCoefficient = 0,
                            VoltageTransformerType = "Type3"
                        },
                        new
                        {
                            VoltageTransformerId = 4,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 4,
                            Number = 4,
                            TransformationCoefficient = 0,
                            VoltageTransformerType = "Type4"
                        },
                        new
                        {
                            VoltageTransformerId = 5,
                            CheckDate = new DateOnly(2023, 11, 27),
                            CheckPointId = 5,
                            Number = 5,
                            TransformationCoefficient = 0,
                            VoltageTransformerType = "Type3"
                        });
                });

            modelBuilder.Entity("CalculationDeviceCheckPoint", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.CalculationDevice", null)
                        .WithMany()
                        .HasForeignKey("DeviceCalculationDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestApp.Models.DbModels.CheckPoint", null)
                        .WithMany()
                        .HasForeignKey("PointCheckPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestApp.Models.DbModels.CheckPoint", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.ObjConsumption", "ObjConsumption")
                        .WithMany("CheckPoints")
                        .HasForeignKey("ObjConsumptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjConsumption");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ChildOrganization", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.Organization", "Organization")
                        .WithMany("ChildOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.CurrentTransformer", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.CheckPoint", "CheckPoint")
                        .WithOne("CurrentTransformer")
                        .HasForeignKey("TestApp.Models.DbModels.CurrentTransformer", "CheckPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckPoint");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ElectricityMeter", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.CheckPoint", "CheckPoint")
                        .WithOne("ElectricityMeter")
                        .HasForeignKey("TestApp.Models.DbModels.ElectricityMeter", "CheckPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckPoint");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ElectricitySupplyPoint", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.ObjConsumption", "ObjConsumption")
                        .WithMany("ElectricitySupplyPoints")
                        .HasForeignKey("ObjConsumptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjConsumption");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ObjConsumption", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.ChildOrganization", "ChildOrganization")
                        .WithMany("ObjConsumptions")
                        .HasForeignKey("ChildOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChildOrganization");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.VoltageTransformer", b =>
                {
                    b.HasOne("TestApp.Models.DbModels.CheckPoint", "CheckPoint")
                        .WithOne("VoltageTransformer")
                        .HasForeignKey("TestApp.Models.DbModels.VoltageTransformer", "CheckPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckPoint");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.CheckPoint", b =>
                {
                    b.Navigation("CurrentTransformer");

                    b.Navigation("ElectricityMeter");

                    b.Navigation("VoltageTransformer");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ChildOrganization", b =>
                {
                    b.Navigation("ObjConsumptions");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.ObjConsumption", b =>
                {
                    b.Navigation("CheckPoints");

                    b.Navigation("ElectricitySupplyPoints");
                });

            modelBuilder.Entity("TestApp.Models.DbModels.Organization", b =>
                {
                    b.Navigation("ChildOrganizations");
                });
#pragma warning restore 612, 618
        }
    }
}
