IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [InventItem] (
    [Id] bigint NOT NULL IDENTITY,
    [ItemId] nvarchar(max) NULL,
    [ItemName] nvarchar(max) NULL,
    [NameAlias] nvarchar(max) NULL,
    [ItemGroupId] nvarchar(max) NULL,
    CONSTRAINT [PK_InventItem] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ItemBarcode] (
    [Id] bigint NOT NULL IDENTITY,
    [Barcode] nvarchar(max) NULL,
    [ItemId] nvarchar(max) NULL,
    [ItemName] nvarchar(max) NULL,
    [NameAlias] nvarchar(max) NULL,
    [InventColorId] nvarchar(max) NULL,
    [InventSizeId] nvarchar(max) NULL,
    [BarcodeSetupId] nvarchar(max) NULL,
    CONSTRAINT [PK_ItemBarcode] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Port] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [Route] nvarchar(max) NULL,
    [TransitTime] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Port] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchOrderHeader] (
    [Id] bigint NOT NULL,
    [PurchId] nvarchar(max) NULL,
    [VendorAccount] nvarchar(max) NULL,
    [PurchStatus] int NOT NULL,
    [CurrencyCode] nvarchar(max) NULL,
    [CreatedDatetime] datetime2 NOT NULL,
    [PurchName] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchOrderHeader] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShipmentContainerType] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [CubicCapacity] decimal(18,2) NOT NULL,
    [LoadCapacity] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ShipmentContainerType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShippingCompany] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [VendorAccount] nvarchar(max) NULL,
    [FreeTimeBoxDays] decimal(18,2) NOT NULL,
    [FreeTimeBoxHours] decimal(18,2) NOT NULL,
    [FreeTimeChassisDays] decimal(18,2) NOT NULL,
    [FreeTimeChassisHours] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ShippingCompany] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchOrderDetail] (
    [Id] bigint NOT NULL,
    [PurchOrderHeaderId] bigint NOT NULL,
    [PurchId] nvarchar(max) NULL,
    [ItemId] nvarchar(max) NULL,
    [ItemName] nvarchar(max) NULL,
    [NameAlias] nvarchar(max) NULL,
    [QtyOrdered] decimal(18,2) NOT NULL,
    [PurchUnit] nvarchar(max) NULL,
    [PurchPrice] decimal(18,2) NOT NULL,
    [LineAmount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PurchOrderDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId] FOREIGN KEY ([PurchOrderHeaderId]) REFERENCES [PurchOrderHeader] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PurchOrderShipmentHeader] (
    [Id] bigint NOT NULL IDENTITY,
    [PurchOrderHeaderId] bigint NOT NULL,
    [Description] nvarchar(max) NULL,
    [DateCreated] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [ShipmentDateRequested] datetime2 NOT NULL,
    [ShipmentDateConfirmed] datetime2 NOT NULL,
    [DeliveryDate] datetime2 NOT NULL,
    [ReceiptDateConfirmed] datetime2 NOT NULL,
    [ShippingCompanyId] bigint NULL,
    [BLNumber] nvarchar(max) NULL,
    [PortOfOriginId] bigint NULL,
    [PortOfDestinationId] bigint NULL,
    [EstimatedVolume] decimal(18,2) NOT NULL,
    [EstimatedWeight] decimal(18,2) NOT NULL,
    [Incoterm] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchOrderShipmentHeader] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchOrderShipmentHeader_Port_PortOfDestinationId] FOREIGN KEY ([PortOfDestinationId]) REFERENCES [Port] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PurchOrderShipmentHeader_Port_PortOfOriginId] FOREIGN KEY ([PortOfOriginId]) REFERENCES [Port] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId] FOREIGN KEY ([PurchOrderHeaderId]) REFERENCES [PurchOrderHeader] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingCompany_ShippingCompanyId] FOREIGN KEY ([ShippingCompanyId]) REFERENCES [ShippingCompany] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PurchOrderShipmentDetail] (
    [Id] bigint NOT NULL IDENTITY,
    [PurchOrderShipmentHeaderId] bigint NOT NULL,
    [PurchOrderDetailId] bigint NOT NULL,
    [QtyOnShipment] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PurchOrderShipmentDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId] FOREIGN KEY ([PurchOrderDetailId]) REFERENCES [PurchOrderDetail] ([Id]),
    CONSTRAINT [FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ShipmentContainer] (
    [Id] bigint NOT NULL IDENTITY,
    [PurchOrderShipmentHeaderId] bigint NOT NULL,
    [Description] nvarchar(max) NULL,
    [ShipmentContainerTypeId] bigint NOT NULL,
    [ContainerNumber] nvarchar(max) NULL,
    [Weight] decimal(18,2) NOT NULL,
    [Volume] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ShipmentContainer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId] FOREIGN KEY ([ShipmentContainerTypeId]) REFERENCES [ShipmentContainerType] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ShipmentContainerDetail] (
    [Id] bigint NOT NULL IDENTITY,
    [ShipmentContainerId] bigint NOT NULL,
    [PurchOrderDetailId] bigint NOT NULL,
    [QtyOnContainer] decimal(18,2) NOT NULL,
    [PurchOrderShipmentDetailId] bigint NULL,
    CONSTRAINT [PK_ShipmentContainerDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId] FOREIGN KEY ([PurchOrderDetailId]) REFERENCES [PurchOrderDetail] ([Id]),
    CONSTRAINT [FK_ShipmentContainerDetail_PurchOrderShipmentDetail_PurchOrderShipmentDetailId] FOREIGN KEY ([PurchOrderShipmentDetailId]) REFERENCES [PurchOrderShipmentDetail] ([Id]),
    CONSTRAINT [FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId] FOREIGN KEY ([ShipmentContainerId]) REFERENCES [ShipmentContainer] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PurchOrderDetail_PurchOrderHeaderId] ON [PurchOrderDetail] ([PurchOrderHeaderId]);

GO

CREATE INDEX [IX_PurchOrderShipmentDetail_PurchOrderDetailId] ON [PurchOrderShipmentDetail] ([PurchOrderDetailId]);

GO

CREATE INDEX [IX_PurchOrderShipmentDetail_PurchOrderShipmentHeaderId] ON [PurchOrderShipmentDetail] ([PurchOrderShipmentHeaderId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_PortOfDestinationId] ON [PurchOrderShipmentHeader] ([PortOfDestinationId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_PortOfOriginId] ON [PurchOrderShipmentHeader] ([PortOfOriginId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_PurchOrderHeaderId] ON [PurchOrderShipmentHeader] ([PurchOrderHeaderId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_ShippingCompanyId] ON [PurchOrderShipmentHeader] ([ShippingCompanyId]);

GO

CREATE INDEX [IX_ShipmentContainer_PurchOrderShipmentHeaderId] ON [ShipmentContainer] ([PurchOrderShipmentHeaderId]);

GO

CREATE INDEX [IX_ShipmentContainer_ShipmentContainerTypeId] ON [ShipmentContainer] ([ShipmentContainerTypeId]);

GO

CREATE INDEX [IX_ShipmentContainerDetail_PurchOrderDetailId] ON [ShipmentContainerDetail] ([PurchOrderDetailId]);

GO

CREATE INDEX [IX_ShipmentContainerDetail_PurchOrderShipmentDetailId] ON [ShipmentContainerDetail] ([PurchOrderShipmentDetailId]);

GO

CREATE INDEX [IX_ShipmentContainerDetail_ShipmentContainerId] ON [ShipmentContainerDetail] ([ShipmentContainerId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201122234914_InitialMigration', N'3.1.7');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Port]') AND [c].[name] = N'Country');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Port] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Port] DROP COLUMN [Country];

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [CurrentShippingRouteId] bigint NULL;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [ShippingRouteId] bigint NULL;

GO

ALTER TABLE [Port] ADD [CountryId] bigint NULL;

GO

CREATE TABLE [Country] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShippingRoute] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ShippingRoute] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShippingStepType] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ShippingStepType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShippingRouteStep] (
    [Id] bigint NOT NULL IDENTITY,
    [ShippingRouteId] bigint NOT NULL,
    [ShippingStepTypeId] bigint NOT NULL,
    [StepNumber] int NOT NULL,
    CONSTRAINT [PK_ShippingRouteStep] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShippingRouteStep_ShippingRoute_ShippingRouteId] FOREIGN KEY ([ShippingRouteId]) REFERENCES [ShippingRoute] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId] FOREIGN KEY ([ShippingStepTypeId]) REFERENCES [ShippingStepType] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ShipmentLogEntry] (
    [Id] bigint NOT NULL IDENTITY,
    [PurchOrderShipmentHeaderId] bigint NOT NULL,
    [ShippingRouteStepId] bigint NOT NULL,
    [LogText] nvarchar(max) NULL,
    [Date] datetime2 NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    CONSTRAINT [PK_ShipmentLogEntry] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId] FOREIGN KEY ([ShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_CurrentShippingRouteId] ON [PurchOrderShipmentHeader] ([CurrentShippingRouteId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_ShippingRouteId] ON [PurchOrderShipmentHeader] ([ShippingRouteId]);

GO

CREATE INDEX [IX_Port_CountryId] ON [Port] ([CountryId]);

GO

CREATE INDEX [IX_ShipmentLogEntry_PurchOrderShipmentHeaderId] ON [ShipmentLogEntry] ([PurchOrderShipmentHeaderId]);

GO

CREATE INDEX [IX_ShipmentLogEntry_ShippingRouteStepId] ON [ShipmentLogEntry] ([ShippingRouteStepId]);

GO

CREATE INDEX [IX_ShippingRouteStep_ShippingRouteId] ON [ShippingRouteStep] ([ShippingRouteId]);

GO

CREATE INDEX [IX_ShippingRouteStep_ShippingStepTypeId] ON [ShippingRouteStep] ([ShippingStepTypeId]);

GO

ALTER TABLE [Port] ADD CONSTRAINT [FK_Port_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteId] FOREIGN KEY ([CurrentShippingRouteId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRoute_ShippingRouteId] FOREIGN KEY ([ShippingRouteId]) REFERENCES [ShippingRoute] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201128170415_AddingRoutes', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteId];

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_Port_PortOfDestinationId];

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_Port_PortOfOriginId];

GO

DROP INDEX [IX_PurchOrderShipmentHeader_CurrentShippingRouteId] ON [PurchOrderShipmentHeader];

GO

DROP INDEX [IX_PurchOrderShipmentHeader_PortOfDestinationId] ON [PurchOrderShipmentHeader];

GO

DROP INDEX [IX_PurchOrderShipmentHeader_PortOfOriginId] ON [PurchOrderShipmentHeader];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchOrderShipmentHeader]') AND [c].[name] = N'PortOfDestinationId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [PurchOrderShipmentHeader] DROP COLUMN [PortOfDestinationId];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchOrderShipmentHeader]') AND [c].[name] = N'PortOfOriginId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [PurchOrderShipmentHeader] DROP COLUMN [PortOfOriginId];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Port]') AND [c].[name] = N'Route');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Port] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Port] DROP COLUMN [Route];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Port]') AND [c].[name] = N'TransitTime');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Port] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Port] DROP COLUMN [TransitTime];

GO

ALTER TABLE [ShippingRouteStep] ADD [TransitTimeDays] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [ShippingRouteStep] ADD [TransitTimeHours] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [ShippingRoute] ADD [PortOfDestinationId] bigint NULL;

GO

ALTER TABLE [ShippingRoute] ADD [PortOfOriginId] bigint NULL;

GO

ALTER TABLE [ShippingRoute] ADD [TransportationMethod] int NOT NULL DEFAULT 0;

GO

EXEC sp_rename N'[PurchOrderShipmentHeader].[CurrentShippingRouteId]', N'CurrentShippingRouteStepId', N'COLUMN';

GO

CREATE INDEX [IX_ShippingRoute_PortOfDestinationId] ON [ShippingRoute] ([PortOfDestinationId]);

GO

CREATE INDEX [IX_ShippingRoute_PortOfOriginId] ON [ShippingRoute] ([PortOfOriginId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_CurrentShippingRouteStepId] ON [PurchOrderShipmentHeader] ([CurrentShippingRouteStepId]);

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteStepId] FOREIGN KEY ([CurrentShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShippingRoute] ADD CONSTRAINT [FK_ShippingRoute_Port_PortOfDestinationId] FOREIGN KEY ([PortOfDestinationId]) REFERENCES [Port] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShippingRoute] ADD CONSTRAINT [FK_ShippingRoute_Port_PortOfOriginId] FOREIGN KEY ([PortOfOriginId]) REFERENCES [Port] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201129185502_ModifyingRoute', N'3.1.7');

GO

ALTER TABLE [PurchOrderDetail] ADD [Barcode] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderDetail] ADD [InventColorId] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderDetail] ADD [InventSizeId] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201214202754_ItemFieldsInPurchoOrderDetail', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [ShipmentImportId] bigint NULL;

GO

CREATE TABLE [ShipmentImport] (
    [Id] bigint NOT NULL IDENTITY,
    [ShippingRouteId] bigint NOT NULL,
    [CurrentShippingRouteStepId] bigint NOT NULL,
    [ShippingCompanyId] bigint NOT NULL,
    [Description] nvarchar(max) NULL,
    [DateCreated] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [ShipmentDateRequested] datetime2 NOT NULL,
    [ShipmentDateConfirmed] datetime2 NOT NULL,
    [DeliveryDate] datetime2 NOT NULL,
    [ReceiptDateConfirmed] datetime2 NOT NULL,
    [BLNumber] nvarchar(max) NULL,
    [EstimatedVolume] decimal(18,2) NOT NULL,
    [EstimatedWeight] decimal(18,2) NOT NULL,
    [Incoterm] nvarchar(max) NULL,
    CONSTRAINT [PK_ShipmentImport] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId] FOREIGN KEY ([CurrentShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ShipmentImport_ShippingCompany_ShippingCompanyId] FOREIGN KEY ([ShippingCompanyId]) REFERENCES [ShippingCompany] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ShipmentImport_ShippingRoute_ShippingRouteId] FOREIGN KEY ([ShippingRouteId]) REFERENCES [ShippingRoute] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_ShipmentImportId] ON [PurchOrderShipmentHeader] ([ShipmentImportId]);

GO

CREATE INDEX [IX_ShipmentImport_CurrentShippingRouteStepId] ON [ShipmentImport] ([CurrentShippingRouteStepId]);

GO

CREATE INDEX [IX_ShipmentImport_ShippingCompanyId] ON [ShipmentImport] ([ShippingCompanyId]);

GO

CREATE INDEX [IX_ShipmentImport_ShippingRouteId] ON [ShipmentImport] ([ShippingRouteId]);

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShipmentImport_ShipmentImportId] FOREIGN KEY ([ShipmentImportId]) REFERENCES [ShipmentImport] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201229110036_Adding ShippingImport', N'3.1.7');

GO

ALTER TABLE [ShipmentImport] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [ShipmentImport] ADD [Status] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210103155003_AddingStatustoShipmentImport', N'3.1.7');

GO

ALTER TABLE [ShipmentImport] DROP CONSTRAINT [FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId];

GO

ALTER TABLE [ShipmentImport] DROP CONSTRAINT [FK_ShipmentImport_ShippingCompany_ShippingCompanyId];

GO

ALTER TABLE [ShipmentImport] DROP CONSTRAINT [FK_ShipmentImport_ShippingRoute_ShippingRouteId];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShipmentImport]') AND [c].[name] = N'ShippingRouteId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ShipmentImport] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [ShipmentImport] ALTER COLUMN [ShippingRouteId] bigint NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShipmentImport]') AND [c].[name] = N'ShippingCompanyId');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ShipmentImport] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [ShipmentImport] ALTER COLUMN [ShippingCompanyId] bigint NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShipmentImport]') AND [c].[name] = N'CurrentShippingRouteStepId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ShipmentImport] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [ShipmentImport] ALTER COLUMN [CurrentShippingRouteStepId] bigint NULL;

GO

ALTER TABLE [ShipmentImport] ADD CONSTRAINT [FK_ShipmentImport_ShippingRouteStep_CurrentShippingRouteStepId] FOREIGN KEY ([CurrentShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentImport] ADD CONSTRAINT [FK_ShipmentImport_ShippingCompany_ShippingCompanyId] FOREIGN KEY ([ShippingCompanyId]) REFERENCES [ShippingCompany] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentImport] ADD CONSTRAINT [FK_ShipmentImport_ShippingRoute_ShippingRouteId] FOREIGN KEY ([ShippingRouteId]) REFERENCES [ShippingRoute] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210103155933_ModifiyingShipmentImport', N'3.1.7');

GO

ALTER TABLE [ShippingStepType] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingStepType] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingStepType] ADD [ModifiedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingStepType] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRouteStep] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRouteStep] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRouteStep] ADD [ModifiedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRouteStep] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRoute] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRoute] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRoute] ADD [ModifiedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRoute] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Port] ADD [Code] nvarchar(max) NULL;

GO

ALTER TABLE [Port] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Port] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Port] ADD [ModifiedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Port] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Country] ADD [Code] nvarchar(max) NULL;

GO

ALTER TABLE [Country] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Country] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Country] ADD [ModifiedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Country] ADD [ModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210109182859_PreparingForDataMigration', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [PreparationCurrentShippingRouteStepId] bigint NULL;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [PreparationShippingRouteId] bigint NULL;

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_PreparationCurrentShippingRouteStepId] ON [PurchOrderShipmentHeader] ([PreparationCurrentShippingRouteStepId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_PreparationShippingRouteId] ON [PurchOrderShipmentHeader] ([PreparationShippingRouteId]);

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRouteStep_PreparationCurrentShippingRouteStepId] FOREIGN KEY ([PreparationCurrentShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRoute_PreparationShippingRouteId] FOREIGN KEY ([PreparationShippingRouteId]) REFERENCES [ShippingRoute] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210205015345_PreparationRoute', N'3.1.7');

GO

ALTER TABLE [ShipmentLogEntry] ADD [Completed] bit NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210205121912_CompletedLogEntry', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRouteStep_CurrentShippingRouteStepId];

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_ShippingRouteStep_PreparationCurrentShippingRouteStepId];

GO

DROP INDEX [IX_PurchOrderShipmentHeader_CurrentShippingRouteStepId] ON [PurchOrderShipmentHeader];

GO

DROP INDEX [IX_PurchOrderShipmentHeader_PreparationCurrentShippingRouteStepId] ON [PurchOrderShipmentHeader];

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchOrderShipmentHeader]') AND [c].[name] = N'CurrentShippingRouteStepId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [PurchOrderShipmentHeader] DROP COLUMN [CurrentShippingRouteStepId];

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchOrderShipmentHeader]') AND [c].[name] = N'Incoterm');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [PurchOrderShipmentHeader] DROP COLUMN [Incoterm];

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchOrderShipmentHeader]') AND [c].[name] = N'PreparationCurrentShippingRouteStepId');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [PurchOrderShipmentHeader] DROP COLUMN [PreparationCurrentShippingRouteStepId];

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [IncotermId] bigint NULL;

GO

CREATE TABLE [Incoterm] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Incoterm] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_IncotermId] ON [PurchOrderShipmentHeader] ([IncotermId]);

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_Incoterm_IncotermId] FOREIGN KEY ([IncotermId]) REFERENCES [Incoterm] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210207134044_Incoterms', N'3.1.7');

GO

ALTER TABLE [ShippingRoute] ADD [ShippingRouteStatusPresentationSchemaId] bigint NULL;

GO

CREATE TABLE [PurchOrderShipmentRouteStepSuscription] (
    [Id] bigint NOT NULL IDENTITY,
    [PurchOrderShipmentHeaderId] bigint NOT NULL,
    [ShippingRouteStepId] bigint NOT NULL,
    [Username] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchOrderShipmentRouteStepSuscription] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId] FOREIGN KEY ([ShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ShippingRouteStatusPresentationSchema] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [NoRisk] decimal(18,2) NOT NULL,
    [LowRisk] decimal(18,2) NOT NULL,
    [HighRisk] decimal(18,2) NOT NULL,
    [OnTime] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ShippingRouteStatusPresentationSchema] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_ShippingRoute_ShippingRouteStatusPresentationSchemaId] ON [ShippingRoute] ([ShippingRouteStatusPresentationSchemaId]);

GO

CREATE INDEX [IX_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeaderId] ON [PurchOrderShipmentRouteStepSuscription] ([PurchOrderShipmentHeaderId]);

GO

CREATE INDEX [IX_PurchOrderShipmentRouteStepSuscription_ShippingRouteStepId] ON [PurchOrderShipmentRouteStepSuscription] ([ShippingRouteStepId]);

GO

ALTER TABLE [ShippingRoute] ADD CONSTRAINT [FK_ShippingRoute_ShippingRouteStatusPresentationSchema_ShippingRouteStatusPresentationSchemaId] FOREIGN KEY ([ShippingRouteStatusPresentationSchemaId]) REFERENCES [ShippingRouteStatusPresentationSchema] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210216102222_suscriptions', N'3.1.7');

GO

CREATE TABLE [Brand] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Color] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Color] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [InventDim] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InventDim] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [InventDimGroup] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InventDimGroup] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [InventItemGroup] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InventItemGroup] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchQuotation] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchQuotation] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchQuotationApprovalLog] (
    [Id] bigint NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchQuotationApprovalLog] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchQuotationApprovalRule] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchQuotationApprovalRule] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchQuotationApprovals] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PurchQuotationApprovals] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Size] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Size] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Store] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TaxItemGroupHeading] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_TaxItemGroupHeading] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TaxOnItem] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_TaxOnItem] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Unit] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Unit] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PurchQuotationLine] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [PurchQuotationId] bigint NOT NULL,
    CONSTRAINT [PK_PurchQuotationLine] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchQuotationLine_PurchQuotation_PurchQuotationId] FOREIGN KEY ([PurchQuotationId]) REFERENCES [PurchQuotation] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PurchQuotationApprovalRuleCondition] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [PurchQuotationApprovalRuleId] bigint NULL,
    CONSTRAINT [PK_PurchQuotationApprovalRuleCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId] FOREIGN KEY ([PurchQuotationApprovalRuleId]) REFERENCES [PurchQuotationApprovalRule] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [UnitConvert] (
    [Id] bigint NOT NULL IDENTITY,
    [FromUnitId] bigint NOT NULL,
    [ToUnitId] bigint NOT NULL,
    [Factor] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_UnitConvert] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UnitConvert_Unit_FromUnitId] FOREIGN KEY ([FromUnitId]) REFERENCES [Unit] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UnitConvert_Unit_ToUnitId] FOREIGN KEY ([ToUnitId]) REFERENCES [Unit] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PurchQuotationApprovalRuleConditionTerm] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [PurchQuotationApprovalRuleConditionId] bigint NULL,
    CONSTRAINT [PK_PurchQuotationApprovalRuleConditionTerm] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId] FOREIGN KEY ([PurchQuotationApprovalRuleConditionId]) REFERENCES [PurchQuotationApprovalRuleCondition] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleId] ON [PurchQuotationApprovalRuleCondition] ([PurchQuotationApprovalRuleId]);

GO

CREATE INDEX [IX_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleConditionId] ON [PurchQuotationApprovalRuleConditionTerm] ([PurchQuotationApprovalRuleConditionId]);

GO

CREATE INDEX [IX_PurchQuotationLine_PurchQuotationId] ON [PurchQuotationLine] ([PurchQuotationId]);

GO

CREATE INDEX [IX_UnitConvert_FromUnitId] ON [UnitConvert] ([FromUnitId]);

GO

CREATE INDEX [IX_UnitConvert_ToUnitId] ON [UnitConvert] ([ToUnitId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210218021107_itemconfigtables', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [EstimatedContainerQty] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [InvoiceNumber] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderHeader] ADD [Reference] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210222133449_POShipmentNewFields', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [CommercialEventId] bigint NULL;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [ShipmentTypeId] bigint NULL;

GO

CREATE TABLE [CommercialEvent] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_CommercialEvent] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShipmentType] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ShipmentType] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_CommercialEventId] ON [PurchOrderShipmentHeader] ([CommercialEventId]);

GO

CREATE INDEX [IX_PurchOrderShipmentHeader_ShipmentTypeId] ON [PurchOrderShipmentHeader] ([ShipmentTypeId]);

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId] FOREIGN KEY ([CommercialEventId]) REFERENCES [CommercialEvent] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShipmentType_ShipmentTypeId] FOREIGN KEY ([ShipmentTypeId]) REFERENCES [ShipmentType] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210224205359_CommercialEvents', N'3.1.7');

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId];

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_ShipmentType_ShipmentTypeId];

GO

ALTER TABLE [ShipmentType] DROP CONSTRAINT [PK_ShipmentType];

GO

ALTER TABLE [CommercialEvent] DROP CONSTRAINT [PK_CommercialEvent];

GO

EXEC sp_rename N'[ShipmentType]', N'ShipmentTypes';

GO

EXEC sp_rename N'[CommercialEvent]', N'CommercialEvents';

GO

ALTER TABLE [ShipmentTypes] ADD CONSTRAINT [PK_ShipmentTypes] PRIMARY KEY ([Id]);

GO

ALTER TABLE [CommercialEvents] ADD CONSTRAINT [PK_CommercialEvents] PRIMARY KEY ([Id]);

GO

CREATE TABLE [UserSettings] (
    [Id] bigint NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_UserSettings] PRIMARY KEY ([Id])
);

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_CommercialEvents_CommercialEventId] FOREIGN KEY ([CommercialEventId]) REFERENCES [CommercialEvents] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_ShipmentTypes_ShipmentTypeId] FOREIGN KEY ([ShipmentTypeId]) REFERENCES [ShipmentTypes] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210224212707_UserSetting', N'3.1.7');

GO

ALTER TABLE [Store] ADD [BackStoreLocationCode] nvarchar(max) NULL;

GO

ALTER TABLE [Store] ADD [IncludedInSKUAnalysis] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Store] ADD [Number] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Store] ADD [StoreLocationCode] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210301015345_StoreFields', N'3.1.7');

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventItem]') AND [c].[name] = N'ItemId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [InventItem] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [InventItem] DROP COLUMN [ItemId];

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventItem]') AND [c].[name] = N'ItemName');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [InventItem] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [InventItem] DROP COLUMN [ItemName];

GO

ALTER TABLE [UnitConvert] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [Unit] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [Size] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [Size] ADD [InventItemId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [ItemBarcode] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [InventItemGroup] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [InventItem] ADD [AllowDiscount] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventItem] ADD [BrandId] bigint NULL;

GO

ALTER TABLE [InventItem] ADD [Code] nvarchar(max) NULL;

GO

ALTER TABLE [InventItem] ADD [Description] nvarchar(max) NULL;

GO

ALTER TABLE [InventItem] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [InventItem] ADD [EmployeeDiscountId] bigint NULL;

GO

ALTER TABLE [InventItem] ADD [GrossDepth] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [InventItem] ADD [GrossHeight] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [InventItem] ADD [GrossWidth] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [InventItem] ADD [InventItemGroupId] bigint NULL;

GO

ALTER TABLE [InventItem] ADD [InventModelGroupId] bigint NULL;

GO

ALTER TABLE [InventItem] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventItem] ADD [ItemHierarchyId] bigint NULL;

GO

ALTER TABLE [InventItem] ADD [ItemType] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [InventItem] ADD [VendorId] bigint NULL;

GO

ALTER TABLE [InventDimGroup] ADD [ColorRequired] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventDimGroup] ADD [ConfigurationRequired] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventDimGroup] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [InventDimGroup] ADD [SerialNumberRequired] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventDimGroup] ADD [SizeRequired] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventDimGroup] ADD [StyleRequired] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventDim] ADD [ColorId] bigint NULL;

GO

ALTER TABLE [InventDim] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [InventDim] ADD [InventItemId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [InventDim] ADD [SizeId] bigint NULL;

GO

ALTER TABLE [Color] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [Color] ADD [InventItemId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [Brand] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

CREATE TABLE [EmployeeDiscounts] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [DiscountPercentage] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_EmployeeDiscounts] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [InventItemStoreConfigurations] (
    [Id] bigint NOT NULL IDENTITY,
    [ERPRecId] bigint NOT NULL,
    [AllowToSell] bit NOT NULL,
    [InventItemId] bigint NOT NULL,
    [StoreId] bigint NOT NULL,
    CONSTRAINT [PK_InventItemStoreConfigurations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InventItemStoreConfigurations_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_InventItemStoreConfigurations_Store_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Store] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [InventModelGroups] (
    [Id] bigint NOT NULL IDENTITY,
    [ERPRecId] bigint NOT NULL,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_InventModelGroups] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ItemHierarchies] (
    [Id] bigint NOT NULL IDENTITY,
    CONSTRAINT [PK_ItemHierarchies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Vendors] (
    [Id] bigint NOT NULL IDENTITY,
    [ERPRecId] bigint NOT NULL,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Size_InventItemId] ON [Size] ([InventItemId]);

GO

CREATE INDEX [IX_InventItem_BrandId] ON [InventItem] ([BrandId]);

GO

CREATE INDEX [IX_InventItem_EmployeeDiscountId] ON [InventItem] ([EmployeeDiscountId]);

GO

CREATE INDEX [IX_InventItem_InventItemGroupId] ON [InventItem] ([InventItemGroupId]);

GO

CREATE INDEX [IX_InventItem_InventModelGroupId] ON [InventItem] ([InventModelGroupId]);

GO

CREATE INDEX [IX_InventItem_ItemHierarchyId] ON [InventItem] ([ItemHierarchyId]);

GO

CREATE INDEX [IX_InventItem_VendorId] ON [InventItem] ([VendorId]);

GO

CREATE INDEX [IX_InventDim_ColorId] ON [InventDim] ([ColorId]);

GO

CREATE INDEX [IX_InventDim_InventItemId] ON [InventDim] ([InventItemId]);

GO

CREATE INDEX [IX_InventDim_SizeId] ON [InventDim] ([SizeId]);

GO

CREATE INDEX [IX_Color_InventItemId] ON [Color] ([InventItemId]);

GO

CREATE INDEX [IX_InventItemStoreConfigurations_InventItemId] ON [InventItemStoreConfigurations] ([InventItemId]);

GO

CREATE INDEX [IX_InventItemStoreConfigurations_StoreId] ON [InventItemStoreConfigurations] ([StoreId]);

GO

ALTER TABLE [Color] ADD CONSTRAINT [FK_Color_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventDim] ADD CONSTRAINT [FK_InventDim_Color_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [Color] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventDim] ADD CONSTRAINT [FK_InventDim_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventDim] ADD CONSTRAINT [FK_InventDim_Size_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [Size] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_Brand_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_EmployeeDiscounts_EmployeeDiscountId] FOREIGN KEY ([EmployeeDiscountId]) REFERENCES [EmployeeDiscounts] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_InventItemGroup_InventItemGroupId] FOREIGN KEY ([InventItemGroupId]) REFERENCES [InventItemGroup] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_InventModelGroups_InventModelGroupId] FOREIGN KEY ([InventModelGroupId]) REFERENCES [InventModelGroups] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_ItemHierarchies_ItemHierarchyId] FOREIGN KEY ([ItemHierarchyId]) REFERENCES [ItemHierarchies] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_Vendors_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Vendors] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Size] ADD CONSTRAINT [FK_Size_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210313123526_ItemProperties', N'3.1.7');

GO

ALTER TABLE [UnitConvert] ADD [InventItemId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [TaxOnItem] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [TaxItemGroupHeading] ADD [ERPRecId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

CREATE INDEX [IX_UnitConvert_InventItemId] ON [UnitConvert] ([InventItemId]);

GO

ALTER TABLE [UnitConvert] ADD CONSTRAINT [FK_UnitConvert_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210315155007_ERPRecIdinTaxTables', N'3.1.7');

GO

ALTER TABLE [TaxOnItem] ADD [TaxItemGroupHeadingId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

CREATE INDEX [IX_TaxOnItem_TaxItemGroupHeadingId] ON [TaxOnItem] ([TaxItemGroupHeadingId]);

GO

ALTER TABLE [TaxOnItem] ADD CONSTRAINT [FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId] FOREIGN KEY ([TaxItemGroupHeadingId]) REFERENCES [TaxItemGroupHeading] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210315194822_TaxItemGroupHeadingIdinTaxOnItem', N'3.1.7');

GO

ALTER TABLE [InventItem] DROP CONSTRAINT [FK_InventItem_EmployeeDiscounts_EmployeeDiscountId];

GO

ALTER TABLE [InventItem] DROP CONSTRAINT [FK_InventItem_InventModelGroups_InventModelGroupId];

GO

ALTER TABLE [InventItem] DROP CONSTRAINT [FK_InventItem_ItemHierarchies_ItemHierarchyId];

GO

ALTER TABLE [InventItem] DROP CONSTRAINT [FK_InventItem_Vendors_VendorId];

GO

ALTER TABLE [InventItemStoreConfigurations] DROP CONSTRAINT [FK_InventItemStoreConfigurations_InventItem_InventItemId];

GO

ALTER TABLE [InventItemStoreConfigurations] DROP CONSTRAINT [FK_InventItemStoreConfigurations_Store_StoreId];

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_CommercialEvents_CommercialEventId];

GO

DROP TABLE [EmployeeDiscounts];

GO

DROP INDEX [IX_InventItem_EmployeeDiscountId] ON [InventItem];

GO

ALTER TABLE [Vendors] DROP CONSTRAINT [PK_Vendors];

GO

ALTER TABLE [PurchQuotationApprovals] DROP CONSTRAINT [PK_PurchQuotationApprovals];

GO

ALTER TABLE [ItemHierarchies] DROP CONSTRAINT [PK_ItemHierarchies];

GO

ALTER TABLE [InventModelGroups] DROP CONSTRAINT [PK_InventModelGroups];

GO

ALTER TABLE [InventItemStoreConfigurations] DROP CONSTRAINT [PK_InventItemStoreConfigurations];

GO

ALTER TABLE [CommercialEvents] DROP CONSTRAINT [PK_CommercialEvents];

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventItem]') AND [c].[name] = N'EmployeeDiscountId');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [InventItem] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [InventItem] DROP COLUMN [EmployeeDiscountId];

GO

EXEC sp_rename N'[Vendors]', N'Vendor';

GO

EXEC sp_rename N'[PurchQuotationApprovals]', N'PurchQuotationApproval';

GO

EXEC sp_rename N'[ItemHierarchies]', N'ItemHierarchy';

GO

EXEC sp_rename N'[InventModelGroups]', N'InventModelGroup';

GO

EXEC sp_rename N'[InventItemStoreConfigurations]', N'InventItemStoreConfiguration';

GO

EXEC sp_rename N'[CommercialEvents]', N'CommercialEvent';

GO

EXEC sp_rename N'[InventItemStoreConfiguration].[IX_InventItemStoreConfigurations_StoreId]', N'IX_InventItemStoreConfiguration_StoreId', N'INDEX';

GO

EXEC sp_rename N'[InventItemStoreConfiguration].[IX_InventItemStoreConfigurations_InventItemId]', N'IX_InventItemStoreConfiguration_InventItemId', N'INDEX';

GO

ALTER TABLE [InventItem] ADD [EmployeeDiscountType] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [InventItem] ADD [InventDimGroupId] bigint NULL;

GO

ALTER TABLE [InventItem] ADD [TaxItemGroupHeadingId] bigint NULL;

GO

ALTER TABLE [Vendor] ADD CONSTRAINT [PK_Vendor] PRIMARY KEY ([Id]);

GO

ALTER TABLE [PurchQuotationApproval] ADD CONSTRAINT [PK_PurchQuotationApproval] PRIMARY KEY ([Id]);

GO

ALTER TABLE [ItemHierarchy] ADD CONSTRAINT [PK_ItemHierarchy] PRIMARY KEY ([Id]);

GO

ALTER TABLE [InventModelGroup] ADD CONSTRAINT [PK_InventModelGroup] PRIMARY KEY ([Id]);

GO

ALTER TABLE [InventItemStoreConfiguration] ADD CONSTRAINT [PK_InventItemStoreConfiguration] PRIMARY KEY ([Id]);

GO

ALTER TABLE [CommercialEvent] ADD CONSTRAINT [PK_CommercialEvent] PRIMARY KEY ([Id]);

GO

CREATE INDEX [IX_InventItem_InventDimGroupId] ON [InventItem] ([InventDimGroupId]);

GO

CREATE INDEX [IX_InventItem_TaxItemGroupHeadingId] ON [InventItem] ([TaxItemGroupHeadingId]);

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_InventDimGroup_InventDimGroupId] FOREIGN KEY ([InventDimGroupId]) REFERENCES [InventDimGroup] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_InventModelGroup_InventModelGroupId] FOREIGN KEY ([InventModelGroupId]) REFERENCES [InventModelGroup] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_ItemHierarchy_ItemHierarchyId] FOREIGN KEY ([ItemHierarchyId]) REFERENCES [ItemHierarchy] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_TaxItemGroupHeading_TaxItemGroupHeadingId] FOREIGN KEY ([TaxItemGroupHeadingId]) REFERENCES [TaxItemGroupHeading] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_Vendor_VendorId] FOREIGN KEY ([VendorId]) REFERENCES [Vendor] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItemStoreConfiguration] ADD CONSTRAINT [FK_InventItemStoreConfiguration_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [InventItemStoreConfiguration] ADD CONSTRAINT [FK_InventItemStoreConfiguration_Store_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Store] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_CommercialEvent_CommercialEventId] FOREIGN KEY ([CommercialEventId]) REFERENCES [CommercialEvent] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210316153042_TaxInInventItem', N'3.1.7');

GO

ALTER TABLE [Brand] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Brand] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Brand] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Brand] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210320103240_BrandAsAuditableEntity', N'3.1.7');

GO

ALTER TABLE [Vendor] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Vendor] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Vendor] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Vendor] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [UserSettings] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [UserSettings] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [UserSettings] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [UserSettings] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [UnitConvert] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [UnitConvert] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [UnitConvert] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [UnitConvert] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Unit] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Unit] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Unit] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Unit] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TaxOnItem] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [TaxOnItem] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TaxOnItem] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [TaxOnItem] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TaxItemGroupHeading] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [TaxItemGroupHeading] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TaxItemGroupHeading] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [TaxItemGroupHeading] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Store] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Store] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Store] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Store] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Size] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Size] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Size] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Size] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingStepType] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingStepType] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRouteStep] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRouteStep] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRouteStatusPresentationSchema] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRouteStatusPresentationSchema] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRouteStatusPresentationSchema] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRouteStatusPresentationSchema] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingRoute] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingRoute] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingCompany] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingCompany] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShippingCompany] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShippingCompany] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentTypes] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentTypes] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentTypes] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentTypes] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentLogEntry] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentLogEntry] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentLogEntry] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentLogEntry] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentImport] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentImport] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentImport] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentImport] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentContainerType] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentContainerType] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentContainerType] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentContainerType] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentContainerDetail] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentContainerDetail] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentContainerDetail] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentContainerDetail] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentContainer] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentContainer] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ShipmentContainer] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ShipmentContainer] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationLine] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationLine] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalRule] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRule] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalRule] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRule] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApproval] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApproval] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotationApproval] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApproval] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotation] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotation] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchQuotation] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotation] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderShipmentDetail] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderShipmentDetail] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderShipmentDetail] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderShipmentDetail] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderHeader] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderHeader] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderHeader] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderHeader] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderDetail] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderDetail] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [PurchOrderDetail] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [PurchOrderDetail] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Port] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Port] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ItemHierarchy] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ItemHierarchy] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [ItemHierarchy] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [ItemHierarchy] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventModelGroup] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventModelGroup] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventModelGroup] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventModelGroup] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventItemStoreConfiguration] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventItemStoreConfiguration] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventItemStoreConfiguration] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventItemStoreConfiguration] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventItemGroup] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventItemGroup] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventItemGroup] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventItemGroup] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventItem] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventItem] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventItem] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventItem] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventDimGroup] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventDimGroup] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventDimGroup] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventDimGroup] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventDim] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventDim] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [InventDim] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [InventDim] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Incoterm] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Incoterm] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Incoterm] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Incoterm] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Country] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Country] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [CommercialEvent] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [CommercialEvent] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [CommercialEvent] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [CommercialEvent] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Color] ADD [CreatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Color] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Color] ADD [UpdatedBy] nvarchar(max) NULL;

GO

ALTER TABLE [Color] ADD [UpdatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210320124456_NewFieldsForAuditableEntity', N'3.1.7');

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] DROP CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId];

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] DROP CONSTRAINT [FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId];

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingStepType]') AND [c].[name] = N'ModifiedBy');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [ShippingStepType] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [ShippingStepType] DROP COLUMN [ModifiedBy];

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingStepType]') AND [c].[name] = N'ModifiedDate');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [ShippingStepType] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [ShippingStepType] DROP COLUMN [ModifiedDate];

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingRouteStep]') AND [c].[name] = N'ModifiedBy');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [ShippingRouteStep] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [ShippingRouteStep] DROP COLUMN [ModifiedBy];

GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingRouteStep]') AND [c].[name] = N'ModifiedDate');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [ShippingRouteStep] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [ShippingRouteStep] DROP COLUMN [ModifiedDate];

GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingRoute]') AND [c].[name] = N'ModifiedBy');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [ShippingRoute] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [ShippingRoute] DROP COLUMN [ModifiedBy];

GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingRoute]') AND [c].[name] = N'ModifiedDate');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [ShippingRoute] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [ShippingRoute] DROP COLUMN [ModifiedDate];

GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Port]') AND [c].[name] = N'ModifiedBy');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Port] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [Port] DROP COLUMN [ModifiedBy];

GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Port]') AND [c].[name] = N'ModifiedDate');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Port] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [Port] DROP COLUMN [ModifiedDate];

GO

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Country]') AND [c].[name] = N'ModifiedBy');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Country] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [Country] DROP COLUMN [ModifiedBy];

GO

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Country]') AND [c].[name] = N'ModifiedDate');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Country] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [Country] DROP COLUMN [ModifiedDate];

GO

DROP INDEX [IX_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleConditionId] ON [PurchQuotationApprovalRuleConditionTerm];
DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchQuotationApprovalRuleConditionTerm]') AND [c].[name] = N'PurchQuotationApprovalRuleConditionId');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ALTER COLUMN [PurchQuotationApprovalRuleConditionId] bigint NOT NULL;
CREATE INDEX [IX_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleConditionId] ON [PurchQuotationApprovalRuleConditionTerm] ([PurchQuotationApprovalRuleConditionId]);

GO

DROP INDEX [IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleId] ON [PurchQuotationApprovalRuleCondition];
DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchQuotationApprovalRuleCondition]') AND [c].[name] = N'PurchQuotationApprovalRuleId');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [PurchQuotationApprovalRuleCondition] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [PurchQuotationApprovalRuleCondition] ALTER COLUMN [PurchQuotationApprovalRuleId] bigint NOT NULL;
CREATE INDEX [IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleId] ON [PurchQuotationApprovalRuleCondition] ([PurchQuotationApprovalRuleId]);

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD [PurchQuotationId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

CREATE INDEX [IX_PurchQuotationApprovalLog_PurchQuotationId] ON [PurchQuotationApprovalLog] ([PurchQuotationId]);

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD CONSTRAINT [FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId] FOREIGN KEY ([PurchQuotationId]) REFERENCES [PurchQuotation] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId] FOREIGN KEY ([PurchQuotationApprovalRuleId]) REFERENCES [PurchQuotationApprovalRule] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD CONSTRAINT [FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId] FOREIGN KEY ([PurchQuotationApprovalRuleConditionId]) REFERENCES [PurchQuotationApprovalRuleCondition] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210321132055_PurchQuotationIdinPurchQuotationApprovalLog', N'3.1.7');

GO

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchQuotationApprovalRuleConditionTerm]') AND [c].[name] = N'Code');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] DROP COLUMN [Code];

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [ComparisonValue] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [LowerBound] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [PurchQuotationApprovalRuleConditionComparisonOperation] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [PurchQuotationApprovalRuleConditionField] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD [UpperBound] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD [Priority] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD [PurchQuotationApprovalId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

CREATE INDEX [IX_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalId] ON [PurchQuotationApprovalRuleCondition] ([PurchQuotationApprovalId]);

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId] FOREIGN KEY ([PurchQuotationApprovalId]) REFERENCES [PurchQuotationApproval] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210327125251_RulesAndConditionFields', N'3.1.7');

GO

ALTER TABLE [ShippingStepType] ADD [ShippingStepERPAction] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210329151800_ShippingStepERPAction', N'3.1.7');

GO

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchOrderShipmentHeader]') AND [c].[name] = N'BLNumber');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [PurchOrderShipmentHeader] DROP COLUMN [BLNumber];

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD [Code] AS replicate('0' , 8-len(convert(varchar(8), [id] ))) + convert(varchar(8), [id] );

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210330165307_PurchOrderShipmentHeaderCode', N'3.1.7');

GO

ALTER TABLE [Vendor] ADD [AllowPurchOrderShipments] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210330232445_Vendor', N'3.1.7');

GO

ALTER TABLE [ItemHierarchy] ADD [Code] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [ItemHierarchy] ADD [Description] nvarchar(max) NULL;

GO

CREATE TABLE [EmployeeDiscount] (
    [Id] bigint NOT NULL IDENTITY,
    [CreatedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedDate] datetime2 NOT NULL,
    [UpdatedBy] nvarchar(max) NULL,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [DiscountPercentage] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_EmployeeDiscount] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414113748_AddingItemHierarchyAndInventModelGroup', N'3.1.7');

GO

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ItemHierarchy]') AND [c].[name] = N'Code');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [ItemHierarchy] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [ItemHierarchy] ALTER COLUMN [Code] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414121416_fixItemrHierarchy', N'3.1.7');

GO

DECLARE @var29 sysname;
SELECT @var29 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[InventItem]') AND [c].[name] = N'EmployeeDiscountType');
IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [InventItem] DROP CONSTRAINT [' + @var29 + '];');
ALTER TABLE [InventItem] DROP COLUMN [EmployeeDiscountType];

GO

ALTER TABLE [InventItem] ADD [EmployeeDiscountId] bigint NULL;

GO

CREATE INDEX [IX_InventItem_EmployeeDiscountId] ON [InventItem] ([EmployeeDiscountId]);

GO

ALTER TABLE [InventItem] ADD CONSTRAINT [FK_InventItem_EmployeeDiscount_EmployeeDiscountId] FOREIGN KEY ([EmployeeDiscountId]) REFERENCES [EmployeeDiscount] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414122750_EmployeeDiscountInInventItem', N'3.1.7');

GO

DECLARE @var30 sysname;
SELECT @var30 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchQuotationLine]') AND [c].[name] = N'Code');
IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [PurchQuotationLine] DROP CONSTRAINT [' + @var30 + '];');
ALTER TABLE [PurchQuotationLine] DROP COLUMN [Code];

GO

DECLARE @var31 sysname;
SELECT @var31 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchQuotationLine]') AND [c].[name] = N'Description');
IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [PurchQuotationLine] DROP CONSTRAINT [' + @var31 + '];');
ALTER TABLE [PurchQuotationLine] DROP COLUMN [Description];

GO

ALTER TABLE [PurchQuotationLine] ADD [ColorCode] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [ColorDescription] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [ColorId] bigint NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [InventItemCode] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [InventItemDescription] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [InventItemId] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

ALTER TABLE [PurchQuotationLine] ADD [ItemBarcodeCode] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [ItemBarcodeDescription] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [ItemBarcodeId] bigint NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [LineAmount] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchQuotationLine] ADD [PurchPrice] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchQuotationLine] ADD [QtyOrdered] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [PurchQuotationLine] ADD [SizeCode] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [SizeDescription] nvarchar(max) NULL;

GO

ALTER TABLE [PurchQuotationLine] ADD [SizeId] bigint NULL;

GO

CREATE INDEX [IX_PurchQuotationLine_ColorId] ON [PurchQuotationLine] ([ColorId]);

GO

CREATE INDEX [IX_PurchQuotationLine_InventItemId] ON [PurchQuotationLine] ([InventItemId]);

GO

CREATE INDEX [IX_PurchQuotationLine_ItemBarcodeId] ON [PurchQuotationLine] ([ItemBarcodeId]);

GO

CREATE INDEX [IX_PurchQuotationLine_SizeId] ON [PurchQuotationLine] ([SizeId]);

GO

ALTER TABLE [PurchQuotationLine] ADD CONSTRAINT [FK_PurchQuotationLine_Color_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [Color] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationLine] ADD CONSTRAINT [FK_PurchQuotationLine_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationLine] ADD CONSTRAINT [FK_PurchQuotationLine_ItemBarcode_ItemBarcodeId] FOREIGN KEY ([ItemBarcodeId]) REFERENCES [ItemBarcode] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationLine] ADD CONSTRAINT [FK_PurchQuotationLine_Size_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [Size] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414200105_PurchQuotationLineFields', N'3.1.7');

GO

CREATE TABLE [BarcodeBatch] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [QtyRequested] int NOT NULL,
    [QtyGenerated] int NOT NULL,
    CONSTRAINT [PK_BarcodeBatch] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [BarcodeSource] (
    [Id] bigint NOT NULL IDENTITY,
    [RangeFirst] bigint NOT NULL,
    [RangeLast] bigint NOT NULL,
    CONSTRAINT [PK_BarcodeSource] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [CustomerPriceGroup] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_CustomerPriceGroup] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SalesPriceDefinition] (
    [Id] bigint NOT NULL IDENTITY,
    [Code] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [SalesPriceDefinitionStatus] int NOT NULL,
    CONSTRAINT [PK_SalesPriceDefinition] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Barcode] (
    [Id] bigint NOT NULL IDENTITY,
    [Number] bigint NOT NULL,
    [ControlDigit] int NOT NULL,
    [Code] nvarchar(max) NULL,
    [BarcodeBatchId] bigint NOT NULL,
    [BarcodeSourceId] bigint NOT NULL,
    CONSTRAINT [PK_Barcode] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Barcode_BarcodeBatch_BarcodeBatchId] FOREIGN KEY ([BarcodeBatchId]) REFERENCES [BarcodeBatch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Barcode_BarcodeSource_BarcodeSourceId] FOREIGN KEY ([BarcodeSourceId]) REFERENCES [BarcodeSource] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SalesPrice] (
    [Id] bigint NOT NULL IDENTITY,
    [Price] decimal(18,2) NOT NULL,
    [InventItemId] bigint NOT NULL,
    [CustomerPriceGroupId] bigint NOT NULL,
    CONSTRAINT [PK_SalesPrice] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId] FOREIGN KEY ([CustomerPriceGroupId]) REFERENCES [CustomerPriceGroup] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SalesPrice_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SalesPriceDefinitionLine] (
    [Id] bigint NOT NULL IDENTITY,
    [InventItemId] bigint NULL,
    [InventItemCode] nvarchar(max) NULL,
    [CustomerPriceGroupId] bigint NULL,
    [CustomerPriceGroupCode] nvarchar(max) NULL,
    [Price] decimal(18,2) NOT NULL,
    [SalesPriceId] bigint NULL,
    [SalesPriceDefinitionId] bigint NULL,
    CONSTRAINT [PK_SalesPriceDefinitionLine] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SalesPriceDefinitionLine_CustomerPriceGroup_CustomerPriceGroupId] FOREIGN KEY ([CustomerPriceGroupId]) REFERENCES [CustomerPriceGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SalesPriceDefinitionLine_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId] FOREIGN KEY ([SalesPriceDefinitionId]) REFERENCES [SalesPriceDefinition] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SalesPriceDefinitionLine_SalesPrice_SalesPriceId] FOREIGN KEY ([SalesPriceId]) REFERENCES [SalesPrice] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Barcode_BarcodeBatchId] ON [Barcode] ([BarcodeBatchId]);

GO

CREATE INDEX [IX_Barcode_BarcodeSourceId] ON [Barcode] ([BarcodeSourceId]);

GO

CREATE INDEX [IX_SalesPrice_CustomerPriceGroupId] ON [SalesPrice] ([CustomerPriceGroupId]);

GO

CREATE INDEX [IX_SalesPrice_InventItemId] ON [SalesPrice] ([InventItemId]);

GO

CREATE INDEX [IX_SalesPriceDefinitionLine_CustomerPriceGroupId] ON [SalesPriceDefinitionLine] ([CustomerPriceGroupId]);

GO

CREATE INDEX [IX_SalesPriceDefinitionLine_InventItemId] ON [SalesPriceDefinitionLine] ([InventItemId]);

GO

CREATE INDEX [IX_SalesPriceDefinitionLine_SalesPriceDefinitionId] ON [SalesPriceDefinitionLine] ([SalesPriceDefinitionId]);

GO

CREATE INDEX [IX_SalesPriceDefinitionLine_SalesPriceId] ON [SalesPriceDefinitionLine] ([SalesPriceId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210414231454_BarcodesAndPrices', N'3.1.7');

GO

ALTER TABLE [BarcodeSource] ADD [NextAvailable] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415013610_NextInBarcodeSource', N'3.1.7');

GO

ALTER TABLE [ItemHierarchy] ADD [ItemHierarchyLevel] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [ItemHierarchy] ADD [ParentId] bigint NULL;

GO

CREATE INDEX [IX_ItemHierarchy_ParentId] ON [ItemHierarchy] ([ParentId]);

GO

ALTER TABLE [ItemHierarchy] ADD CONSTRAINT [FK_ItemHierarchy_ItemHierarchy_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [ItemHierarchy] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210415113330_ItemHierachyLevels', N'3.1.7');

GO

ALTER TABLE [SalesPriceDefinitionLine] DROP CONSTRAINT [FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId];

GO

ALTER TABLE [UnitConvert] ADD [GrossDepth] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [UnitConvert] ADD [GrossHeight] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [UnitConvert] ADD [GrossWeight] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [UnitConvert] ADD [GrossWidth] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

DROP INDEX [IX_SalesPriceDefinitionLine_SalesPriceDefinitionId] ON [SalesPriceDefinitionLine];
DECLARE @var32 sysname;
SELECT @var32 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SalesPriceDefinitionLine]') AND [c].[name] = N'SalesPriceDefinitionId');
IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [SalesPriceDefinitionLine] DROP CONSTRAINT [' + @var32 + '];');
ALTER TABLE [SalesPriceDefinitionLine] ALTER COLUMN [SalesPriceDefinitionId] bigint NOT NULL;
CREATE INDEX [IX_SalesPriceDefinitionLine_SalesPriceDefinitionId] ON [SalesPriceDefinitionLine] ([SalesPriceDefinitionId]);

GO

ALTER TABLE [InventItem] ADD [GrossWeight] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [SalesPriceDefinitionLine] ADD CONSTRAINT [FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId] FOREIGN KEY ([SalesPriceDefinitionId]) REFERENCES [SalesPriceDefinition] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210417100814_DimensionsInUnitConvert', N'3.1.7');

GO

ALTER TABLE [Barcode] DROP CONSTRAINT [FK_Barcode_BarcodeBatch_BarcodeBatchId];

GO

ALTER TABLE [Barcode] DROP CONSTRAINT [FK_Barcode_BarcodeSource_BarcodeSourceId];

GO

ALTER TABLE [Color] DROP CONSTRAINT [FK_Color_InventItem_InventItemId];

GO

ALTER TABLE [InventDim] DROP CONSTRAINT [FK_InventDim_InventItem_InventItemId];

GO

ALTER TABLE [InventItemStoreConfiguration] DROP CONSTRAINT [FK_InventItemStoreConfiguration_InventItem_InventItemId];

GO

ALTER TABLE [InventItemStoreConfiguration] DROP CONSTRAINT [FK_InventItemStoreConfiguration_Store_StoreId];

GO

ALTER TABLE [PurchOrderDetail] DROP CONSTRAINT [FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId];

GO

ALTER TABLE [PurchOrderShipmentDetail] DROP CONSTRAINT [FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId];

GO

ALTER TABLE [PurchOrderShipmentDetail] DROP CONSTRAINT [FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId];

GO

ALTER TABLE [PurchOrderShipmentHeader] DROP CONSTRAINT [FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId];

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] DROP CONSTRAINT [FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId];

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] DROP CONSTRAINT [FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId];

GO

ALTER TABLE [PurchQuotationApprovalLog] DROP CONSTRAINT [FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId];

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] DROP CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId];

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] DROP CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId];

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] DROP CONSTRAINT [FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId];

GO

ALTER TABLE [PurchQuotationLine] DROP CONSTRAINT [FK_PurchQuotationLine_InventItem_InventItemId];

GO

ALTER TABLE [PurchQuotationLine] DROP CONSTRAINT [FK_PurchQuotationLine_PurchQuotation_PurchQuotationId];

GO

ALTER TABLE [SalesPrice] DROP CONSTRAINT [FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId];

GO

ALTER TABLE [SalesPrice] DROP CONSTRAINT [FK_SalesPrice_InventItem_InventItemId];

GO

ALTER TABLE [SalesPriceDefinitionLine] DROP CONSTRAINT [FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId];

GO

ALTER TABLE [ShipmentContainer] DROP CONSTRAINT [FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId];

GO

ALTER TABLE [ShipmentContainer] DROP CONSTRAINT [FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId];

GO

ALTER TABLE [ShipmentContainerDetail] DROP CONSTRAINT [FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId];

GO

ALTER TABLE [ShipmentContainerDetail] DROP CONSTRAINT [FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId];

GO

ALTER TABLE [ShipmentLogEntry] DROP CONSTRAINT [FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId];

GO

ALTER TABLE [ShipmentLogEntry] DROP CONSTRAINT [FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId];

GO

ALTER TABLE [ShippingRouteStep] DROP CONSTRAINT [FK_ShippingRouteStep_ShippingRoute_ShippingRouteId];

GO

ALTER TABLE [ShippingRouteStep] DROP CONSTRAINT [FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId];

GO

ALTER TABLE [Size] DROP CONSTRAINT [FK_Size_InventItem_InventItemId];

GO

ALTER TABLE [TaxOnItem] DROP CONSTRAINT [FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId];

GO

ALTER TABLE [UnitConvert] DROP CONSTRAINT [FK_UnitConvert_Unit_FromUnitId];

GO

ALTER TABLE [UnitConvert] DROP CONSTRAINT [FK_UnitConvert_InventItem_InventItemId];

GO

ALTER TABLE [UnitConvert] DROP CONSTRAINT [FK_UnitConvert_Unit_ToUnitId];

GO

ALTER TABLE [Barcode] ADD CONSTRAINT [FK_Barcode_BarcodeBatch_BarcodeBatchId] FOREIGN KEY ([BarcodeBatchId]) REFERENCES [BarcodeBatch] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Barcode] ADD CONSTRAINT [FK_Barcode_BarcodeSource_BarcodeSourceId] FOREIGN KEY ([BarcodeSourceId]) REFERENCES [BarcodeSource] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Color] ADD CONSTRAINT [FK_Color_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventDim] ADD CONSTRAINT [FK_InventDim_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItemStoreConfiguration] ADD CONSTRAINT [FK_InventItemStoreConfiguration_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [InventItemStoreConfiguration] ADD CONSTRAINT [FK_InventItemStoreConfiguration_Store_StoreId] FOREIGN KEY ([StoreId]) REFERENCES [Store] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderDetail] ADD CONSTRAINT [FK_PurchOrderDetail_PurchOrderHeader_PurchOrderHeaderId] FOREIGN KEY ([PurchOrderHeaderId]) REFERENCES [PurchOrderHeader] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentDetail] ADD CONSTRAINT [FK_PurchOrderShipmentDetail_PurchOrderDetail_PurchOrderDetailId] FOREIGN KEY ([PurchOrderDetailId]) REFERENCES [PurchOrderDetail] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentDetail] ADD CONSTRAINT [FK_PurchOrderShipmentDetail_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentHeader] ADD CONSTRAINT [FK_PurchOrderShipmentHeader_PurchOrderHeader_PurchOrderHeaderId] FOREIGN KEY ([PurchOrderHeaderId]) REFERENCES [PurchOrderHeader] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] ADD CONSTRAINT [FK_PurchOrderShipmentRouteStepSuscription_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchOrderShipmentRouteStepSuscription] ADD CONSTRAINT [FK_PurchOrderShipmentRouteStepSuscription_ShippingRouteStep_ShippingRouteStepId] FOREIGN KEY ([ShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationApprovalLog] ADD CONSTRAINT [FK_PurchQuotationApprovalLog_PurchQuotation_PurchQuotationId] FOREIGN KEY ([PurchQuotationId]) REFERENCES [PurchQuotation] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApproval_PurchQuotationApprovalId] FOREIGN KEY ([PurchQuotationApprovalId]) REFERENCES [PurchQuotationApproval] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationApprovalRuleCondition] ADD CONSTRAINT [FK_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRule_PurchQuotationApprovalRuleId] FOREIGN KEY ([PurchQuotationApprovalRuleId]) REFERENCES [PurchQuotationApprovalRule] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationApprovalRuleConditionTerm] ADD CONSTRAINT [FK_PurchQuotationApprovalRuleConditionTerm_PurchQuotationApprovalRuleCondition_PurchQuotationApprovalRuleConditionId] FOREIGN KEY ([PurchQuotationApprovalRuleConditionId]) REFERENCES [PurchQuotationApprovalRuleCondition] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationLine] ADD CONSTRAINT [FK_PurchQuotationLine_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [PurchQuotationLine] ADD CONSTRAINT [FK_PurchQuotationLine_PurchQuotation_PurchQuotationId] FOREIGN KEY ([PurchQuotationId]) REFERENCES [PurchQuotation] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [SalesPrice] ADD CONSTRAINT [FK_SalesPrice_CustomerPriceGroup_CustomerPriceGroupId] FOREIGN KEY ([CustomerPriceGroupId]) REFERENCES [CustomerPriceGroup] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [SalesPrice] ADD CONSTRAINT [FK_SalesPrice_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [SalesPriceDefinitionLine] ADD CONSTRAINT [FK_SalesPriceDefinitionLine_SalesPriceDefinition_SalesPriceDefinitionId] FOREIGN KEY ([SalesPriceDefinitionId]) REFERENCES [SalesPriceDefinition] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentContainer] ADD CONSTRAINT [FK_ShipmentContainer_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentContainer] ADD CONSTRAINT [FK_ShipmentContainer_ShipmentContainerType_ShipmentContainerTypeId] FOREIGN KEY ([ShipmentContainerTypeId]) REFERENCES [ShipmentContainerType] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentContainerDetail] ADD CONSTRAINT [FK_ShipmentContainerDetail_PurchOrderDetail_PurchOrderDetailId] FOREIGN KEY ([PurchOrderDetailId]) REFERENCES [PurchOrderDetail] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentContainerDetail] ADD CONSTRAINT [FK_ShipmentContainerDetail_ShipmentContainer_ShipmentContainerId] FOREIGN KEY ([ShipmentContainerId]) REFERENCES [ShipmentContainer] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentLogEntry] ADD CONSTRAINT [FK_ShipmentLogEntry_PurchOrderShipmentHeader_PurchOrderShipmentHeaderId] FOREIGN KEY ([PurchOrderShipmentHeaderId]) REFERENCES [PurchOrderShipmentHeader] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShipmentLogEntry] ADD CONSTRAINT [FK_ShipmentLogEntry_ShippingRouteStep_ShippingRouteStepId] FOREIGN KEY ([ShippingRouteStepId]) REFERENCES [ShippingRouteStep] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShippingRouteStep] ADD CONSTRAINT [FK_ShippingRouteStep_ShippingRoute_ShippingRouteId] FOREIGN KEY ([ShippingRouteId]) REFERENCES [ShippingRoute] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ShippingRouteStep] ADD CONSTRAINT [FK_ShippingRouteStep_ShippingStepType_ShippingStepTypeId] FOREIGN KEY ([ShippingStepTypeId]) REFERENCES [ShippingStepType] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Size] ADD CONSTRAINT [FK_Size_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [TaxOnItem] ADD CONSTRAINT [FK_TaxOnItem_TaxItemGroupHeading_TaxItemGroupHeadingId] FOREIGN KEY ([TaxItemGroupHeadingId]) REFERENCES [TaxItemGroupHeading] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [UnitConvert] ADD CONSTRAINT [FK_UnitConvert_Unit_FromUnitId] FOREIGN KEY ([FromUnitId]) REFERENCES [Unit] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [UnitConvert] ADD CONSTRAINT [FK_UnitConvert_InventItem_InventItemId] FOREIGN KEY ([InventItemId]) REFERENCES [InventItem] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [UnitConvert] ADD CONSTRAINT [FK_UnitConvert_Unit_ToUnitId] FOREIGN KEY ([ToUnitId]) REFERENCES [Unit] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210417112550_RestrictFK', N'3.1.7');

GO

ALTER TABLE [InventItem] ADD [BlckedForSale] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [InventItem] ADD [Cost] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [InventItem] ADD [WebSiteDescription] decimal(18,2) NOT NULL DEFAULT 0.0;

GO

ALTER TABLE [InventItem] ADD [WebSiteStatus] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210417223521_NAVFieldsInItem', N'3.1.7');

GO

