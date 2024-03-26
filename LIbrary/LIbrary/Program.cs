using LIbrary.Data;
using LIbrary.Repository;
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
