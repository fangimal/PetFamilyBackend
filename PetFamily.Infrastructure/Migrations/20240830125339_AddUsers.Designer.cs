﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFamily.Infrastructure.DbContexts;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    [DbContext(typeof(PetFamilyWriteDbContext))]
    [Migration("20240830125339_AddUsers")]
    partial class AddUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFamily.Domain.Entities.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AnimalAttitude")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("animal_attitude");

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("breed");

                    b.Property<bool>("Castration")
                        .HasColumnType("boolean")
                        .HasColumnName("castration");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("color");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 8, 30, 12, 53, 39, 712, DateTimeKind.Unspecified).AddTicks(8844), new TimeSpan(0, 0, 0, 0, 0)))
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("description");

                    b.Property<string>("Health")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("health");

                    b.Property<int?>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nickname");

                    b.Property<bool>("OnTreatment")
                        .HasColumnType("boolean")
                        .HasColumnName("on_treatment");

                    b.Property<bool>("OnlyOneInFamily")
                        .HasColumnType("boolean")
                        .HasColumnName("only_one_in_family");

                    b.Property<string>("PeopleAttitude")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("people_attitude");

                    b.Property<Guid>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PetFamily.Domain.Entities.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("building");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("city");

                            b1.Property<string>("Index")
                                .IsRequired()
                                .HasMaxLength(6)
                                .HasColumnType("character varying(6)")
                                .HasColumnName("index");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("character varying(1000)")
                                .HasColumnName("street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("ContactPhoneNumber", "PetFamily.Domain.Entities.Pet.ContactPhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("contact_phone_number");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Place", "PetFamily.Domain.Entities.Pet.Place#Place", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("place");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("VolunteerPhoneNumber", "PetFamily.Domain.Entities.Pet.VolunteerPhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("volunteer_phone_number");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Weight", "PetFamily.Domain.Entities.Pet.Weight#Weight", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<float>("Kilograms")
                                .HasColumnType("real")
                                .HasColumnName("weight");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.PetPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid")
                        .HasColumnName("pet_id");

                    b.HasKey("Id")
                        .HasName("pk_pet_photos");

                    b.HasIndex("PetId")
                        .HasDatabaseName("ix_pet_photos_pet_id");

                    b.ToTable("pet_photos", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string[]>("Permissions")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("permissions");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_roles_name");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_users_role_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Vaccination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("Applied")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("applied");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid")
                        .HasColumnName("pet_id");

                    b.HasKey("Id")
                        .HasName("pk_vaccinations");

                    b.HasIndex("PetId")
                        .HasDatabaseName("ix_vaccinations_pet_id");

                    b.ToTable("vaccinations", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("description");

                    b.Property<string>("DonationInfo")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("donation_info");

                    b.Property<bool>("FromShelter")
                        .HasColumnType("boolean")
                        .HasColumnName("from_shelter");

                    b.Property<int?>("NumberOfPetsFoundHome")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_pets_found_home");

                    b.Property<int>("YearsExperience")
                        .HasColumnType("integer")
                        .HasColumnName("years_experience");

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "PetFamily.Domain.Entities.Volunteer.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("last_name");

                            b1.Property<string>("Patronymic")
                                .HasColumnType("text")
                                .HasColumnName("patronymic");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.VolunteerApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("FromShelter")
                        .HasColumnType("boolean")
                        .HasColumnName("from_shelter");

                    b.Property<int?>("NumberOfPetsFoundHome")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_pets_found_home");

                    b.Property<int>("YearsExperience")
                        .HasColumnType("integer")
                        .HasColumnName("years_experience");

                    b.ComplexProperty<Dictionary<string, object>>("FullName", "PetFamily.Domain.Entities.VolunteerApplication.FullName#FullName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("last_name");

                            b1.Property<string>("Patronymic")
                                .HasColumnType("text")
                                .HasColumnName("patronymic");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Status", "PetFamily.Domain.Entities.VolunteerApplication.Status#ApplicationStatus", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Status")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("status");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteer_applications");

                    b.ToTable("volunteer_applications", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.VolunteerPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<Guid>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.HasKey("Id")
                        .HasName("pk_volunteer_photos");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_volunteer_photos_volunteer_id");

                    b.ToTable("volunteer_photos", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Pet", b =>
                {
                    b.HasOne("PetFamily.Domain.Entities.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.PetPhoto", b =>
                {
                    b.HasOne("PetFamily.Domain.Entities.Pet", null)
                        .WithMany("Photos")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pet_photos_pets_pet_id");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.User", b =>
                {
                    b.HasOne("PetFamily.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_roles_role_id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Vaccination", b =>
                {
                    b.HasOne("PetFamily.Domain.Entities.Pet", null)
                        .WithMany("Vaccinations")
                        .HasForeignKey("PetId")
                        .HasConstraintName("fk_vaccinations_pets_pet_id");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Volunteer", b =>
                {
                    b.OwnsMany("PetFamily.Domain.Entities.SocialMedia", "SocialMedias", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Link")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Social")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VolunteerId", "Id");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_medias");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.Navigation("SocialMedias");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.VolunteerPhoto", b =>
                {
                    b.HasOne("PetFamily.Domain.Entities.Volunteer", null)
                        .WithMany("Photos")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_volunteer_photos_volunteers_volunteer_id");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Pet", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("PetFamily.Domain.Entities.Volunteer", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
