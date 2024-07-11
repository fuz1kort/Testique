using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application;
using Testique.API.Infrastructure;
using Testique.API.Persistence;
using Testique.API.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EfContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = true;
    })
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<EfContext>();

builder.Services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; });

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistenceLayer();
builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(cookie =>
{
    cookie.Cookie.SameSite = SameSiteMode.None;
});

builder.Services.AddCors(x =>
{
    x.AddPolicy("AllowAll", opt =>
    {
        opt.WithOrigins("http://localhost:3000");
        opt.AllowCredentials();
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();