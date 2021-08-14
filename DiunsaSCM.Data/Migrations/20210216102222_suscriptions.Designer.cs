﻿// <auto-generated />
using System;
using DiunsaSCM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiunsaSCM.Data.Migrations
{
    [DbContext(typeof(DiunsaSCMContext))]
    [Migration("20210216102222_suscriptions")]
    partial class suscriptions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiunsaSCM.Core.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.Incoterm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Incoterm");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.InventItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemGroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAlias")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InventItem");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ItemBarcode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BarcodeSetupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventColorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventSizeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAlias")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemBarcode");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.Port", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CountryId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Port");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventColorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventSizeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LineAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NameAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PurchOrderHeaderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PurchPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PurchUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("QtyOrdered")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PurchOrderHeaderId");

                    b.ToTable("PurchOrderDetail");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderHeader", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchStatus")
                        .HasColumnType("int");

                    b.Property<string>("VendorAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PurchOrderHeader");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderShipmentDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PurchOrderDetailId")
                        .HasColumnType("bigint");

                    b.Property<long>("PurchOrderShipmentHeaderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("QtyOnShipment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PurchOrderDetailId");

                    b.HasIndex("PurchOrderShipmentHeaderId");

                    b.ToTable("PurchOrderShipmentDetail");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderShipmentHeader", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BLNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EstimatedVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EstimatedWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("IncotermId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PreparationShippingRouteId")
                        .HasColumnType("bigint");

                    b.Property<long>("PurchOrderHeaderId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReceiptDateConfirmed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipmentDateConfirmed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipmentDateRequested")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ShipmentImportId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShippingCompanyId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShippingRouteId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IncotermId");

                    b.HasIndex("PreparationShippingRouteId");

                    b.HasIndex("PurchOrderHeaderId");

                    b.HasIndex("ShipmentImportId");

                    b.HasIndex("ShippingCompanyId");

                    b.HasIndex("ShippingRouteId");

                    b.ToTable("PurchOrderShipmentHeader");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderShipmentRouteStepSuscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PurchOrderShipmentHeaderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShippingRouteStepId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PurchOrderShipmentHeaderId");

                    b.HasIndex("ShippingRouteStepId");

                    b.ToTable("PurchOrderShipmentRouteStepSuscription");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentContainer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContainerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PurchOrderShipmentHeaderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShipmentContainerTypeId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PurchOrderShipmentHeaderId");

                    b.HasIndex("ShipmentContainerTypeId");

                    b.ToTable("ShipmentContainer");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentContainerDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PurchOrderDetailId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PurchOrderShipmentDetailId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("QtyOnContainer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ShipmentContainerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PurchOrderDetailId");

                    b.HasIndex("PurchOrderShipmentDetailId");

                    b.HasIndex("ShipmentContainerId");

                    b.ToTable("ShipmentContainerDetail");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentContainerType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CubicCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LoadCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ShipmentContainerType");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentImport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BLNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CurrentShippingRouteStepId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ERPRecId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("EstimatedVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EstimatedWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Incoterm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReceiptDateConfirmed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipmentDateConfirmed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipmentDateRequested")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ShippingCompanyId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShippingRouteId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentShippingRouteStepId");

                    b.HasIndex("ShippingCompanyId");

                    b.HasIndex("ShippingRouteId");

                    b.ToTable("ShipmentImport");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentLogEntry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PurchOrderShipmentHeaderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShippingRouteStepId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PurchOrderShipmentHeaderId");

                    b.HasIndex("ShippingRouteStepId");

                    b.ToTable("ShipmentLogEntry");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FreeTimeBoxDays")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FreeTimeBoxHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FreeTimeChassisDays")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FreeTimeChassisHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShippingCompany");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("PortOfDestinationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PortOfOriginId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShippingRouteStatusPresentationSchemaId")
                        .HasColumnType("bigint");

                    b.Property<int>("TransportationMethod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortOfDestinationId");

                    b.HasIndex("PortOfOriginId");

                    b.HasIndex("ShippingRouteStatusPresentationSchemaId");

                    b.ToTable("ShippingRoute");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingRouteStatusPresentationSchema", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HighRisk")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowRisk")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NoRisk")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OnTime")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ShippingRouteStatusPresentationSchema");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingRouteStep", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ShippingRouteId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShippingStepTypeId")
                        .HasColumnType("bigint");

                    b.Property<int>("StepNumber")
                        .HasColumnType("int");

                    b.Property<int>("TransitTimeDays")
                        .HasColumnType("int");

                    b.Property<int>("TransitTimeHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShippingRouteId");

                    b.HasIndex("ShippingStepTypeId");

                    b.ToTable("ShippingRouteStep");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingStepType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ShippingStepType");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.Port", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderDetail", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderHeader", "PurchOrderHeader")
                        .WithMany("PurchOrderDetails")
                        .HasForeignKey("PurchOrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderShipmentDetail", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderDetail", "PurchOrderOrderDetail")
                        .WithMany("PurchOrderShipmentDetails")
                        .HasForeignKey("PurchOrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderShipmentHeader", "PurchOrderShipmentHeader")
                        .WithMany("PurchOrderShipmentDetails")
                        .HasForeignKey("PurchOrderShipmentHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderShipmentHeader", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.Incoterm", "Incoterm")
                        .WithMany()
                        .HasForeignKey("IncotermId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRoute", "PreparationShippingRoute")
                        .WithMany()
                        .HasForeignKey("PreparationShippingRouteId");

                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderHeader", "PurchOrderHeader")
                        .WithMany("PurchOrderShipmentHeaders")
                        .HasForeignKey("PurchOrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.ShipmentImport", "ShipmentImport")
                        .WithMany("PurchOrderShipmentHeaders")
                        .HasForeignKey("ShipmentImportId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingCompany", "ShippingCompany")
                        .WithMany()
                        .HasForeignKey("ShippingCompanyId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRoute", "ShippingRoute")
                        .WithMany()
                        .HasForeignKey("ShippingRouteId");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.PurchOrderShipmentRouteStepSuscription", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderShipmentHeader", "PurchOrderShipmentHeader")
                        .WithMany()
                        .HasForeignKey("PurchOrderShipmentHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRouteStep", "ShippingRouteStep")
                        .WithMany()
                        .HasForeignKey("ShippingRouteStepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentContainer", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderShipmentHeader", "PurchOrderShipmentHeader")
                        .WithMany("ShipmentContainers")
                        .HasForeignKey("PurchOrderShipmentHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.ShipmentContainerType", "ShipmentContainerType")
                        .WithMany()
                        .HasForeignKey("ShipmentContainerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentContainerDetail", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderDetail", "PurchOrderOrderDetail")
                        .WithMany("ShipmentContainerDetails")
                        .HasForeignKey("PurchOrderDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderShipmentDetail", null)
                        .WithMany("ShipmentContainerDetails")
                        .HasForeignKey("PurchOrderShipmentDetailId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShipmentContainer", "ShipmentContainer")
                        .WithMany("ShipmentContainerLines")
                        .HasForeignKey("ShipmentContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentImport", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRouteStep", "ShippingRouteStep")
                        .WithMany()
                        .HasForeignKey("CurrentShippingRouteStepId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingCompany", "ShippingCompany")
                        .WithMany()
                        .HasForeignKey("ShippingCompanyId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRoute", "ShippingRoute")
                        .WithMany()
                        .HasForeignKey("ShippingRouteId");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShipmentLogEntry", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.PurchOrderShipmentHeader", "PurchOrderShipmentHeader")
                        .WithMany("ShipmentLogEntries")
                        .HasForeignKey("PurchOrderShipmentHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRouteStep", "ShippingRouteStep")
                        .WithMany()
                        .HasForeignKey("ShippingRouteStepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingRoute", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.Port", "PortOfDestination")
                        .WithMany()
                        .HasForeignKey("PortOfDestinationId");

                    b.HasOne("DiunsaSCM.Core.Entities.Port", "PortOfOrigin")
                        .WithMany()
                        .HasForeignKey("PortOfOriginId");

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRouteStatusPresentationSchema", "ShippingRouteStatusPresentationSchema")
                        .WithMany()
                        .HasForeignKey("ShippingRouteStatusPresentationSchemaId");
                });

            modelBuilder.Entity("DiunsaSCM.Core.Entities.ShippingRouteStep", b =>
                {
                    b.HasOne("DiunsaSCM.Core.Entities.ShippingRoute", "ShippingRoute")
                        .WithMany("ShippingRouteSteps")
                        .HasForeignKey("ShippingRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiunsaSCM.Core.Entities.ShippingStepType", "ShippingStepType")
                        .WithMany()
                        .HasForeignKey("ShippingStepTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
