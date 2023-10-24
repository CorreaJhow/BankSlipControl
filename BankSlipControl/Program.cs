using BankSlipControl.Domain.Services.v1.Contracts;
using BankSlipControl.Domain.Services.v1.Implementation;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using Microsoft.EntityFrameworkCore;

namespace BankSlipControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContextDb>(opt => opt.UseNpgsql(
                    builder.Configuration.GetConnectionString("postgredb")));

            builder.Services.AddTransient<IBankSlipService, BankSlipService>();
            builder.Services.AddTransient<IBankService, BankService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}