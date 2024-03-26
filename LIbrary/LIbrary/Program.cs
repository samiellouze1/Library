using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository;
using LIbrary.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// With Razor runtime compilation enabled, changes made to Razor views (.cshtml files) are automatically recompiled without requiring a manual build or restart of the application. 
// builder.Services.AddMvc().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Repository
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAvailabilityStatusRepository,AvailabilityStatusRepository>();
builder.Services.AddScoped<IBookCopyRepository,BookCopyRepository>();
builder.Services.AddScoped<IBookCopyStatusRepository,BookCopyStatusRepository>();
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IBorrowRepository,BorrowRepository>();
builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
#endregion

#region Service
// builder.Services.AddScoped<ICheckOutInService, CheckOutInService>();
#endregion





builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
// add role reader
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Reader",
        authBuilder =>
        {
            authBuilder.RequireRole("Reader");
        });

});
// add role Librarian
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Librarian",
        authBuilder =>
        {
            authBuilder.RequireRole("Librarian");
        });

});

// Claims are a way to retrieve current logged in (in session) user credentials like id or username
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, ApplicationUserClaimsPrincipalFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// The app.UseStaticFiles() method configures the middleware pipeline to serve static files, such as HTML, CSS, JavaScript, and image files, from the application's wwwroot directory or any other specified directory.
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
