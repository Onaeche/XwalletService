IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714153305_Initial_14072023')
BEGIN
    CREATE TABLE [customers] (
        [customerId] int NOT NULL IDENTITY,
        [walletAccount] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [firstName] nvarchar(max) NOT NULL,
        [lastName] nvarchar(max) NOT NULL,
        [middleName] nvarchar(max) NULL,
        [phoneNo] nvarchar(max) NOT NULL,
        [emailAddress] nvarchar(max) NULL,
        [address] nvarchar(max) NULL,
        [idType] nvarchar(max) NULL,
        [idNumber] nvarchar(max) NULL,
        [paasportPhoto] nvarchar(max) NULL,
        [isActive] bit NULL,
        [IsLoggedIn] bit NULL,
        [IsLockedOut] bit NULL,
        [IsDeleted] bit NULL,
        [createdDate] datetime2 NULL,
        [createdBy] nvarchar(max) NULL,
        [approvedDate] datetime2 NULL,
        [approvedBy] nvarchar(max) NULL,
        [modifiedDate] datetime2 NULL,
        [modifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_customers] PRIMARY KEY ([customerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714153305_Initial_14072023')
BEGIN
    CREATE TABLE [otpContainers] (
        [otpId] int NOT NULL IDENTITY,
        [otp] nvarchar(max) NOT NULL,
        [createdDate] datetime2 NOT NULL,
        [expiryDateTime] datetime2 NOT NULL,
        [status] nvarchar(max) NOT NULL,
        [isValidated] bit NOT NULL,
        CONSTRAINT [PK_otpContainers] PRIMARY KEY ([otpId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714153305_Initial_14072023')
BEGIN
    CREATE TABLE [tokenLogins] (
        [ID] int NOT NULL IDENTITY,
        [userName] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [createdDate] datetime2 NULL,
        [createdBy] nvarchar(max) NULL,
        CONSTRAINT [PK_tokenLogins] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714153305_Initial_14072023')
BEGIN
    CREATE TABLE [userRoles] (
        [roleId] int NOT NULL IDENTITY,
        [isAdmin] bit NOT NULL,
        [isUser] bit NOT NULL,
        [roleName] nvarchar(max) NOT NULL,
        [roleDescription] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_userRoles] PRIMARY KEY ([roleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714153305_Initial_14072023')
BEGIN
    CREATE TABLE [users] (
        [userId] int NOT NULL IDENTITY,
        [userName] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [businessName] nvarchar(max) NOT NULL,
        [businessAddress] nvarchar(max) NOT NULL,
        [firstName] nvarchar(max) NOT NULL,
        [lastName] nvarchar(max) NOT NULL,
        [middleName] nvarchar(max) NULL,
        [DOB] nvarchar(max) NULL,
        [BVN] nvarchar(max) NULL,
        [phoneNo] nvarchar(max) NULL,
        [emailAddress] nvarchar(max) NULL,
        [idType] nvarchar(max) NULL,
        [idNumber] nvarchar(max) NULL,
        [paasportPhoto] nvarchar(max) NULL,
        [serviceProvider] nvarchar(max) NULL,
        [address] nvarchar(max) NULL,
        [superSimPhoneNo] nvarchar(max) NULL,
        [roleId] int NULL,
        [isActive] bit NULL,
        [lastLoginDate] datetime2 NULL,
        [lastLogOutDate] datetime2 NULL,
        [IsLoggedIn] bit NULL,
        [IsLockedOut] bit NULL,
        [IsDeleted] bit NULL,
        [createdDate] datetime2 NULL,
        [createdBy] nvarchar(max) NULL,
        [approvedDate] datetime2 NULL,
        [approvedBy] nvarchar(max) NULL,
        [modifiedDate] datetime2 NULL,
        [modifiedBy] nvarchar(max) NULL,
        [token1] nvarchar(max) NOT NULL,
        [token2] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_users] PRIMARY KEY ([userId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230714153305_Initial_14072023')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230714153305_Initial_14072023', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'IsLockedOut');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [users] DROP COLUMN [IsLockedOut];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'IsLoggedIn');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [users] DROP COLUMN [IsLoggedIn];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'lastLogOutDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [users] DROP COLUMN [lastLogOutDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'lastLoginDate');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [users] DROP COLUMN [lastLoginDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'IsLockedOut');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [customers] DROP COLUMN [IsLockedOut];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'IsLoggedIn');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [customers] DROP COLUMN [IsLoggedIn];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'password');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [customers] DROP COLUMN [password];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    ALTER TABLE [customers] ADD [userId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    CREATE TABLE [logins] (
        [Id] int NOT NULL IDENTITY,
        [userName] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        [roleId] int NULL,
        [userId] int NOT NULL,
        [createdDate] datetime2 NULL,
        [lastLoginDate] datetime2 NULL,
        [lastLogOutDate] datetime2 NULL,
        [isActive] bit NULL,
        [IsLoggedIn] bit NULL,
        [IsLockedOut] bit NULL,
        CONSTRAINT [PK_logins] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    CREATE TABLE [transactionLogs] (
        [transId] nvarchar(450) NOT NULL,
        [requestid] nvarchar(max) NOT NULL,
        [FromAcctNo] nvarchar(max) NOT NULL,
        [ToAcctNo] nvarchar(max) NOT NULL,
        [walletAccount] nvarchar(max) NOT NULL,
        [customerId] int NOT NULL,
        [referenceId] nvarchar(max) NOT NULL,
        [transactionDate] datetime2 NOT NULL,
        [amount] decimal(18,4) NOT NULL,
        [roleId] int NOT NULL,
        [status] nvarchar(max) NOT NULL,
        [responseCode] nvarchar(max) NOT NULL,
        [responseMessage] nvarchar(max) NOT NULL,
        [naration] nvarchar(max) NOT NULL,
        [balanceBeforeTransaction] decimal(18,4) NOT NULL,
        [balanceAfterTransaction] decimal(18,4) NOT NULL,
        [transactionType] nvarchar(max) NOT NULL,
        [paymentDate] datetime2 NOT NULL,
        [paymentResponseCode] nvarchar(max) NOT NULL,
        [paymentResponseDescription] nvarchar(max) NOT NULL,
        [createdDate] datetime2 NULL,
        [userId] int NOT NULL,
        [approvedDate] datetime2 NOT NULL,
        [approvedBy] int NOT NULL,
        [modifiedDate] datetime2 NOT NULL,
        [modifiedBy] int NOT NULL,
        CONSTRAINT [PK_transactionLogs] PRIMARY KEY ([transId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715163608_additionOfTransactionLog_15072023')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230715163608_additionOfTransactionLog_15072023', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'createdDate');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [transactionLogs] DROP COLUMN [createdDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'modifiedBy');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [users] ALTER COLUMN [modifiedBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'createdBy');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [users] ALTER COLUMN [createdBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'approvedBy');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [users] ALTER COLUMN [approvedBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'walletAccount');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [walletAccount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'transactionType');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [transactionType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'responseMessage');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [responseMessage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'responseCode');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [responseCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'paymentResponseDescription');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [paymentResponseDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'paymentResponseCode');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [paymentResponseCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'paymentDate');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [paymentDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'naration');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [naration] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'modifiedDate');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [modifiedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'modifiedBy');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [modifiedBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'customerId');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [customerId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'approvedDate');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [approvedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'approvedBy');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [approvedBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'ToAcctNo');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [ToAcctNo] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[transactionLogs]') AND [c].[name] = N'FromAcctNo');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [transactionLogs] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [transactionLogs] ALTER COLUMN [FromAcctNo] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'modifiedBy');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [customers] ALTER COLUMN [modifiedBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'createdBy');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [customers] ALTER COLUMN [createdBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'approvedBy');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [customers] ALTER COLUMN [approvedBy] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    CREATE TABLE [auditTrailLogs] (
        [id] int NOT NULL IDENTITY,
        [timestamp] datetime2 NOT NULL,
        [action] nvarchar(max) NOT NULL,
        [log] nvarchar(max) NOT NULL,
        [origin] nvarchar(max) NOT NULL,
        [user] int NOT NULL,
        [extra] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_auditTrailLogs] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230715180235_additionOfauditTrail_15072023')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230715180235_additionOfauditTrail_15072023', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716154320_addIdTypeAndServiceProviders_16072023')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'serviceProvider');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [users] ALTER COLUMN [serviceProvider] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716154320_addIdTypeAndServiceProviders_16072023')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[users]') AND [c].[name] = N'idType');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [users] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [users] ALTER COLUMN [idType] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716154320_addIdTypeAndServiceProviders_16072023')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[customers]') AND [c].[name] = N'idType');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [customers] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [customers] ALTER COLUMN [idType] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716154320_addIdTypeAndServiceProviders_16072023')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230716154320_addIdTypeAndServiceProviders_16072023', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718103525_addSessionTracker18072023')
BEGIN
    CREATE TABLE [sessionTrackers] (
        [Id] int NOT NULL IDENTITY,
        [userId] int NOT NULL,
        [userName] nvarchar(max) NOT NULL,
        [sessionId] nvarchar(max) NOT NULL,
        [createdDate] datetime2 NOT NULL,
        CONSTRAINT [PK_sessionTrackers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718103525_addSessionTracker18072023')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230718103525_addSessionTracker18072023', N'6.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718114825_updateUserTable18072023')
BEGIN
    ALTER TABLE [logins] ADD [IsDefault] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718114825_updateUserTable18072023')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230718114825_updateUserTable18072023', N'6.0.0');
END;
GO

COMMIT;
GO

