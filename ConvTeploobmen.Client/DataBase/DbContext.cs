using ConvTeploobmen.App.DataBase;
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
        public DbSet<ViscosityKoeffs> ViscositiesKoeffs { get; set; }
        
        public DbSet<AttackAngle> AttackAngles { get; set; }

        public DbSet<ThermalConductivityKoeffs> ThermalConductancesKoeffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=D:\\convteploobmen\\convteploobmen\\convDB.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AttackAngle>()
                .HasData(
                new AttackAngle() { Degree = 10, Value = 0.42 },
                new AttackAngle() { Degree = 20, Value = 0.52 },
                new AttackAngle() { Degree = 30, Value = 0.67 },
                new AttackAngle() { Degree = 40, Value = 0.78 },
                new AttackAngle() { Degree = 50, Value = 0.88 },
                new AttackAngle() { Degree = 60, Value = 0.94 },
                new AttackAngle() { Degree = 70, Value = 0.98 },
                new AttackAngle() { Degree = 80, Value = 1 },
                new AttackAngle() { Degree = 90, Value = 1 }
                );

            modelBuilder
                .Entity<ViscosityKoeffs>()
                .HasData(
                new ViscosityKoeffs() { GasName = "O2", koeff1 = 6e-11, koeff2 = 1e-7, koeff3 = 1e-5},
                new ViscosityKoeffs() { GasName = "CO2", koeff1 = 4e-11, koeff2 = 7e-8, koeff3 = 5e-6 },
                new ViscosityKoeffs() { GasName = "N2", koeff1 = 6e-11, koeff2 = 1e-7, koeff3 = 1e-5 },
                new ViscosityKoeffs() { GasName = "H2O", koeff1 = 2e-10, koeff2 = 9e-8, koeff3 = 1e-5 }
                );

            modelBuilder
                .Entity<ThermalConductivityKoeffs>()
                .HasData(
                new ThermalConductivityKoeffs() { GasName = "O2", koeff1 = -3e-8, koeff2 = 9e-5, koeff3 = 0.02425 },
                new ThermalConductivityKoeffs() { GasName = "CO2", koeff1 = 2e-10, koeff2 = 8e-5, koeff3 = 0.0141 },
                new ThermalConductivityKoeffs() { GasName = "N2", koeff1 = -2e-8, koeff2 = 6e-5, koeff3 = 0.02525 },
                new ThermalConductivityKoeffs() { GasName = "H2O", koeff1 = 7e-8, koeff2 = 7e-5, koeff3 = 0.01679 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
