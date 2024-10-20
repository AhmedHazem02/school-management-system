
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.infransturture.Data;
using SchoolProject.infransturture;
using SchoolProject.service;
using SchoolProject.Core;
using SchoolProject.Core.MiddelWare;

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
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #region Dependecy Injection
                 builder.Services.AddModuleInfranstructure_ID()
                                  .Addservices_DI()
                                  .AddCore_DI();
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
