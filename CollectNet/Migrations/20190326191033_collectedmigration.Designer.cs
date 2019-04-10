﻿// <auto-generated />
using CollectNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CollectNet.Migrations
{
    [DbContext(typeof(CollectionContext))]
    [Migration("20190326191033_collectedmigration")]
    partial class collectedmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CollectNet.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCollected");

                    b.Property<string>("ItemName")
                        .HasMaxLength(50);

                    b.Property<string>("ItemTags")
                        .HasMaxLength(50);

                    b.Property<string>("ItemTypes")
                        .HasMaxLength(50);

                    b.Property<int>("ListID");

                    b.HasKey("ID");

                    b.HasIndex("ListID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("CollectNet.Models.List", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ListTags")
                        .HasMaxLength(50);

                    b.Property<string>("ListTypes")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("List");
                });

            modelBuilder.Entity("CollectNet.Models.Item", b =>
                {
                    b.HasOne("CollectNet.Models.List", "List")
                        .WithMany("ListItems")
                        .HasForeignKey("ListID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}