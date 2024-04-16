﻿// <auto-generated />
using ConvTeploobmen.Client.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConvTeploobmen.App.Migrations
{
    [DbContext(typeof(ConvTeploobDbConvtext))]
    [Migration("20240409222049_addData")]
    partial class addData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ConvTeploobmen.Client.DataBase.Gas", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("KinematicViscosity")
                        .HasColumnType("REAL");

                    b.HasKey("Name");

                    b.ToTable("Gases");

                    b.HasData(
                        new
                        {
                            Name = "CH4",
                            KinematicViscosity = 11.130000000000001
                        },
                        new
                        {
                            Name = "C2H6",
                            KinematicViscosity = 10.470000000000001
                        },
                        new
                        {
                            Name = "C3H8",
                            KinematicViscosity = 9.6999999999999993
                        },
                        new
                        {
                            Name = "C4H10",
                            KinematicViscosity = 8.7599999999999998
                        },
                        new
                        {
                            Name = "CO",
                            KinematicViscosity = 14.869999999999999
                        },
                        new
                        {
                            Name = "CO2",
                            KinematicViscosity = 15.609999999999999
                        },
                        new
                        {
                            Name = "N2",
                            KinematicViscosity = 16.809999999999999
                        },
                        new
                        {
                            Name = "O2",
                            KinematicViscosity = 17.649999999999999
                        },
                        new
                        {
                            Name = "H2",
                            KinematicViscosity = 8.7599999999999998
                        },
                        new
                        {
                            Name = "C5H12",
                            KinematicViscosity = 7.9100000000000001
                        },
                        new
                        {
                            Name = "C6H14",
                            KinematicViscosity = 7.04
                        },
                        new
                        {
                            Name = "Ar",
                            KinematicViscosity = 20.75
                        },
                        new
                        {
                            Name = "He",
                            KinematicViscosity = 17.760000000000002
                        },
                        new
                        {
                            Name = "Ne",
                            KinematicViscosity = 17.719999999999999
                        },
                        new
                        {
                            Name = "Kr",
                            KinematicViscosity = 19.649999999999999
                        },
                        new
                        {
                            Name = "Xe",
                            KinematicViscosity = 21.18
                        });
                });

            modelBuilder.Entity("ConvTeploobmen.Client.DataBase.Prandtl", b =>
                {
                    b.Property<double>("Temperature")
                        .HasColumnType("REAL");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Temperature");

                    b.ToTable("Prandtls");

                    b.HasData(
                        new
                        {
                            Temperature = -50.0,
                            Value = 0.72799999999999998
                        },
                        new
                        {
                            Temperature = -40.0,
                            Value = 0.72799999999999998
                        },
                        new
                        {
                            Temperature = -30.0,
                            Value = 0.72299999999999998
                        },
                        new
                        {
                            Temperature = -20.0,
                            Value = 0.71599999999999997
                        },
                        new
                        {
                            Temperature = -10.0,
                            Value = 0.71199999999999997
                        },
                        new
                        {
                            Temperature = 0.0,
                            Value = 0.70699999999999996
                        },
                        new
                        {
                            Temperature = 10.0,
                            Value = 0.70499999999999996
                        },
                        new
                        {
                            Temperature = 20.0,
                            Value = 0.70299999999999996
                        },
                        new
                        {
                            Temperature = 30.0,
                            Value = 0.70099999999999996
                        },
                        new
                        {
                            Temperature = 40.0,
                            Value = 0.69899999999999995
                        },
                        new
                        {
                            Temperature = 50.0,
                            Value = 0.69799999999999995
                        },
                        new
                        {
                            Temperature = 60.0,
                            Value = 0.69599999999999995
                        },
                        new
                        {
                            Temperature = 70.0,
                            Value = 0.69399999999999995
                        },
                        new
                        {
                            Temperature = 80.0,
                            Value = 0.69199999999999995
                        },
                        new
                        {
                            Temperature = 90.0,
                            Value = 0.68999999999999995
                        },
                        new
                        {
                            Temperature = 100.0,
                            Value = 0.68799999999999994
                        },
                        new
                        {
                            Temperature = 120.0,
                            Value = 0.68600000000000005
                        },
                        new
                        {
                            Temperature = 140.0,
                            Value = 0.68400000000000005
                        },
                        new
                        {
                            Temperature = 160.0,
                            Value = 0.68200000000000005
                        },
                        new
                        {
                            Temperature = 180.0,
                            Value = 0.68100000000000005
                        },
                        new
                        {
                            Temperature = 200.0,
                            Value = 0.68000000000000005
                        },
                        new
                        {
                            Temperature = 250.0,
                            Value = 0.67700000000000005
                        },
                        new
                        {
                            Temperature = 300.0,
                            Value = 0.67400000000000004
                        },
                        new
                        {
                            Temperature = 350.0,
                            Value = 0.67600000000000005
                        },
                        new
                        {
                            Temperature = 400.0,
                            Value = 0.67800000000000005
                        },
                        new
                        {
                            Temperature = 500.0,
                            Value = 0.68700000000000006
                        },
                        new
                        {
                            Temperature = 600.0,
                            Value = 0.69899999999999995
                        },
                        new
                        {
                            Temperature = 700.0,
                            Value = 0.70599999999999996
                        },
                        new
                        {
                            Temperature = 800.0,
                            Value = 0.71299999999999997
                        },
                        new
                        {
                            Temperature = 900.0,
                            Value = 0.71699999999999997
                        },
                        new
                        {
                            Temperature = 1000.0,
                            Value = 0.71899999999999997
                        },
                        new
                        {
                            Temperature = 1100.0,
                            Value = 0.72199999999999998
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
