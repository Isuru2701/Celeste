using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Celeste.Model.Data
{
    public partial class LunarContext : DbContext
    {
        public LunarContext()
            : base("name=Lunar")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<comfort> comforts { get; set; }
        public virtual DbSet<EndUser> EndUsers { get; set; }
        public virtual DbSet<ProfilePicture> ProfilePictures { get; set; }
        public virtual DbSet<trigger> triggers { get; set; }
        public virtual DbSet<user_comforts> user_comforts { get; set; }
        public virtual DbSet<user_entries> user_entries { get; set; }
        public virtual DbSet<user_score> user_score { get; set; }
        public virtual DbSet<user_triggers> user_triggers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<comfort>()
                .Property(e => e.trigger_name)
                .IsUnicode(false);

            modelBuilder.Entity<comfort>()
                .HasMany(e => e.user_comforts)
                .WithRequired(e => e.comfort)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EndUser>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<EndUser>()
                .Property(e => e.password_hash)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EndUser>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<EndUser>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<EndUser>()
                .HasOptional(e => e.ProfilePicture)
                .WithRequired(e => e.EndUser);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.user_comforts)
                .WithRequired(e => e.EndUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.user_entries)
                .WithRequired(e => e.EndUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.user_score)
                .WithRequired(e => e.EndUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.user_triggers)
                .WithRequired(e => e.EndUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trigger>()
                .Property(e => e.trigger_name)
                .IsUnicode(false);

            modelBuilder.Entity<trigger>()
                .HasMany(e => e.user_triggers)
                .WithRequired(e => e.trigger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_entries>()
                .Property(e => e.content)
                .IsUnicode(false);
        }
    }
}
