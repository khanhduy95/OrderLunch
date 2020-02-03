﻿// <auto-generated />
using System;
using Fetch.OrderLunch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fetch.OrderLunch.Infrastructure.Migrations
{
    [DbContext(typeof(OrderLunchContext))]
    [Migration("20200203105832_repairFoodTable")]
    partial class repairFoodTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BasketAggregate.Basket", b =>
                {
                    b.Property<string>("BuyerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<int>("Id");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("BuyerId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BasketAggregate.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BasketBuyerId")
                        .IsRequired();

                    b.Property<int>("CatalogItemId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("BasketBuyerId");

                    b.ToTable("basketItems");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BuyerAggregate.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<string>("IdentityGuid")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IdentityGuid")
                        .IsUnique();

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BuyerAggregate.Method", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Methods");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BuyerAggregate.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyerId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("methodId");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("methodId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.CompanyAggregate.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<string>("HotLine")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.CompanyAggregate.DailyMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("DailyMenu");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.CompanyAggregate.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<string>("HotLine")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.FoodDailyMenu", b =>
                {
                    b.Property<int>("FoodId");

                    b.Property<int>("DailyMenuId");

                    b.HasKey("FoodId", "DailyMenuId");

                    b.HasIndex("DailyMenuId");

                    b.ToTable("FoodDailyMenu");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OfficeSupplier", b =>
                {
                    b.Property<int>("SupplierId");

                    b.Property<int>("OfficeId");

                    b.HasKey("SupplierId", "OfficeId");

                    b.HasIndex("OfficeId");

                    b.ToTable("OfficeSuppliers");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OrderAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("BuyerId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("OrderStatusId");

                    b.Property<int?>("PaymentMethodId");

                    b.Property<DateTime>("_orderDate")
                        .HasColumnName("OrderDate");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<string>("_pictureUrl")
                        .HasColumnName("PictureUrl");

                    b.Property<string>("_productName")
                        .IsRequired()
                        .HasColumnName("ProductName");

                    b.Property<decimal>("_unitPrice")
                        .HasColumnName("UnitPrice");

                    b.Property<int>("_units")
                        .HasColumnName("Units");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OrderAggregate.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<int?>("DailyMenuId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MenuId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DailyMenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<DateTime>("ExprireTime");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("CreatorUserId");

                    b.Property<string>("HotLine")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Infrastructure.Idempotency.ClientRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("ClientRequest");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BasketAggregate.BasketItem", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.BasketAggregate.Basket")
                        .WithMany("Items")
                        .HasForeignKey("BasketBuyerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.BuyerAggregate.PaymentMethod", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.BuyerAggregate.Buyer")
                        .WithMany("PaymentMethods")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fetch.OrderLunch.Core.Entities.BuyerAggregate.Method", "method")
                        .WithMany()
                        .HasForeignKey("methodId");
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.CompanyAggregate.Office", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.CompanyAggregate.Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.FoodDailyMenu", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.CompanyAggregate.DailyMenu")
                        .WithMany()
                        .HasForeignKey("DailyMenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OfficeSupplier", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.CompanyAggregate.Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OrderAggregate.Order", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.BuyerAggregate.Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("Fetch.OrderLunch.Core.Entities.OrderAggregate.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId");

                    b.HasOne("Fetch.OrderLunch.Core.Entities.BuyerAggregate.PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.OrderAggregate.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Food", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fetch.OrderLunch.Core.Entities.CompanyAggregate.DailyMenu")
                        .WithMany("Foods")
                        .HasForeignKey("DailyMenuId");

                    b.HasOne("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Menu")
                        .WithMany("Foods")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Menu", b =>
                {
                    b.HasOne("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Supplier")
                        .WithOne()
                        .HasForeignKey("Fetch.OrderLunch.Core.Entities.SupplierAggregate.Menu", "SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}