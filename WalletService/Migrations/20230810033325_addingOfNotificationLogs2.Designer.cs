﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WalletService.Data;

#nullable disable

namespace WalletService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230810033325_addingOfNotificationLogs2")]
    partial class addingOfNotificationLogs2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WalletService.Models.auditTrailLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("log")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("user")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("auditTrailLogs");
                });

            modelBuilder.Entity("WalletService.Models.balanceInfo", b =>
                {
                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("walletAccount")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("serviceProvider")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("airtimeBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("dataBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telcoWalletAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("userId", "walletAccount", "serviceProvider");

                    b.ToTable("balance");
                });

            modelBuilder.Entity("WalletService.Models.customerInfo", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerId"), 1L, 1);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("approvedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("approvedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idType")
                        .HasColumnType("int");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("paasportPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("walletAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("WalletService.Models.login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLockedOut")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("lastLogOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("lastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("logins");
                });

            modelBuilder.Entity("WalletService.Models.notificationLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotificationType")
                        .HasColumnType("int");

                    b.Property<string>("OTPCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTPReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Validated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ValidatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("createdFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("messages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("notificationLogs");
                });

            modelBuilder.Entity("WalletService.Models.otpContainer", b =>
                {
                    b.Property<int>("otpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("otpId"), 1L, 1);

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("expiryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isValidated")
                        .HasColumnType("bit");

                    b.Property<string>("otp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("otpId");

                    b.ToTable("otpContainers");
                });

            modelBuilder.Entity("WalletService.Models.serviceLogin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tokenLogins");
                });

            modelBuilder.Entity("WalletService.Models.sessionTracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("sessionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sessionTrackers");
                });

            modelBuilder.Entity("WalletService.Models.transactionLog", b =>
                {
                    b.Property<string>("transId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromAcctNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAcctNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("amount")
                        .IsRequired()
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("approvedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("approvedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("balanceAfterTransaction")
                        .IsRequired()
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("balanceBeforeTransaction")
                        .IsRequired()
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<int?>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("naration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("paymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("paymentResponseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentResponseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("referenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requestid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("responseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("responseMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("transactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("transactionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<string>("walletAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("transId");

                    b.ToTable("transactionLogs");
                });

            modelBuilder.Entity("WalletService.Models.userInfo", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SuperSimToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("approvedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("approvedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("bankAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("businessAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("businessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idType")
                        .HasColumnType("int");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("modifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("passportPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.Property<int?>("serviceProvider")
                        .HasColumnType("int");

                    b.Property<string>("superSimEmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("superSimPhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("walletAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WalletService.Models.userRole", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"), 1L, 1);

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isUser")
                        .HasColumnType("bit");

                    b.Property<string>("roleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("userRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
