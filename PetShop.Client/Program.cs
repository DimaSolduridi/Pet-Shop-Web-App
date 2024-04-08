using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Repositories;
using PetShop.Models.Entities;
using PetShop.Services;
using PetShop.Services.MapperProfiles;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PetShopDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<IRepository<Animal>, AnimalRepository>();
builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
builder.Services.AddTransient<IRepository<Comment>, CommentRepository>();
builder.Services.AddTransient<IAnimalsService, AnimalsService>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<ICommentsService, CommentsService>();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AnimalMapperProfile)));


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopDbContext>();
    ctx.Database.EnsureCreated();
    //ctx.Database.EnsureDeleted();
    ctx.SeedData(ctx);
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
