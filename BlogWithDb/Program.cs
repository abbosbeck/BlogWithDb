using BlogWithDb.Models;
using BlogWithDb.Services;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AbduqayumovBlog")));

builder.Services.AddScoped<IGenericCRUDService<PostsModel>, PostsCRUDService>();
builder.Services.AddScoped<IGenericRepository<Posts>, PostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
