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
    .HasData(
        new Prandtl() { Temperature = 100, Value = 0.691 },
        new Prandtl() { Temperature = 110, Value = 0.690 },
        new Prandtl() { Temperature = 120, Value = 0.689 },
        new Prandtl() { Temperature = 130, Value = 0.688 },
        new Prandtl() { Temperature = 140, Value = 0.687 },
        new Prandtl() { Temperature = 150, Value = 0.686 },
        new Prandtl() { Temperature = 160, Value = 0.685 },
        new Prandtl() { Temperature = 170, Value = 0.684 },
        new Prandtl() { Temperature = 180, Value = 0.684 },
        new Prandtl() { Temperature = 190, Value = 0.683 },
        new Prandtl() { Temperature = 200, Value = 0.682 },
        new Prandtl() { Temperature = 210, Value = 0.681 },
        new Prandtl() { Temperature = 220, Value = 0.680 },
        new Prandtl() { Temperature = 230, Value = 0.680 },
        new Prandtl() { Temperature = 240, Value = 0.679 },
        new Prandtl() { Temperature = 250, Value = 0.678 },
        new Prandtl() { Temperature = 260, Value = 0.677 },
        new Prandtl() { Temperature = 270, Value = 0.677 },
        new Prandtl() { Temperature = 280, Value = 0.676 },
        new Prandtl() { Temperature = 290, Value = 0.676 },
        new Prandtl() { Temperature = 300, Value = 0.675 },
        new Prandtl() { Temperature = 310, Value = 0.675 },
        new Prandtl() { Temperature = 320, Value = 0.674 },
        new Prandtl() { Temperature = 330, Value = 0.674 },
        new Prandtl() { Temperature = 340, Value = 0.673 },
        new Prandtl() { Temperature = 350, Value = 0.673 },
        new Prandtl() { Temperature = 360, Value = 0.672 },
        new Prandtl() { Temperature = 370, Value = 0.672 },
        new Prandtl() { Temperature = 380, Value = 0.672 },
        new Prandtl() { Temperature = 390, Value = 0.671 },
        new Prandtl() { Temperature = 400, Value = 0.671 },
        new Prandtl() { Temperature = 410, Value = 0.671 },
        new Prandtl() { Temperature = 420, Value = 0.670 },
        new Prandtl() { Temperature = 430, Value = 0.670 },
        new Prandtl() { Temperature = 440, Value = 0.670 },
        new Prandtl() { Temperature = 450, Value = 0.669 },
        new Prandtl() { Temperature = 460, Value = 0.669 },
        new Prandtl() { Temperature = 470, Value = 0.669 },
        new Prandtl() { Temperature = 480, Value = 0.668 },
        new Prandtl() { Temperature = 490, Value = 0.668 },
        new Prandtl() { Temperature = 500, Value = 0.668 },
        new Prandtl() { Temperature = 510, Value = 0.667 },
        new Prandtl() { Temperature = 520, Value = 0.667 },
        new Prandtl() { Temperature = 530, Value = 0.667 },
        new Prandtl() { Temperature = 540, Value = 0.667 },
        new Prandtl() { Temperature = 550, Value = 0.666 },
        new Prandtl() { Temperature = 560, Value = 0.666 },
        new Prandtl() { Temperature = 570, Value = 0.666 },
        new Prandtl() { Temperature = 580, Value = 0.666 },
        new Prandtl() { Temperature = 590, Value = 0.665 },
        new Prandtl() { Temperature = 600, Value = 0.665 },
        new Prandtl() { Temperature = 610, Value = 0.665 },
        new Prandtl() { Temperature = 620, Value = 0.665 },
        new Prandtl() { Temperature = 630, Value = 0.665 },
        new Prandtl() { Temperature = 640, Value = 0.664 },
        new Prandtl() { Temperature = 650, Value = 0.664 },
        new Prandtl() { Temperature = 660, Value = 0.664 },
        new Prandtl() { Temperature = 670, Value = 0.664 },
        new Prandtl() { Temperature = 680, Value = 0.664 },
        new Prandtl() { Temperature = 690, Value = 0.663 },
        new Prandtl() { Temperature = 700, Value = 0.663 },
        new Prandtl() { Temperature = 710, Value = 0.663 },
        new Prandtl() { Temperature = 720, Value = 0.663 },
        new Prandtl() { Temperature = 730, Value = 0.663 },
        new Prandtl() { Temperature = 740, Value = 0.662 },
        new Prandtl() { Temperature = 750, Value = 0.662 },
        new Prandtl() { Temperature = 760, Value = 0.662 },
        new Prandtl() { Temperature = 770, Value = 0.662 },
        new Prandtl() { Temperature = 780, Value = 0.662 },
        new Prandtl() { Temperature = 790, Value = 0.662 },
        new Prandtl() { Temperature = 800, Value = 0.661 },
        new Prandtl() { Temperature = 810, Value = 0.661 },
        new Prandtl() { Temperature = 820, Value = 0.661 },
        new Prandtl() { Temperature = 830, Value = 0.661 },
        new Prandtl() { Temperature = 840, Value = 0.661 },
        new Prandtl() { Temperature = 850, Value = 0.661 },
        new Prandtl() { Temperature = 860, Value = 0.661 },
        new Prandtl() { Temperature = 870, Value = 0.660 },
        new Prandtl() { Temperature = 880, Value = 0.660 },
        new Prandtl() { Temperature = 890, Value = 0.660 },
        new Prandtl() { Temperature = 900, Value = 0.660 },
        new Prandtl() { Temperature = 910, Value = 0.660 },
        new Prandtl() { Temperature = 920, Value = 0.660 },
        new Prandtl() { Temperature = 930, Value = 0.660 },
        new Prandtl() { Temperature = 940, Value = 0.660 },
        new Prandtl() { Temperature = 950, Value = 0.659 },
        new Prandtl() { Temperature = 960, Value = 0.659 },
        new Prandtl() { Temperature = 970, Value = 0.659 },
        new Prandtl() { Temperature = 980, Value = 0.659 },
        new Prandtl() { Temperature = 990, Value = 0.659 },
        new Prandtl() { Temperature = 1000, Value = 0.659 }
);
            base.OnModelCreating(modelBuilder);
        }
    }
}
