using Microsoft.EntityFrameworkCore;
using PracticalTask.DbConnection;
using PracticalTask.Mappers;
using PracticalTask.Services;
using PracticalTask.Services.Base;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PracticalTaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductUnitService, ProductUnitService>();
builder.Services.AddScoped<IIndividualCustomerService, IndividualCustomerService>();
builder.Services.AddScoped<ICorporateCustomerService, CorporateCustomerService>();
builder.Services.AddScoped<IMeetingMinutesMasterService, MeetingMinutesMasterService>();
builder.Services.AddScoped<IMeetingMinutesDetailsService, MeetingMinutesDetailsService>();


builder.Services.AddControllersWithViews();

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
