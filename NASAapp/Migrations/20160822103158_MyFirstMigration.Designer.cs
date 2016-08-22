using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NASAapp.DAL;

namespace NASAapp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20160822103158_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("NASAapp.DAL.AstronomyPictureOfDayDAL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Copyright");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Explanation");

                    b.Property<string>("HdUrl");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });
        }
    }
}
