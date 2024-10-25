
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.infransturture.Data;
using SchoolProject.infransturture;
using SchoolProject.service;
using SchoolProject.Core;
using SchoolProject.Core.MiddelWare;
using SchoolProject.infransturture.Identity;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.API.Extention;

namespace SchoolProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
      
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region DataBase
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<AppIdentityDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            #endregion




            #region Dependecy Injection
            builder.Services.AddModuleInfranstructure_ID()
                                  .Addservices_DI()
                                  .AddCore_DI()
                                  .AddServiceRegisteration();
            #endregion

            var app = builder.Build();


           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
