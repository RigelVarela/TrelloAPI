using Microsoft.EntityFrameworkCore;
using TrelloAPI.Models;

namespace TrelloAPI.Data;

public class TrelloDbContext : DbContext
{
    public TrelloDbContext(DbContextOptions<TrelloDbContext> options)
        : base(options) { }

    public DbSet<Board> Boards { get; set; }
    public DbSet<TaskList> Lists { get; set; }
    public DbSet<TasksItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ── BOARD ─────────────────────────────────────────────────────
        modelBuilder.Entity<Board>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.HasMany(e => e.TaskLists)
                .WithOne(l => l.Board)
                .HasForeignKey(l => l.BoardId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ── TASKLIST ──────────────────────────────────────────────────
        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            // ✅ Ahora sí apunta a TasksItem
            entity.HasMany(e => e.Tasks)
                .WithOne(t => t.TaskList)
                .HasForeignKey(t => t.TaskListId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // ── TASKSITEM ─────────────────────────────────────────────────
        modelBuilder.Entity<TasksItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Description)
                .HasMaxLength(1000);

            entity.Property(e => e.Status)
                .HasConversion<string>();
        });
    }
}