using Microsoft.EntityFrameworkCore;
using Test.Board.WebApp.Models;

namespace Test.Board.WebApp.DataContext
{
    public class BoardDbContext : DbContext
    {
        public DbSet<GeneralBoard> Boards { get; set; }
        public DbSet<GeneralBoardCategory> BoardCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Board;User Id=sa;Password=123qwe!@#QWE;Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Default Category Data
            modelBuilder.Entity<GeneralBoardCategory>()
                .HasData(
                new GeneralBoardCategory { Id = 1, Name = "유머" },
                new GeneralBoardCategory { Id = 2, Name = "지식" },
                new GeneralBoardCategory { Id = 3, Name = "기타" });
        }
    }
}
