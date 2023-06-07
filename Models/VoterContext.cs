using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VotersApplication.Models;

public partial class VoterContext : DbContext
{
    public VoterContext()
    {
    }

    public VoterContext(DbContextOptions<VoterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RegisteredVoter> RegisteredVoters { get; set; }

    public virtual DbSet<VoterLog> VoterLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\LocalDBDemo;Database=Voter;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisteredVoter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Register__3214EC07AA84D76B");

            entity.ToTable("RegisteredVoter");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.VoterIdNumber).HasMaxLength(13);
        });

        modelBuilder.Entity<VoterLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__VoterLog__5E5486488EC31E88");

            entity.ToTable("VoterLog");

            entity.Property(e => e.VoteDate).HasColumnType("datetime");

            entity.HasOne(d => d.Voter).WithMany(p => p.VoterLogs)
                .HasForeignKey(d => d.VoterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VoterLog__VoterI__25869641");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
