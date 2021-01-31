﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Net;
using AuthServer.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AuthServer.Server.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20210131130100_AddUserDisabledFlagToDatabase")]
    partial class AddUserDisabledFlagToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("hstore")
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AppUserUserGroup", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MembersId")
                        .HasColumnType("uuid");

                    b.HasKey("GroupsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("AppUserUserGroup");
                });

            modelBuilder.Entity("AuthAppUserGroup", b =>
                {
                    b.Property<Guid>("AuthAppsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserGroupsId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthAppsId", "UserGroupsId");

                    b.HasIndex("UserGroupsId");

                    b.ToTable("AuthAppUserGroup");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AuthMethod")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DirectoryMethod")
                        .HasColumnType("integer");

                    b.Property<int>("HostingType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AuthApp");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreationTime")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("DeviceCookieId")
                        .HasColumnType("uuid");

                    b.Property<DeviceInformation>("DeviceInfo")
                        .HasColumnType("jsonb");

                    b.Property<Instant?>("ExpiredTime")
                        .HasColumnType("timestamp");

                    b.Property<Instant>("LastUsedTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("UserAgent")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DeviceCookieId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthSessions");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthSessionIp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthSessionId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<IPAddress>("IpAddress")
                        .IsRequired()
                        .HasColumnType("inet");

                    b.HasKey("Id");

                    b.HasIndex("AuthSessionId");

                    b.HasIndex("IpAddress");

                    b.ToTable("AuthSessionIps");
                });

            modelBuilder.Entity("AuthServer.Server.Models.DeviceCookie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("DeviceCookies");
                });

            modelBuilder.Entity("AuthServer.Server.Models.InvalidLoginAttempt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("AttemptTime")
                        .HasColumnType("timestamp");

                    b.Property<IPAddress>("IpAddress")
                        .IsRequired()
                        .HasColumnType("inet");

                    b.Property<Guid?>("TargetUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TargetUserId");

                    b.ToTable("InvalidLoginAttempts");
                });

            modelBuilder.Entity("AuthServer.Server.Models.InvalidTwoFactorAttempt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("AttemptTime")
                        .HasColumnType("timestamp");

                    b.Property<IPAddress>("IPAddress")
                        .IsRequired()
                        .HasColumnType("inet");

                    b.Property<Guid>("TargetUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TargetUserId");

                    b.ToTable("InvalidTwoFactorAttempts");
                });

            modelBuilder.Entity("AuthServer.Server.Models.LdapAppSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthAppId")
                        .HasColumnType("uuid");

                    b.Property<string>("BaseDn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BindUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BindUserPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("UseForAuthentication")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseForIdentity")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AuthAppId")
                        .IsUnique();

                    b.ToTable("LdapAppSettings");
                });

            modelBuilder.Entity("AuthServer.Server.Models.LdapAppUserCredentials", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LdapAppSettingsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LdapAppSettingsId");

                    b.HasIndex("UserId");

                    b.ToTable("LdapAppUserCredentials");
                });

            modelBuilder.Entity("AuthServer.Server.Models.OIDCAppSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Audience")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("AuthAppId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RedirectUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthAppId")
                        .IsUnique();

                    b.ToTable("OIDCAppSettings");
                });

            modelBuilder.Entity("AuthServer.Server.Models.OIDCSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreationTime")
                        .HasColumnType("timestamp");

                    b.Property<Instant?>("ExpiredTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("Nonce")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OIDCAppSettingsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OIDCAppSettingsId");

                    b.HasIndex("UserId");

                    b.ToTable("OIDCSessions");
                });

            modelBuilder.Entity("AuthServer.Server.Models.ProxyAppSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthAppId")
                        .HasColumnType("uuid");

                    b.Property<List<string>>("EndpointsWithoutAuth")
                        .HasColumnType("text[]");

                    b.Property<string>("InternalHostname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PublicHostname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthAppId")
                        .IsUnique();

                    b.ToTable("ProxyAppSettings");
                });

            modelBuilder.Entity("AuthServer.Server.Models.SCIMAppSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthAppId")
                        .HasColumnType("uuid");

                    b.Property<string>("Credentials")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthAppId")
                        .IsUnique();

                    b.ToTable("SCIMAppSettings");
                });

            modelBuilder.Entity("AuthServer.Server.Models.ScimGroupSyncState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("SCIMAppSettingsId")
                        .HasColumnType("uuid");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserGroupId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SCIMAppSettingsId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("ScimGroupSyncStates");
                });

            modelBuilder.Entity("AuthServer.Server.Models.ScimUserSyncState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("SCIMAppSettingsId")
                        .HasColumnType("uuid");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SCIMAppSettingsId");

                    b.HasIndex("UserId");

                    b.ToTable("ScimUserSyncStates");
                });

            modelBuilder.Entity("AuthServer.Server.Models.SystemSecurityAlert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AlertType")
                        .HasColumnType("integer");

                    b.Property<Dictionary<string, string>>("KeyValueStore")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.HasKey("Id");

                    b.ToTable("SystemSecurityAlerts");
                });

            modelBuilder.Entity("AuthServer.Server.Models.SystemSetting", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("AuthServer.Server.Models.UserGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("AuthServer.Server.Models.UserSecurityAlert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AlertType")
                        .HasColumnType("integer");

                    b.Property<Dictionary<string, string>>("KeyValueStore")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<Guid?>("RecipientId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("UserSecurityAlerts");
                });

            modelBuilder.Entity("AuthServer.Server.Models.UserTotpDevice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("CreationTime")
                        .HasColumnType("timestamp");

                    b.Property<Instant>("LastUsedTime")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SharedSecret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTotpDevices");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AppUserUserGroup", b =>
                {
                    b.HasOne("AuthServer.Server.Models.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthAppUserGroup", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AuthApp", null)
                        .WithMany()
                        .HasForeignKey("AuthAppsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.UserGroup", null)
                        .WithMany()
                        .HasForeignKey("UserGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthSession", b =>
                {
                    b.HasOne("AuthServer.Server.Models.DeviceCookie", "DeviceCookie")
                        .WithMany("AuthSessions")
                        .HasForeignKey("DeviceCookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.AppUser", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceCookie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthSessionIp", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AuthSession", "AuthSession")
                        .WithMany("SessionIps")
                        .HasForeignKey("AuthSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthSession");
                });

            modelBuilder.Entity("AuthServer.Server.Models.InvalidLoginAttempt", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", "TargetUser")
                        .WithMany("InvalidLoginAttempts")
                        .HasForeignKey("TargetUserId");

                    b.Navigation("TargetUser");
                });

            modelBuilder.Entity("AuthServer.Server.Models.InvalidTwoFactorAttempt", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", "TargetUser")
                        .WithMany("InvalidTwoFactorAttempts")
                        .HasForeignKey("TargetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetUser");
                });

            modelBuilder.Entity("AuthServer.Server.Models.LdapAppSettings", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AuthApp", "AuthApp")
                        .WithOne("LdapAppSettings")
                        .HasForeignKey("AuthServer.Server.Models.LdapAppSettings", "AuthAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthApp");
                });

            modelBuilder.Entity("AuthServer.Server.Models.LdapAppUserCredentials", b =>
                {
                    b.HasOne("AuthServer.Server.Models.LdapAppSettings", "LdapAppSettings")
                        .WithMany("LdapAppUserCredentials")
                        .HasForeignKey("LdapAppSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("LdapAppSettings");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthServer.Server.Models.OIDCAppSettings", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AuthApp", "AuthApp")
                        .WithOne("OidcAppSettings")
                        .HasForeignKey("AuthServer.Server.Models.OIDCAppSettings", "AuthAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthApp");
                });

            modelBuilder.Entity("AuthServer.Server.Models.OIDCSession", b =>
                {
                    b.HasOne("AuthServer.Server.Models.OIDCAppSettings", "OIDCAppSettings")
                        .WithMany("OIDCSessions")
                        .HasForeignKey("OIDCAppSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("OIDCAppSettings");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthServer.Server.Models.ProxyAppSettings", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AuthApp", "AuthApp")
                        .WithOne("ProxyAppSettings")
                        .HasForeignKey("AuthServer.Server.Models.ProxyAppSettings", "AuthAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthApp");
                });

            modelBuilder.Entity("AuthServer.Server.Models.SCIMAppSettings", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AuthApp", "AuthApp")
                        .WithOne("ScimAppSettings")
                        .HasForeignKey("AuthServer.Server.Models.SCIMAppSettings", "AuthAppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthApp");
                });

            modelBuilder.Entity("AuthServer.Server.Models.ScimGroupSyncState", b =>
                {
                    b.HasOne("AuthServer.Server.Models.SCIMAppSettings", "SCIMAppSettings")
                        .WithMany("ScimGroupSyncStates")
                        .HasForeignKey("SCIMAppSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.UserGroup", "UserGroup")
                        .WithMany("ScimGroupSyncState")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SCIMAppSettings");

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("AuthServer.Server.Models.ScimUserSyncState", b =>
                {
                    b.HasOne("AuthServer.Server.Models.SCIMAppSettings", "SCIMAppSettings")
                        .WithMany("ScimUserSyncStates")
                        .HasForeignKey("SCIMAppSettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.AppUser", "User")
                        .WithMany("ScimUserSyncState")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SCIMAppSettings");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthServer.Server.Models.UserSecurityAlert", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("AuthServer.Server.Models.UserTotpDevice", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", "User")
                        .WithMany("TotpDevices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthServer.Server.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("AuthServer.Server.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthServer.Server.Models.AppUser", b =>
                {
                    b.Navigation("InvalidLoginAttempts");

                    b.Navigation("InvalidTwoFactorAttempts");

                    b.Navigation("ScimUserSyncState");

                    b.Navigation("Sessions");

                    b.Navigation("TotpDevices");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthApp", b =>
                {
                    b.Navigation("LdapAppSettings");

                    b.Navigation("OidcAppSettings");

                    b.Navigation("ProxyAppSettings");

                    b.Navigation("ScimAppSettings");
                });

            modelBuilder.Entity("AuthServer.Server.Models.AuthSession", b =>
                {
                    b.Navigation("SessionIps");
                });

            modelBuilder.Entity("AuthServer.Server.Models.DeviceCookie", b =>
                {
                    b.Navigation("AuthSessions");
                });

            modelBuilder.Entity("AuthServer.Server.Models.LdapAppSettings", b =>
                {
                    b.Navigation("LdapAppUserCredentials");
                });

            modelBuilder.Entity("AuthServer.Server.Models.OIDCAppSettings", b =>
                {
                    b.Navigation("OIDCSessions");
                });

            modelBuilder.Entity("AuthServer.Server.Models.SCIMAppSettings", b =>
                {
                    b.Navigation("ScimGroupSyncStates");

                    b.Navigation("ScimUserSyncStates");
                });

            modelBuilder.Entity("AuthServer.Server.Models.UserGroup", b =>
                {
                    b.Navigation("ScimGroupSyncState");
                });
#pragma warning restore 612, 618
        }
    }
}
