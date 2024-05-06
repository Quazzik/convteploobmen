﻿using ConvTeploobmen.App.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvTeploobmen.Client.DataBase
{
    public class ConvTeploobDbContext : DbContext
    {
        public DbSet<Prandtl> Prandtls { get; set; }
        
        public DbSet<AttackAngle> AttackAngles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=D:\\convteploobmen\\convteploobmen\\convDB.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AttackAngle>()
                .HasData(new AttackAngle()
                {
                    Degree = 10,
                    Value = 0.42
                },
                new AttackAngle()
                {
                    Degree = 20,
                    Value = 0.52
                },
                new AttackAngle()
                {
                    Degree = 30,
                    Value = 0.67
                },
                new AttackAngle()
                {
                    Degree = 40,
                    Value = 0.78
                },
                new AttackAngle()
                {
                    Degree = 50,
                    Value = 0.88
                },
                new AttackAngle()
                {
                    Degree = 60,
                    Value = 0.94
                },
                new AttackAngle()
                {
                    Degree = 70,
                    Value = 0.98
                },
                new AttackAngle()
                {
                    Degree = 80,
                    Value = 1
                },
                new AttackAngle()
                {
                    Degree = 90,
                    Value = 1
                });

            modelBuilder
                .Entity<Prandtl>()
                .HasData(new Prandtl()
                {
                    Temperature = -50,
                    Value = 0.728
                },
                new Prandtl()
                {
                    Temperature = -40,
                    Value = 0.728
                },
                new Prandtl()
                {
                    Temperature = -30,
                    Value = 0.723
                },
                new Prandtl()
                {
                    Temperature = -20,
                    Value = 0.716
                },
                new Prandtl()
                {
                    Temperature = -10,
                    Value = 0.712
                },
                new Prandtl()
                {
                    Temperature = 0,
                    Value = 0.707
                },
                new Prandtl()
                {
                    Temperature = 10,
                    Value = 0.705
                },
                new Prandtl()
                {
                    Temperature = 20,
                    Value = 0.703
                },
                new Prandtl()
                {
                    Temperature = 30,
                    Value = 0.701
                },
                new Prandtl()
                {
                    Temperature = 40,
                    Value = 0.699
                },
                new Prandtl()
                {
                    Temperature = 50,
                    Value = 0.698
                },
                new Prandtl()
                {
                    Temperature = 60,
                    Value = 0.696
                },
                new Prandtl()
                {
                    Temperature = 70,
                    Value = 0.694
                },
                new Prandtl()
                {
                    Temperature = 80,
                    Value = 0.692
                },
                new Prandtl()
                {
                    Temperature = 90,
                    Value = 0.69
                },
                new Prandtl()
                {
                    Temperature = 100,
                    Value = 0.688
                },
                new Prandtl()
                {
                    Temperature = 120,
                    Value = 0.686
                },
                new Prandtl()
                {
                    Temperature = 140,
                    Value = 0.684
                },
                new Prandtl()
                {
                    Temperature = 160,
                    Value = 0.682
                },
                new Prandtl()
                {
                    Temperature = 180,
                    Value = 0.681
                },
                new Prandtl()
                {
                    Temperature = 200,
                    Value = 0.68
                },
                new Prandtl()
                {
                    Temperature = 250,
                    Value = 0.677
                },
                new Prandtl()
                {
                    Temperature = 300,
                    Value = 0.674
                },
                new Prandtl()
                {
                    Temperature = 350,
                    Value = 0.676
                },
                new Prandtl()
                {
                    Temperature = 400,
                    Value = 0.678
                },
                new Prandtl()
                {
                    Temperature = 500,
                    Value = 0.687
                },
                new Prandtl()
                {
                    Temperature = 600,
                    Value = 0.699
                },
                new Prandtl()
                {
                    Temperature = 700,
                    Value = 0.706
                },
                new Prandtl()
                {
                    Temperature = 800,
                    Value = 0.713
                },
                new Prandtl()
                {
                    Temperature = 900,
                    Value = 0.717
                },
                new Prandtl()
                {
                    Temperature = 1000,
                    Value = 0.719
                },
                new Prandtl()
                {
                    Temperature = 1100,
                    Value = 0.722
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
