using Microsoft.EntityFrameworkCore;
using Test.Board.WebApp.Models;

namespace Test.Board.WebApp.DataContext
{
    public class BoardDbContext : DbContext
    {
        public DbSet<GeneralBoard> Boards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Board;User Id=sa;Password=123qwe!@#QWE;Encrypt=false;");
        }
    }
}
