﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eFrizer.Database;

namespace eFrizer.Migrations
{
    [DbContext(typeof(eFrizerContext))]
    partial class eFrizerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eFrizer.Database.ApplicationUser", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("eFrizer.Database.ApplicationUserRole", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "RoleId")
                        .HasName("PK_applicationuser_role");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationUserRoles");
                });

            modelBuilder.Entity("eFrizer.Database.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("eFrizer.Database.HairDresser", b =>
                {
                    b.Property<int>("HairDresserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HairDresserId");

                    b.HasIndex("HairSalonId");

                    b.ToTable("HairDressers");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalon", b =>
                {
                    b.Property<int>("HairSalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HairSalonId");

                    b.ToTable("HairSalons");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonCity", b =>
                {
                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("HairSalonId", "CityId")
                        .HasName("PK_hairsalon_city");

                    b.HasIndex("CityId");

                    b.ToTable("HairSalonCities");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonHairSalonType", b =>
                {
                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("HairSalonTypeId")
                        .HasColumnType("int");

                    b.HasKey("HairSalonId", "HairSalonTypeId")
                        .HasName("PK_hairsalon_hairsalontype");

                    b.HasIndex("HairSalonTypeId");

                    b.ToTable("HairSalonHairSalonTypes");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonPicture", b =>
                {
                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.HasKey("HairSalonId", "PictureId")
                        .HasName("PK_hairsalon_picture");

                    b.HasIndex("PictureId");

                    b.ToTable("HairSalonPictures");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonService", b =>
                {
                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("HairSalonId", "ServiceId")
                        .HasName("PK_hairsalon_service");

                    b.HasIndex("ServiceId");

                    b.ToTable("HairSalonServices");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonType", b =>
                {
                    b.Property<int>("HairSalonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HairSalonTypeId");

                    b.ToTable("HairSalonTypes");
                });

            modelBuilder.Entity("eFrizer.Database.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PictureId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("eFrizer.Database.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("HairDresserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("HairDresserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("eFrizer.Database.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("HairSalonId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("eFrizer.Database.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("eFrizer.Database.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("eFrizer.Database.ApplicationUserRole", b =>
                {
                    b.HasOne("eFrizer.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.Role", "Role")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("eFrizer.Database.HairDresser", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", null)
                        .WithMany("HairDressers")
                        .HasForeignKey("HairSalonId");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonCity", b =>
                {
                    b.HasOne("eFrizer.Database.City", "City")
                        .WithMany("HairSalonCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonCities")
                        .HasForeignKey("HairSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("HairSalon");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonHairSalonType", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonHairSalonTypes")
                        .HasForeignKey("HairSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairSalonType", "HairSalonType")
                        .WithMany("HairSalonHairSalonTypes")
                        .HasForeignKey("HairSalonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HairSalon");

                    b.Navigation("HairSalonType");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonPicture", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonPictures")
                        .HasForeignKey("HairSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.Picture", "Picture")
                        .WithMany("HairSalonPictures")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HairSalon");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonService", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonServices")
                        .HasForeignKey("HairSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.Service", "Service")
                        .WithMany("HairSalonServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HairSalon");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("eFrizer.Database.Reservation", b =>
                {
                    b.HasOne("eFrizer.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("Reservations")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairDresser", "HairDresser")
                        .WithMany("Reservations")
                        .HasForeignKey("HairDresserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("HairDresser");
                });

            modelBuilder.Entity("eFrizer.Database.Review", b =>
                {
                    b.HasOne("eFrizer.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("Reviews")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("Reviews")
                        .HasForeignKey("HairSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("HairSalon");
                });

            modelBuilder.Entity("eFrizer.Database.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("eFrizer.Database.City", b =>
                {
                    b.Navigation("HairSalonCities");
                });

            modelBuilder.Entity("eFrizer.Database.HairDresser", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalon", b =>
                {
                    b.Navigation("HairDressers");

                    b.Navigation("HairSalonCities");

                    b.Navigation("HairSalonHairSalonTypes");

                    b.Navigation("HairSalonPictures");

                    b.Navigation("HairSalonServices");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonType", b =>
                {
                    b.Navigation("HairSalonHairSalonTypes");
                });

            modelBuilder.Entity("eFrizer.Database.Picture", b =>
                {
                    b.Navigation("HairSalonPictures");
                });

            modelBuilder.Entity("eFrizer.Database.Role", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("eFrizer.Database.Service", b =>
                {
                    b.Navigation("HairSalonServices");
                });
#pragma warning restore 612, 618
        }
    }
}
