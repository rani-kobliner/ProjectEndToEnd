using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.models;

public partial class dbClass : DbContext
{
    public dbClass()
    {
    }

    public dbClass(DbContextOptions<dbClass> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeRange> AgeRanges { get; set; }

    public virtual DbSet<Optometrist> Optometrists { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientsAppointment> PatientsAppointments { get; set; }

    public virtual DbSet<QueueList> QueueLists { get; set; }

    public virtual DbSet<RegisteredPatient> RegisteredPatients { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='H:\\פרויקט מקצה לקצה\\ProjectEndToEnd\\Dal\\Data\\DataBase.mdf';Integrated Security=True;Connect Timeout=30");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
        string dbPath = Path.Combine(solutionRoot, @"DAL\Models\Data\DataBase.mdf");

        optionsBuilder.UseSqlServer(
            $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeRange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgeRange__3214EC075D357644");

            entity.ToTable("AgeRange");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age)
                .HasMaxLength(6)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("age");
        });

        modelBuilder.Entity<Optometrist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07F1189D6B");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.SpecializationByAgeNavigation).WithMany(p => p.Optometrists)
                .HasForeignKey(d => d.SpecializationByAge)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Optometrists_ToTable");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC0765D4C38B");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Hmo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("HMO");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<PatientsAppointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patients__3214EC07891AC471");

            entity.ToTable("Patients_Appointment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OptometristCode)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PatientCode)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.OptometristCodeNavigation).WithMany(p => p.PatientsAppointments)
                .HasForeignKey(d => d.OptometristCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Appointment_ToTable_1");

            entity.HasOne(d => d.PatientCodeNavigation).WithMany(p => p.PatientsAppointments)
                .HasForeignKey(d => d.PatientCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patients_Appointment_ToTable");
        });

        modelBuilder.Entity<QueueList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Queue_Li__3214EC0726B35CDF");

            entity.ToTable("Queue_List");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OptometrisId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("OptometrisID");

            entity.HasOne(d => d.Optometris).WithMany(p => p.QueueLists)
                .HasForeignKey(d => d.OptometrisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Queue_List_ToTable");
        });

        modelBuilder.Entity<RegisteredPatient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Register__3214EC076D4CB16E");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
