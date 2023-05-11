using Microsoft.EntityFrameworkCore;
using Test.Board.WebApp.DataContext;
using Test.Board.WebApp.Models;

namespace Test.Board.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<BoardDbContext>(options =>
            //    options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Board;User Id=sa;Password=123qwe!@#QWE;Encrypt=false;"));

            builder.Services.AddDbContext<BoardDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Seed Data
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BoardDbContext>();
                context.Database.EnsureCreated();

                if (!context.BoardCategories.Any())
                {
                    context.BoardCategories.Add(new GeneralBoardCategory { Name = "유머" });
                    context.BoardCategories.Add(new GeneralBoardCategory { Name = "지식" });
                    context.BoardCategories.Add(new GeneralBoardCategory { Name = "기타" });
                }
                context.SaveChanges();
            }

            app.Run();
        }
    }
}