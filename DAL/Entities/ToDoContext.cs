using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public partial class ToDoContext : DbContext
    {

        public ToDoContext() : base()
        {
        }
        public ToDoContext(DbContextOptions<ToDoContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ToDoDb;Trusted_Connection=True;TrustServerCertificate=True;");

            }
        }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100); 
                entity.Property(e => e.Description);
                entity.Property(e => e.Status).HasConversion<string>();
                entity.Property(e => e.Priority).HasConversion<string>();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
