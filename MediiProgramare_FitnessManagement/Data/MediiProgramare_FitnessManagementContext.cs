using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Models;

namespace MediiProgramare_FitnessManagement.Data
{
    public class MediiProgramare_FitnessManagementContext : DbContext
    {
        public MediiProgramare_FitnessManagementContext (DbContextOptions<MediiProgramare_FitnessManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; } = default!;
        public DbSet<Gym> Gym { get; set; } = default!;
        public DbSet<FitnessClass> FitnessClasses { get; set; } = default!;
        public DbSet<Trainer> Trainer { get; set; } = default!;
        public DbSet<ClassType> ClassType { get; set; } = default!;
        public DbSet<Booking> Booking { get; set; } = default!;

        public DbSet<TrainerClassType> TrainerClassType { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrainerClassType>()
                .HasKey(t => new { t.TrainerID, t.ClassTypeID });
        }
    }
}
