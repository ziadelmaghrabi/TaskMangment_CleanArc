using Microsoft.EntityFrameworkCore;
using TaskMange.Core.Entiteis;

namespace TaskMange.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {
        }
        public DbSet<TaskItem> Tasks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.Property(t => t.Title)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(t => t.Description)
                      .HasMaxLength(500);

                entity.Property(t => t.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");
            });


        }
    }
}
