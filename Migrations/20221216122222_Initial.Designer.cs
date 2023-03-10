// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserLevels;

#nullable disable

namespace UserLevels.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20221216122222_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cube", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CubeListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CubeListId");

                    b.ToTable("Cubes");
                });

            modelBuilder.Entity("Domain.Entities.CubeList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CubeLists");
                });

            modelBuilder.Entity("Domain.Entities.Cube", b =>
                {
                    b.HasOne("Domain.Entities.CubeList", "CubeList")
                        .WithMany("Cubes")
                        .HasForeignKey("CubeListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CubeList");
                });

            modelBuilder.Entity("Domain.Entities.CubeList", b =>
                {
                    b.Navigation("Cubes");
                });
#pragma warning restore 612, 618
        }
    }
}
