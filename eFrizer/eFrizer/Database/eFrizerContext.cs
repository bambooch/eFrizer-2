﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eFrizer.Database
{
    public partial class eFrizerContext : DbContext
    {
        public eFrizerContext()
        {
        }

        public eFrizerContext(DbContextOptions<eFrizerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<HairDresser> HairDressers { get; set; }
        public virtual DbSet<HairSalon> HairSalons { get; set; }
        public virtual DbSet<HairSalonHairDresser> HairSalonHairDressers { get; set; }
        public virtual DbSet<HairSalonHairSalonType> HairSalonHairSalonTypes { get; set; }
        public virtual DbSet<HairSalonPicture> HairSalonPictures { get; set; }
        public virtual DbSet<HairSalonService> HairSalonServices { get; set; }
        public virtual DbSet<HairSalonType> HairSalonTypes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<HairSalonManager> HairSalonManagers { get; set; }
        public virtual DbSet<HairSalonServiceLoyaltyBonus> HairSalonServiceLoyaltyBonuses { get; set; }

        public virtual DbSet<LoyaltyBonusUser> LoyaltyBonusUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(k => new { k.ApplicationUserId, k.RoleId })
                    .HasName("PK_applicationuser_role");
            });

            modelBuilder.Entity<HairSalonHairSalonType>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.HairSalonTypeId })
                    .HasName("PK_hairsalon_hairsalontype");
            });

            modelBuilder.Entity<HairSalonPicture>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.PictureId })
                    .HasName("PK_hairsalon_picture");
            });

            modelBuilder.Entity<HairSalonHairDresser>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.HairDresserId })
                    .HasName("PK_hairsalon_hairdresser");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(k => new { k.HairDresserId, k.ClientId })
                    .HasName("PK_reservation");
            });

            modelBuilder.Entity<HairSalonManager>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.ManagerId })
                    .HasName("PK_hairsalon_manager");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(k => new { k.ClientId, k.HairSalonId })
                    .HasName("PK_client_hairSalon");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
