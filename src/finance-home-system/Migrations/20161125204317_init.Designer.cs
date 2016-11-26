using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Api.Contexts;

namespace financehomesystem.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20161125204317_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("finance_home_system.Category.categoryList", b =>
                {
                    b.Property<int>("categoryListId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.HasKey("categoryListId");

                    b.ToTable("categoryList");
                });

            modelBuilder.Entity("finance_home_system.Products.Products", b =>
                {
                    b.Property<int>("ProductsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Spending");

                    b.Property<int>("categoryListId");

                    b.HasKey("ProductsId");

                    b.HasIndex("categoryListId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("finance_home_system.Products.Products", b =>
                {
                    b.HasOne("finance_home_system.Category.categoryList", "categoryList")
                        .WithMany()
                        .HasForeignKey("categoryListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
