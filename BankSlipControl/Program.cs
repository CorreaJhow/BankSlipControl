using BankSlipControl.Domain.Mappers.v1.BankProfile;
using BankSlipControl.Domain.Services.v1.BankContract;
using BankSlipControl.Domain.Services.v1.BankSlipContract;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace BankSlipControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContextDb>(opt => opt.UseNpgsql(
                    builder.Configuration.GetConnectionString("postgredb")));

            builder.Services.AddTransient<IBankSlipService, BankSlipService>();
            builder.Services.AddTransient<IBankService, BankService>();

            builder.Services.AddAutoMapper(typeof(BankProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}