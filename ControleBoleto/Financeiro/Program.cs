using Domain.Helpers;
using Infra.Repository.Context;
using Infra.Repository.Repository;
using Infra.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Financeiro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(FinanceiroProfile));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IBaseRepository, BaseRepository>();
            builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
            builder.Services.AddScoped<IBancoRepository, BancoRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FinanceiroContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
                    assembly => assembly.MigrationsAssembly(typeof(FinanceiroContext).Assembly.FullName));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}