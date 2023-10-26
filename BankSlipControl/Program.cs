using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.InputModels.v1.BankSlip;
using BankSlipControl.Domain.InputModels.v1.User;
using BankSlipControl.Domain.Mappers.v1.BankProfile;
using BankSlipControl.Domain.Services.v1.BankService;
using BankSlipControl.Domain.Services.v1.BankSlipService;
using BankSlipControl.Domain.Services.v1.UserService;
using BankSlipControl.Domain.Validations.v1.BankSlipValidation;
using BankSlipControl.Domain.Validations.v1.BankValidation;
using BankSlipControl.Domain.Validations.v1.UserValidation;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1;
using BankSlipControl.Infrastructure.ImplementationPersistence.v1.Implementation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BankSlipControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Avaliação de Conhecimentos em C#",
                    Description = "BankSlipControl, application of partial management of banks and Bank Slips.",
                    Contact = new OpenApiContact
                    {
                        Name = "Jhonatas R Correa",
                        Email = "jhonatasrcorrea@correa.com",
                        Url = new Uri("https://www.linkedin.com/in/jhonatas-r-correa/")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<ContextDb>(opt => opt.UseNpgsql(
                    builder.Configuration.GetConnectionString("postgredb")));

            builder.Services.AddTransient<IBankSlipService, BankSlipService>();
            builder.Services.AddTransient<IBankService, BankService>();
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddTransient<IValidator<BankInputModel>, BankValidator>();
            builder.Services.AddTransient<IValidator<BankSlipInputModel>, BankSlipValidator>();
            builder.Services.AddTransient<IValidator<UserInputModel>, UserValidator>();

            builder.Services.AddAutoMapper(typeof(BankProfile));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}