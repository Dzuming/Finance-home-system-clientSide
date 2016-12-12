using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Api.Contexts;

namespace financehomesystem.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20161212172219_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("finance_home_system.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("finance_home_system.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("Name");

                    b.Property<int>("Spending");

                    b.Property<int>("categoryId");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("finance_home_system.Products.Product", b =>
                {
                    b.HasOne("finance_home_system.Categories.Category", "categories")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
