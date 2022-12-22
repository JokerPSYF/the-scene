﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheScene.Infrastructure.Data;

#nullable disable

namespace TheScene.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221222121946_geolocation")]
    partial class geolocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b97379a1-4a4b-4cdb-b57f-edf338d73730",
                            ConcurrencyStamp = "549fc033-7a1d-4f62-a213-987cf3fccd42",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "7a15400e-4991-4d66-87df-05a82c3bf851",
                            RoleId = "b97379a1-4a4b-4cdb-b57f-edf338d73730"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FreeSeats")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPremiere")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("OccupiedSeats")
                        .HasColumnType("int");

                    b.Property<int>("PerfomanceId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerTicket")
                        .HasPrecision(18, 2)
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PerfomanceId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsPremiere = false,
                            LocationId = 6,
                            OccupiedSeats = 0,
                            PerfomanceId = 1,
                            PricePerTicket = 12m
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2022, 11, 24, 22, 30, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsPremiere = false,
                            LocationId = 5,
                            OccupiedSeats = 0,
                            PerfomanceId = 2,
                            PricePerTicket = 14m
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2022, 11, 22, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsPremiere = false,
                            LocationId = 7,
                            OccupiedSeats = 0,
                            PerfomanceId = 3,
                            PricePerTicket = 12m
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2022, 12, 23, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsPremiere = false,
                            LocationId = 7,
                            OccupiedSeats = 0,
                            PerfomanceId = 4,
                            PricePerTicket = 25m
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2022, 12, 18, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsPremiere = false,
                            LocationId = 4,
                            OccupiedSeats = 0,
                            PerfomanceId = 5,
                            PricePerTicket = 40m
                        });
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Western"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Pop music"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Hip hop music"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Rock music"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Folk music"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Pop Folk music"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Jazz music"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Electronic music"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Classical music"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Christian music"
                        });
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlaceTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceTypeId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "pl. \"Troykata\" 1, 8000 Burgas Center, Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d505.2189479926242!2d27.46955384608908!3d42.498052194717765!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694be410c32c9%3A0x1887194803bffd9f!2z0JrRg9C70YLRg9GA0LXQvSDQtNC-0Lwg0J3QpdCa!5e0!3m2!1sen!2sbg!4v1671710527425!5m2!1sen!2sbg",
                            Name = "Културен дом НХК",
                            PlaceTypeId = 2,
                            Seats = 400
                        },
                        new
                        {
                            Id = 2,
                            Address = "48 улица „Христо Ботев“, 8000 Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1485726.0365802157!2d25.608665091216206!3d43.33919270804973!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694bee7bc0013%3A0x64d7652ab70a143!2sMilitary%20Hotel!5e0!3m2!1sen!2sbg!4v1671710657625!5m2!1sen!2sbg",
                            Name = "Military Hotel",
                            PlaceTypeId = 2,
                            Seats = 300
                        },
                        new
                        {
                            Id = 3,
                            Address = "ul. \"Tsar Asen I\" 28, вх.А, 8000 Wasraschdane, Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.9731228793357!2d27.46557931575126!3d42.49212403474332!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694b87b8e8175%3A0x162a847dd72fc4be!2sDrama%20Theatre%20Adriana%20Budevska!5e0!3m2!1sen!2sbg!4v1671711023393!5m2!1sen!2sbg",
                            Name = "Drama Theatre Adriana Budevska",
                            PlaceTypeId = 2,
                            Seats = 320
                        },
                        new
                        {
                            Id = 4,
                            Address = "Demokratsia Blvd 94, 8001 Burgas Center, Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.767603047012!2d27.473731165751342!3d42.49649308446668!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694ea2b320899%3A0xd212510bf1f13ad2!2sOpen-air%20theater!5e0!3m2!1sen!2sbg!4v1671711176033!5m2!1sen!2sbg",
                            Name = "Open-air theater",
                            PlaceTypeId = 3,
                            Seats = 1970
                        },
                        new
                        {
                            Id = 5,
                            Address = "Mall Galleria, Blvd. \"Dame Gruev\" 6, 8005 Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.0000352977227!2d27.452702515751575!3d42.51280723343363!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a693634968f40b%3A0x33fae8c02fef63e6!2sCinema%20City!5e0!3m2!1sen!2sbg!4v1671711225819!5m2!1sen!2sbg",
                            Name = "Cinema City",
                            PlaceTypeId = 1,
                            Seats = 153
                        },
                        new
                        {
                            Id = 6,
                            Address = "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23527.987394558437!2d27.43738163133954!3d42.51284146838338!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a69536d031a19f%3A0xee7a2bf8742be5d!2z0JTRitGA0LbQsNCy0LXQvSDQutGD0LrQu9C10L0g0YLQtdCw0YLRitGA!5e0!3m2!1sen!2sbg!4v1671711273085!5m2!1sen!2sbg",
                            Name = "Държавен куклен театър",
                            PlaceTypeId = 2,
                            Seats = 200
                        },
                        new
                        {
                            Id = 7,
                            Address = "ul. \"Sveti Kliment Ohridski\" 2, 8000 g.k. Vazrazhdane, Burgas",
                            IsActive = true,
                            Link = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2941.8628304682!2d27.4671644157514!3d42.494468734594896!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40a694b8b420f267%3A0x2bed66575402c90b!2sThe%20Opera%20House!5e0!3m2!1sen!2sbg!4v1671711341381!5m2!1sen!2sbg",
                            Name = "The Opera House",
                            PlaceTypeId = 2,
                            Seats = 300
                        });
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Perfomance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Actors")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Director")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PerfomanceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("PerfomanceTypeId");

                    b.ToTable("Perfomances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Actors = "Стефан Василев, Таня Памукчиева",
                            Description = "„Талантино“ предупреждава: Страстта може да бъде много опасна!\r\nПсихопат – сериен убиец и жертва – психолог, разказват една история. История, в която истината и лъжата са винаги на тънка и опасна граница. В търсенето на причината, която ги е довела до тази екстремна ситуация, ролята на палач преминава от ръка на ръка и това, което изглежда като предсказуем край, търпи обрат след обрат. Трябва ли да превърнем живота си в една трагична история, за да го разберем? Ще получи ли психопата желаната си терапия или ще вземе поредната си жертва?",
                            Director = "Станимир Карагьозов",
                            GenreId = 8,
                            ImageURL = "https://scontent-sof1-2.xx.fbcdn.net/v/t39.30808-6/312262525_523539703113345_5372908178241038288_n.jpg?stp=dst-jpg_s960x960&_nc_cat=110&ccb=1-7&_nc_sid=340051&_nc_ohc=sqvojeCwuhUAX-sD6f5&_nc_ht=scontent-sof1-2.xx&oh=00_AfD9_3plCjvaqT6IiWveG_8HOaVI37UEvZJ8PuuE4Hw3Bg&oe=637B30E4",
                            IsActive = true,
                            PerfomanceTypeId = 2,
                            Title = "Верига от думи"
                        },
                        new
                        {
                            Id = 2,
                            Actors = "Sosie Bacon, Jessie T. Usher, Kyle Gallner",
                            Description = "After witnessing a bizarre, traumatic incident involving a patient, Dr. Rose Cotter starts experiencing frightening occurrences that she can't explain. Rose must confront her troubling past in order to survive and escape her horrifying new reality.",
                            Director = "Parker Finn",
                            GenreId = 5,
                            ImageURL = "https://www.cinemacity.bg/xmedia-cw/repo/feats/posters/5170S2R-lg.jpg",
                            IsActive = true,
                            PerfomanceTypeId = 1,
                            Title = "Smile",
                            Year = 2022
                        },
                        new
                        {
                            Id = 3,
                            Actors = "Йоана Кадийска, Яни Николов, Йордан Христозов",
                            Description = "Оригинални декори пренасят присъстващите в най-големия храм на древна Елада и в покоите на Елена. Изрисуваните по тях известни случки от ловни и любовни сцени използват техниката на гръцкия вазопис.",
                            Director = "Александър Текелиев",
                            GenreId = 2,
                            ImageURL = "https://www.programata.bg/img/gallery/event_50529.jpg?997794843",
                            IsActive = true,
                            PerfomanceTypeId = 2,
                            Title = "La belle Hellene"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Едно неочаквано претворяване на познатия сюжет от новелата Кармен на Мериме и любимата музика от едноименната опера на Бизе. Спектакъл за неустоимата страст на Кармен, търсеща всепоглъщаща любов или просто хладна любовна игра на живот и смърт.",
                            Director = "Боряна Сечанова",
                            GenreId = 7,
                            ImageURL = "https://www.programata.bg/img/gallery/event_107123.jpg?1331961416",
                            IsActive = true,
                            PerfomanceTypeId = 4,
                            Title = "Колекция Кармен"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Самюел Андре Мадсън израства в религиозно семейство в провинция в Дания и се учи да свири на бас и барабани в църквата там, а сега е един от най-успешните диджеи и лейбъл мениджъри.",
                            GenreId = 16,
                            ImageURL = "https://www.programata.bg/img/gallery/event_107182.jpg?630607749",
                            IsActive = true,
                            PerfomanceTypeId = 5,
                            Title = "Ritual Gatherings present S.A.M."
                        });
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.PerfomanceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PerfomanceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Movie"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Theatrical play"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Opera"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ballet"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Concert"
                        });
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.PlaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PlaceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cinema"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Theater"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Open air theater"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Stadium"
                        });
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("The first name of the user");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("The first name of the user");

                    b.HasDiscriminator().HasValue("AppUser");

                    b.HasData(
                        new
                        {
                            Id = "7a15400e-4991-4d66-87df-05a82c3bf851",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a44a3088-9e7b-491d-8ffc-04387a929072",
                            Email = "teo@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEO@MAIL.COM",
                            NormalizedUserName = "TEO",
                            PasswordHash = "AQAAAAEAACcQAAAAEOUwVsSmGxUkuxOhbQ2a1zO4eVs3Utc5ETRlV+4RvInpgYNvKOdhPdSCDYU7vTr3Hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "84fc3742-966b-4bc1-ab01-cf62dc73dc26",
                            TwoFactorEnabled = false,
                            UserName = "Teo",
                            FirstName = "Todor",
                            IsActive = true,
                            LastName = "Vasilev"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Event", b =>
                {
                    b.HasOne("TheScene.Infrastructure.Data.Entities.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheScene.Infrastructure.Data.Entities.Perfomance", "Perfomance")
                        .WithMany("Events")
                        .HasForeignKey("PerfomanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Perfomance");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Location", b =>
                {
                    b.HasOne("TheScene.Infrastructure.Data.Entities.PlaceType", "PlaceType")
                        .WithMany("Locations")
                        .HasForeignKey("PlaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceType");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Perfomance", b =>
                {
                    b.HasOne("TheScene.Infrastructure.Data.Entities.Genre", "Genre")
                        .WithMany("Perfomances")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheScene.Infrastructure.Data.Entities.PerfomanceType", "PerfomanceType")
                        .WithMany("Perfomances")
                        .HasForeignKey("PerfomanceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("PerfomanceType");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Genre", b =>
                {
                    b.Navigation("Perfomances");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Location", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.Perfomance", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.PerfomanceType", b =>
                {
                    b.Navigation("Perfomances");
                });

            modelBuilder.Entity("TheScene.Infrastructure.Data.Entities.PlaceType", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
