﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSConstruct.DBClasses;

#nullable disable

namespace PSConstruct.Data.Migrations
{
    [DbContext(typeof(ConfigContext))]
    partial class ConfigContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("PSConstruct.DBClasses.BDMotherBoard", b =>
                {
                    b.Property<int>("BDMotherBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountRAM")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MDName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RAMsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BDMotherBoardId");

                    b.HasIndex("ConfigId");

                    b.ToTable("BDMotherBoards");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.Config", b =>
                {
                    b.Property<int>("ConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConfigName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ConfigId");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBCPU", b =>
                {
                    b.Property<int>("DBCPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPUName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoreCount")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CoreHz")
                        .HasColumnType("REAL");

                    b.Property<bool>("GraphicsCore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerEat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StreamsCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBCPUId");

                    b.HasIndex("ConfigId");

                    b.ToTable("DBCPUs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBGPU", b =>
                {
                    b.Property<int>("DBGPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GPUMemoryCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GPUName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GPUsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PowerEat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("bandwidth")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBGPUId");

                    b.HasIndex("ConfigId");

                    b.ToTable("DBGPUs");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBHDD", b =>
                {
                    b.Property<int>("DBHDDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HDDMemoryCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HDDName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HDDPowerEat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemorySpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBHDDId");

                    b.HasIndex("ConfigId");

                    b.ToTable("DBHDD");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBPowerUnit", b =>
                {
                    b.Property<int>("DBPowerUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PowerUnitName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DBPowerUnitId");

                    b.HasIndex("ConfigId");

                    b.ToTable("DBPowerUnit");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBRAM", b =>
                {
                    b.Property<int>("DBRAMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RAMName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RAMsocket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RamMemoryCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RamMemorySpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("DBRAMId");

                    b.HasIndex("ConfigId");

                    b.ToTable("DBRAM");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.BDMotherBoard", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.Config", null)
                        .WithMany("BDMotherBoards")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBCPU", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.Config", null)
                        .WithMany("DBCPUs")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBGPU", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.Config", null)
                        .WithMany("DBGPUs")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBHDD", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.Config", null)
                        .WithMany("DBHDDs")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBPowerUnit", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.Config", null)
                        .WithMany("DBPowerUnits")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.DBRAM", b =>
                {
                    b.HasOne("PSConstruct.DBClasses.Config", null)
                        .WithMany("DBRAMs")
                        .HasForeignKey("ConfigId");
                });

            modelBuilder.Entity("PSConstruct.DBClasses.Config", b =>
                {
                    b.Navigation("BDMotherBoards");

                    b.Navigation("DBCPUs");

                    b.Navigation("DBGPUs");

                    b.Navigation("DBHDDs");

                    b.Navigation("DBPowerUnits");

                    b.Navigation("DBRAMs");
                });
#pragma warning restore 612, 618
        }
    }
}
