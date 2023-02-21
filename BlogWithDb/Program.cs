using BlogWithDb.Models;
using BlogWithDb.Services;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AbduqayumovBlog")));


builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/NoAccess";
        options.ExpireTimeSpan = TimeSpan.FromSeconds(15);
    });


builder.Services.AddScoped<IGenericCRUDService<PostResponseModel, PostRegisterModel>, PostsCRUDService>();
builder.Services.AddScoped<IGenericRepository<Posts>, PostRepository>();

builder.Services.AddScoped<ICommentCRUDService<CommentResponseModel, CommentRegisterModel>, CommentCRUDService>();
builder.Services.AddScoped<IGenericRepository<Comment>, CommentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
