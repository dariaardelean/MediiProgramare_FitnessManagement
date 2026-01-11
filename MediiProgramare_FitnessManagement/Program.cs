using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediiProgramare_FitnessManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
    {
        //doar utilizatori logati
        options.Conventions.AuthorizeFolder("/FitnessClasses");

        //doar admin
        options.Conventions.AuthorizeFolder("/Bookings");

    });

//DbContext principal
builder.Services.AddDbContext<MediiProgramare_FitnessManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediiProgramare_FitnessManagementContext") ?? throw new InvalidOperationException("Connection string 'MediiProgramare_FitnessManagementContext' not found.")));

//DbContext pt Identity
builder.Services.AddDbContext<FitnessIdentityContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MediiProgramare_FitnessManagementContext")
    ));

//Identity

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<FitnessIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
