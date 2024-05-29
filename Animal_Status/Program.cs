using Animal_Status;
using Animal_Status.Util;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AnimalServiceContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });


builder.Services.AddAutoMapper(typeof(BLL.Mapping.UserMapper));
builder.Services.AddAutoMapper(typeof(Animal_Status.Mapping.UserMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.PetMapper));
builder.Services.AddAutoMapper(typeof(Animal_Status.Mapping.PetMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.AnimalTypeMapper));
builder.Services.AddAutoMapper(typeof(Animal_Status.Mapping.AnimalTypeMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.VaccinationMapper));
builder.Services.AddAutoMapper(typeof(Animal_Status.Mapping.VaccinationMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.PetVaccinationMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.DietMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.ExerciseMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.SleepAndRestMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.StressLevelMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.BehaviorMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.VeterinaryRecordMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.WeightAndHeightMapper));

builder.Services.AddScoped<IBehaviorService, BehaviorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVeterinaryRecordService, VeterinaryRecordService>();
builder.Services.AddScoped<IStressLevelService, StressLevelService>();
builder.Services.AddScoped<ISleepAndRestService, SleepAndRestService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IDietService, DietService>();
builder.Services.AddScoped<IPetVaccinationService, PetVaccinationService>();
builder.Services.AddScoped<IVaccinationService, VaccinationService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAnimalTypeService, AnimalTypeService>();
builder.Services.AddScoped<IWeightAndHeightService, WeightAndHeightService>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
