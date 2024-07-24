using FitnessJournal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Infrastructure.Data
{
    public class FitnessJournalContext : DbContext
    {
        public FitnessJournalContext(DbContextOptions<FitnessJournalContext> options) : base(options) { }
        public virtual DbSet<Achievement> Achievements { get; set; }   
        public virtual DbSet<ActivityTracking> ActivityTrackings { get; set; }
        public virtual DbSet<FitnessInformation> FitnessInformations { get; set; }
        public virtual DbSet<UserProfile> Profiles { get; set; }
        public virtual DbSet<Progress> Progresses { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Achievement>().HasKey(a => a.Id);
            modelBuilder.Entity<ActivityTracking>().HasKey(a => a.Id);
            modelBuilder.Entity<FitnessInformation>().HasKey(f => f.Id);
            modelBuilder.Entity<UserProfile>().HasKey(p => p.Id);
            modelBuilder.Entity<Progress>().HasKey(p => p.Id);
            modelBuilder.Entity<Workout>().HasKey(w => w.Id);


            
        }

    }
}
