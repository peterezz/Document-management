using AspNetCoreAssessment.AutoMapper;
using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Manger;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// database connection string
string ConnectionString = builder.Configuration.GetConnectionString("DeafualConnection");

// database connection
builder.Services.AddDbContext<AspnetcoreassessmentContext>(options => options.UseSqlServer(ConnectionString));

// AutoMaper Configurations
var config = new MapperConfiguration(Mcf =>
{
    Mcf.AddProfile(new DomainProfile());
    
});
var Mapper = config.CreateMapper();
builder.Services.AddSingleton(Mapper);

// add depedency injections
builder.Services.AddTransient<DocumentManger>();
builder.Services.AddTransient<PriorityManger>();
builder.Services.AddTransient<DocumentFilesManger>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
