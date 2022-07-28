using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class BaseDataContext : DbContext
    {
        public BaseDataContext()
        {
        }

        public BaseDataContext(DbContextOptions<BaseDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<T_Party> T_Parties { get; set; }
        public virtual DbSet<T_Permission> T_Permissions { get; set; }
        public virtual DbSet<T_Voter> T_Voters { get; set; }
        public virtual DbSet<T_VoterInParty> T_VoterInParties { get; set; }
        public virtual DbSet<T_VoterPassword> T_VoterPasswords { get; set; }
        public virtual DbSet<T_VoterPermission> T_VoterPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("-----------------");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<T_Party>(entity =>
            {
                entity.HasKey(e => e.IdParty)
                    .HasName("PK__T_Party__19B4EEF9C0156FC7");

                entity.ToTable("T_Party");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<T_Permission>(entity =>
            {
                entity.HasKey(e => e.IdPermission)
                    .HasName("PK__T_Permis__17C26EA25F9B62AA");

                entity.ToTable("T_Permission");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<T_Voter>(entity =>
            {
                entity.HasKey(e => e.IdVoter)
                    .HasName("PK__T_Voter__754619480FBD4298");

                entity.ToTable("T_Voter");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.city)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.mail).IsUnicode(false);

                entity.Property(e => e.tz)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<T_VoterInParty>(entity =>
            {
                entity.HasKey(e => e.IdPointerInParty)
                    .HasName("PK__T_VoterI__5D833B746DF5B9CC");

                entity.ToTable("T_VoterInParty");

                entity.Property(e => e.date).HasColumnType("datetime");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.T_VoterInParties)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_VoterInParty_ToT_T_Party");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.T_VoterInParties)
                    .HasForeignKey(d => d.VoterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_VoterInParty_ToT_Voter");
            });

            modelBuilder.Entity<T_VoterPassword>(entity =>
            {
                entity.HasKey(e => e.IdVoterPassword)
                    .HasName("PK__T_VoterP__5120FBF08B3BCC4B");

                entity.ToTable("T_VoterPassword");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.T_VoterPasswords)
                    .HasForeignKey(d => d.VoterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_VoterPassword_ToT_Voter");
            });

            modelBuilder.Entity<T_VoterPermission>(entity =>
            {
                entity.HasKey(e => e.IdVoterPermission)
                    .HasName("PK__T_VoterP__963CD67FFBE28409");

                entity.ToTable("T_VoterPermission");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.T_VoterPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoterPermission_ToT_Permission");

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.T_VoterPermissions)
                    .HasForeignKey(d => d.VoterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoterPermission_ToT_Voter");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
