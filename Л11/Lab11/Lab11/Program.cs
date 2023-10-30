using Lab11.Models.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddDbContext<TvPriceContext>(opt =>
{
    opt.UseInMemoryDatabase("TvPrices");
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TVPrice}/{action=Index}/{id?}");

app.Run();
