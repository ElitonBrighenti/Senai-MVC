using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Senai.Domain.Interfaces;
using Senai.Repository.Context;
using Senai.Repository.Repositories;
using Senai.Service.Interfaces;
using Senai.Service.Services;

namespace Senai.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<SenaiContext>(options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SenaiWeb;User Id=postgres;Password=2024;"));

            builder.Services.AddScoped<IEscolaService, EscolaService>();
            builder.Services.AddScoped<IEstadoService, EstadoService>();


            builder.Services.AddScoped<IEscolaRepository, EscolaRepository>();
            //builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();


            #region AutoMapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(new[] { "Senai.Service" });
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());

            #endregion
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

            app.Run();
        }
    }
}
