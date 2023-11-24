using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Animal_Status;

public partial class AnimalServiceContext : DbContext
{
    public AnimalServiceContext()
    {
    }

    public AnimalServiceContext(DbContextOptions<AnimalServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnimalType> AnimalTypes { get; set; }

    public virtual DbSet<Behavior> Behaviors { get; set; }

    public virtual DbSet<Diet> Diets { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetVaccination> PetVaccinations { get; set; }

    public virtual DbSet<PetVeterinaryRecord> PetVeterinaryRecords { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SleepAndRest> SleepAndRests { get; set; }

    public virtual DbSet<StressLevel> StressLevels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    public virtual DbSet<VeterinaryRecord> VeterinaryRecords { get; set; }

    public virtual DbSet<WeightAndHeight> WeightAndHeights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CLOAKER\\SQLEXPRESS;Initial Catalog=AnimalService;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimalType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__AnimalTy__516F03951FC7C431");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Behavior>(entity =>
        {
            entity.HasKey(e => e.BehaviorId).HasName("PK__Behavior__361B21879A941F19");

            entity.ToTable("Behavior");

            entity.Property(e => e.BehaviorId).HasColumnName("BehaviorID");
            entity.Property(e => e.BehaviorDate).HasColumnType("date");
            entity.Property(e => e.PetId).HasColumnName("PetID");

            entity.HasOne(d => d.Pet).WithMany(p => p.Behaviors)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Behavior__PetID__59FA5E80");
        });

        modelBuilder.Entity<Diet>(entity =>
        {
            entity.HasKey(e => e.DietId).HasName("PK__Diet__AB42F6BEA197BB61");

            entity.ToTable("Diet");

            entity.Property(e => e.DietId).HasColumnName("DietID");
            entity.Property(e => e.DietDate).HasColumnType("date");
            entity.Property(e => e.PetId).HasColumnName("PetID");

            entity.HasOne(d => d.Pet).WithMany(p => p.Diets)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diet__PetID__4E88ABD4");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__Exercise__A074AD0FA243D314");

            entity.ToTable("Exercise", tb => tb.HasTrigger("AddWeightAndHeightOnExercise"));

            entity.Property(e => e.ExerciseId).HasColumnName("ExerciseID");
            entity.Property(e => e.ActivityDate).HasColumnType("date");
            entity.Property(e => e.PetId).HasColumnName("PetID");

            entity.HasOne(d => d.Pet).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exercise__PetID__5165187F");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PK__Notes__EACE357F2A137B2C");

            entity.Property(e => e.NoteId).HasColumnName("NoteID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Pet).WithMany(p => p.Notes)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notes__PetID__5CD6CB2B");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pets__48E53802709A5390");

            entity.ToTable(tb => tb.HasTrigger("InsertPetDiet"));

            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.Picture).HasMaxLength(150);
            entity.Property(e => e.Species).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Owner).WithMany(p => p.Pets)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pets__OwnerID__3C69FB99");

            entity.HasOne(d => d.Type).WithMany(p => p.Pets)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Pets__TypeID__5FB337D6");
        });

        modelBuilder.Entity<PetVaccination>(entity =>
        {
            entity.HasKey(e => e.PetVaccinationId).HasName("PK__PetVacci__32C7BD63FBF41DD3");

            entity.Property(e => e.PetVaccinationId).HasColumnName("PetVaccinationID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.VaccinationId).HasColumnName("VaccinationID");

            entity.HasOne(d => d.Pet).WithMany(p => p.PetVaccinations)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetVaccin__PetID__412EB0B6");

            entity.HasOne(d => d.Vaccination).WithMany(p => p.PetVaccinations)
                .HasForeignKey(d => d.VaccinationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetVaccin__Vacci__4222D4EF");
        });

        modelBuilder.Entity<PetVeterinaryRecord>(entity =>
        {
            entity.HasKey(e => e.PetVeterinaryRecordId).HasName("PK__PetVeter__E28867F7ACEDEA68");

            entity.Property(e => e.PetVeterinaryRecordId).HasColumnName("PetVeterinaryRecordID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.RecordId).HasColumnName("RecordID");

            entity.HasOne(d => d.Pet).WithMany(p => p.PetVeterinaryRecords)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetVeteri__PetID__47DBAE45");

            entity.HasOne(d => d.Record).WithMany(p => p.PetVeterinaryRecords)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetVeteri__Recor__48CFD27E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3ADBE2822C");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<SleepAndRest>(entity =>
        {
            entity.HasKey(e => e.SleepAndRestId).HasName("PK__SleepAnd__18363BDDF1BED610");

            entity.ToTable("SleepAndRest");

            entity.Property(e => e.SleepAndRestId).HasColumnName("SleepAndRestID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.RestDate).HasColumnType("date");

            entity.HasOne(d => d.Pet).WithMany(p => p.SleepAndRests)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SleepAndR__PetID__571DF1D5");
        });

        modelBuilder.Entity<StressLevel>(entity =>
        {
            entity.HasKey(e => e.StressLevelId).HasName("PK__StressLe__1F4494E8819AB58A");

            entity.ToTable("StressLevel");

            entity.Property(e => e.StressLevelId).HasColumnName("StressLevelID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.StressDate).HasColumnType("date");

            entity.HasOne(d => d.Pet).WithMany(p => p.StressLevels)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StressLev__PetID__5441852A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACFA98BFCD");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__398D8EEE");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.HasKey(e => e.VaccinationId).HasName("PK__Vaccinat__466BCFA74BE07351");

            entity.Property(e => e.VaccinationId).HasColumnName("VaccinationID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.VaccinationDate).HasColumnType("date");
        });

        modelBuilder.Entity<VeterinaryRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__Veterina__FBDF78C9E6215BE7");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.Veterinarian).HasMaxLength(255);
            entity.Property(e => e.VisitDate).HasColumnType("date");

            entity.HasOne(d => d.Pet).WithMany(p => p.VeterinaryRecords)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Veterinar__PetID__44FF419A");
        });

        modelBuilder.Entity<WeightAndHeight>(entity =>
        {
            entity.HasKey(e => e.MeasurementId).HasName("PK__WeightAn__85599F981DDADC07");

            entity.ToTable("WeightAndHeight");

            entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MeasurementDate).HasColumnType("date");
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Pet).WithMany(p => p.WeightAndHeights)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WeightAnd__PetID__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
