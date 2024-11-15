
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
using SchoolProject.infransturture.DataSeeding;
using System.Data;

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
                      .AddServiceRegisteration(builder.Configuration);
#endregion

var app = builder.Build();

#region Dataseeding
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}

#endregion


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
