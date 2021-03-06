﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS_Sender.DATA.Data;

namespace SMS_Sender.DATA.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20200317064605_AddedSentMessagesTableToDatabase")]
    partial class AddedSentMessagesTableToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SMS_Sender.DATA.Models.Recipients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MobileNumber");

                    b.Property<string>("NameAndSurname");

                    b.HasKey("Id");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("SMS_Sender.DATA.Models.SentMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAndTime");

                    b.Property<string>("FileName");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Recipient");

                    b.HasKey("Id");

                    b.ToTable("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
