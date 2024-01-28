using Microsoft.EntityFrameworkCore;
using SFNotes.Server.Entites;

namespace SFNotes.Server.Data
{
    public class SFNotesContext : DbContext
    {
        public SFNotesContext()
        {
        }

        public SFNotesContext(DbContextOptions<SFNotesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Name=ConnectionStrings:SFNOTES");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasColumnName("email");
                entity.Property(e => e.Password)
                    .HasColumnName("password");
                entity.Property(e => e.Username)
                    .HasColumnName("username");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp(3) without time zone")
                    .HasColumnName("created_at");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp(3) without time zone")
                    .HasColumnName("updated_at");
            });
        }
    }
}