using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZZDatsTest.Models;

public partial class ZzdatstestdbContext : DbContext
{
    public ZzdatstestdbContext()
    {
    }

    public ZzdatstestdbContext(DbContextOptions<ZzdatstestdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contaminant> Contaminants { get; set; }

    public virtual DbSet<MetalsInSpecy> MetalsInSpecies { get; set; }

    public virtual DbSet<ParametersInYear> ParametersInYears { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contaminant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contaminants_pkey");

            entity.ToTable("contaminants");

            entity.HasIndex(e => e.Parameter, "contaminants_parameter_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bottdepthm)
                .HasComment("Paraugu ņemšanas stacijas dziļums metros, mērot no ūdens virsmas līdz ūdenstilpes dibenam")
                .HasColumnName("bottdepthm");
            entity.Property(e => e.Datetime)
                .HasComment("Paraugu vākšanas datums un laiks")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Individuals)
                .HasComment("Vienā paraugā apvienots attiecīgās sugas īpatņu skaits")
                .HasColumnName("individuals");
            entity.Property(e => e.Latitude)
                .HasComment("Ģeogrāfiskā Ziemeļu platuma grādu decimālskaitlis, WGS84 sistēmā")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasComment("Ģeogrāfiskā Austrumu garuma grādu decimālskaitlis, WGS84 sistēmā")
                .HasColumnName("longitude");
            entity.Property(e => e.Parameter)
                .HasMaxLength(255)
                .HasComment("Paraugam(-ā) noteiktie parametri (zivju vidējais garums, masa, vecums, ūdens saturs audos, metālu saturs audos)")
                .HasColumnName("parameter");
            entity.Property(e => e.ParameterLv)
                .HasMaxLength(255)
                .HasComment("Parametra latviskais atšifirējums")
                .HasColumnName("parameter_lv");
            entity.Property(e => e.Quality)
                .HasComment("Attiecīgās mērījuma vērtības kvalitātes karogs, kas norāda - vai dati ir caurskatīti un pārbaudīti. Atbilstoši SeaDataNet konsorcija kritērijiem")
                .HasColumnName("quality");
            entity.Property(e => e.Sampleid)
                .HasMaxLength(255)
                .HasComment("Unikāls parauga identifikācijas numurs, uz kuru attiecas konkrētā mērījuma vērtība")
                .HasColumnName("sampleid");
            entity.Property(e => e.Species)
                .HasMaxLength(255)
                .HasComment("Attiecīgā zivju suga - Asaris (Perca fluviatilis), Reņģe (Clupea harengus membras)")
                .HasColumnName("species");
            entity.Property(e => e.SpeciesLv)
                .HasMaxLength(255)
                .HasComment("Zivju sugu latviskais nosaukums")
                .HasColumnName("species_lv");
            entity.Property(e => e.Station)
                .HasMaxLength(255)
                .HasComment("Unikāls stacijas kods un/vai nosaukums")
                .HasColumnName("station");
            entity.Property(e => e.Tissue)
                .HasMaxLength(255)
                .HasComment("Audi, kuriem(-os) noteikts attiecīgais parametrs - viss (nepreparēts) organisms, akna, muskulis (fileja)")
                .HasColumnName("tissue");
            entity.Property(e => e.Trip)
                .HasMaxLength(255)
                .HasComment("Universāls paraugu ņemšanas kampaņas kods")
                .HasColumnName("trip");
            entity.Property(e => e.Units)
                .HasMaxLength(255)
                .HasComment("Parametra vērtības mērvienība, DW - vērtība rēķināta uz sausa parauga masu (izžāvētam paraugam); WW - vērtība rēķināta uz mitra parauga masu (nežāvētam paraugam)")
                .HasColumnName("units");
            entity.Property(e => e.Value)
                .HasComment("Parauga testēšanā iegūtā parametra vērtība")
                .HasColumnName("value");
        });

        modelBuilder.Entity<MetalsInSpecy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("metals_in_species");

            entity.Property(e => e.Individuals).HasColumnName("individuals");
            entity.Property(e => e.ParameterLv)
                .HasMaxLength(255)
                .HasColumnName("parameter_lv");
            entity.Property(e => e.SpeciesLv)
                .HasMaxLength(255)
                .HasColumnName("species_lv");
            entity.Property(e => e.Units)
                .HasMaxLength(255)
                .HasColumnName("units");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<ParametersInYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("parameters_in_years");

            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.ParameterLv)
                .HasMaxLength(255)
                .HasColumnName("parameter_lv");
            entity.Property(e => e.Units)
                .HasMaxLength(255)
                .HasColumnName("units");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
