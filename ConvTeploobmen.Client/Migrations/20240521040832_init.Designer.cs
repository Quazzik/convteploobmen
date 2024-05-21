﻿// <auto-generated />
using ConvTeploobmen.Client.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConvTeploobmen.Client.Migrations
{
    [DbContext(typeof(ConvTeploobDbContext))]
    [Migration("20240521040832_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ConvTeploobmen.App.DataBase.AttackAngle", b =>
                {
                    b.Property<int>("Degree")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Degree");

                    b.ToTable("AttackAngles");

                    b.HasData(
                        new
                        {
                            Degree = 10,
                            Value = 0.41999999999999998
                        },
                        new
                        {
                            Degree = 20,
                            Value = 0.52000000000000002
                        },
                        new
                        {
                            Degree = 30,
                            Value = 0.67000000000000004
                        },
                        new
                        {
                            Degree = 40,
                            Value = 0.78000000000000003
                        },
                        new
                        {
                            Degree = 50,
                            Value = 0.88
                        },
                        new
                        {
                            Degree = 60,
                            Value = 0.93999999999999995
                        },
                        new
                        {
                            Degree = 70,
                            Value = 0.97999999999999998
                        },
                        new
                        {
                            Degree = 80,
                            Value = 1.0
                        },
                        new
                        {
                            Degree = 90,
                            Value = 1.0
                        });
                });

            modelBuilder.Entity("ConvTeploobmen.Client.DataBase.ThermalConductivityKoeffs", b =>
                {
                    b.Property<string>("GasName")
                        .HasColumnType("TEXT");

                    b.Property<double>("koeff1")
                        .HasColumnType("REAL");

                    b.Property<double>("koeff2")
                        .HasColumnType("REAL");

                    b.Property<double>("koeff3")
                        .HasColumnType("REAL");

                    b.HasKey("GasName");

                    b.ToTable("ThermalConductancesKoeffs");

                    b.HasData(
                        new
                        {
                            GasName = "O2",
                            koeff1 = -2.9999999999999999E-07,
                            koeff2 = 0.00089999999999999998,
                            koeff3 = 0.24249999999999999
                        },
                        new
                        {
                            GasName = "CO2",
                            koeff1 = -2E-08,
                            koeff2 = 0.00080000000000000004,
                            koeff3 = 0.14099999999999999
                        },
                        new
                        {
                            GasName = "N2",
                            koeff1 = -1.9999999999999999E-07,
                            koeff2 = 0.00059999999999999995,
                            koeff3 = 0.2525
                        },
                        new
                        {
                            GasName = "H2O",
                            koeff1 = -6.9999999999999997E-07,
                            koeff2 = 0.00069999999999999999,
                            koeff3 = 0.16789999999999999
                        },
                        new
                        {
                            GasName = "Air",
                            koeff1 = -2E-08,
                            koeff2 = 6.9999999999999994E-05,
                            koeff3 = 0.025399999999999999
                        });
                });

            modelBuilder.Entity("ConvTeploobmen.Client.DataBase.ViscosityKoeffs", b =>
                {
                    b.Property<string>("GasName")
                        .HasColumnType("TEXT");

                    b.Property<double>("koeff1")
                        .HasColumnType("REAL");

                    b.Property<double>("koeff2")
                        .HasColumnType("REAL");

                    b.Property<double>("koeff3")
                        .HasColumnType("REAL");

                    b.HasKey("GasName");

                    b.ToTable("ViscositiesKoeffs");

                    b.HasData(
                        new
                        {
                            GasName = "O2",
                            koeff1 = 5.9999999999999997E-07,
                            koeff2 = 0.0011000000000000001,
                            koeff3 = 0.11559999999999999
                        },
                        new
                        {
                            GasName = "CO2",
                            koeff1 = 3.9999999999999998E-07,
                            koeff2 = 0.00069999999999999999,
                            koeff3 = 0.052999999999999999
                        },
                        new
                        {
                            GasName = "N2",
                            koeff1 = 5.9999999999999997E-07,
                            koeff2 = 0.001,
                            koeff3 = 0.1173
                        },
                        new
                        {
                            GasName = "H2O",
                            koeff1 = 1.9999999999999999E-06,
                            koeff2 = 0.00089999999999999998,
                            koeff3 = 0.1009
                        },
                        new
                        {
                            GasName = "Air",
                            koeff1 = 5.9999999999999997E-07,
                            koeff2 = 0.0011000000000000001,
                            koeff3 = 0.11459999999999999
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
