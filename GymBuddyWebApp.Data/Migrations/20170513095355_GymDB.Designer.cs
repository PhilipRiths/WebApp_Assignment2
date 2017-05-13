using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GymBuddyWebApp.Data;
using GymBuddyWebApp.Domain;

namespace GymBuddyWebApp.Data.Migrations
{
    [DbContext(typeof(GymBuddyContext))]
    [Migration("20170513095355_GymDB")]
    partial class GymDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymBuddyWebApp.Domain.Cardio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CardioType");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Distance");

                    b.Property<int>("PersonId");

                    b.Property<int>("Time");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Cardio");
                });

            modelBuilder.Entity("GymBuddyWebApp.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<double>("Height");

                    b.Property<string>("LastName");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("GymBuddyWebApp.Domain.Weights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("ExerciseType");

                    b.Property<int>("PersonId");

                    b.Property<int>("Reps");

                    b.Property<int>("Sets");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Weights");
                });

            modelBuilder.Entity("GymBuddyWebApp.Domain.Cardio", b =>
                {
                    b.HasOne("GymBuddyWebApp.Domain.Person", "Person")
                        .WithMany("CardioExercises")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GymBuddyWebApp.Domain.Weights", b =>
                {
                    b.HasOne("GymBuddyWebApp.Domain.Person", "Person")
                        .WithMany("WeightExercises")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
