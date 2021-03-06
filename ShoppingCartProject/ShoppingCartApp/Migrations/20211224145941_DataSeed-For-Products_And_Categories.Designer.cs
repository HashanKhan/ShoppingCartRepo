// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartApp.Persistence.Contexts;

namespace ShoppingCartApp.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20211224145941_DataSeed-For-Products_And_Categories")]
    partial class DataSeedForProducts_And_Categories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCartApp.Domain.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ShoppingCartApp.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ferari",
                            Price = 3000m,
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Benz",
                            Price = 4000m,
                            ProductCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "AirBus",
                            Price = 5000m,
                            ProductCategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jet",
                            Price = 6000m,
                            ProductCategoryId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hummer",
                            Price = 7000m,
                            ProductCategoryId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Container",
                            Price = 8000m,
                            ProductCategoryId = 3
                        },
                        new
                        {
                            Id = 7,
                            Name = "Spider",
                            Price = 9000m,
                            ProductCategoryId = 4
                        },
                        new
                        {
                            Id = 8,
                            Name = "Jet Boat",
                            Price = 10000m,
                            ProductCategoryId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "RocketA",
                            Price = 11000m,
                            ProductCategoryId = 5
                        },
                        new
                        {
                            Id = 10,
                            Name = "RocketB",
                            Price = 12000m,
                            ProductCategoryId = 5
                        });
                });

            modelBuilder.Entity("ShoppingCartApp.Domain.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Planes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Trucks"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Boats"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Rockets"
                        });
                });

            modelBuilder.Entity("ShoppingCartApp.Domain.Models.Product", b =>
                {
                    b.HasOne("ShoppingCartApp.Domain.Models.ProductCategory", "ProductCategory")
                        .WithMany("Product")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
