using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BussinessObject.Models
{
    public partial class CapstoneRegistrationContext : DbContext
    {
        public CapstoneRegistrationContext()
        {
        }

        public CapstoneRegistrationContext(DbContextOptions<CapstoneRegistrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentInGroup> StudentInGroups { get; set; } = null!;
        public virtual DbSet<StudentInSemester> StudentInSemesters { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<TopicOfLecture> TopicOfLectures { get; set; } = null!;
        public virtual DbSet<TopicOfSemester> TopicOfSemesters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Database=CapstoneRegistration;uid=sa;pwd=123;Trusted_Connection =true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TopicStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Lecture");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Topic");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lecture");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Semester1)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Semester");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentInGroup>(entity =>
            {
                entity.ToTable("StudentInGroup");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentInGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInGroup_Group");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInGroups)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInGroup_Student");
            });

            modelBuilder.Entity<StudentInSemester>(entity =>
            {
                entity.ToTable("StudentInSemester");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInSemester_Semester");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInSemester_Student");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TopicOfLecture>(entity =>
            {
                entity.ToTable("TopicOfLecture");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.TopicOfLectures)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicOfLecture_Lecture");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicOfLectures)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicOfLecture_Topic");
            });

            modelBuilder.Entity<TopicOfSemester>(entity =>
            {
                entity.ToTable("TopicOfSemester");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.TopicOfSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicOfSemester_Semester");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicOfSemesters)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicOfSemester_Topic");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
