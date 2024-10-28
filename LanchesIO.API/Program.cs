using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Services;
using LanchesIO.API.Services;
using LanchesIO.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using LanchesIO.API.Data;
using LanchesIO.API.src.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.Secrets.json", optional: true, reloadOnChange: true);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o banco de dados
// Configurar o DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ILancheService, LancheService>();
builder.Services.AddScoped<IIngredienteService, IngredienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IAuthService, AuthService>();



// Configurar Autentica��o JWT
byte[] key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();

    var adminUsername = builder.Configuration["AdminCredentials:Username"];
    var adminPassword = builder.Configuration["AdminCredentials:Password"];

    if (!context.Users.Any() && !string.IsNullOrEmpty(adminUsername) && !string.IsNullOrEmpty(adminPassword))
    {
        var user = new User
        {
            Username = adminUsername,
            Password = adminPassword
        };
        context.Users.Add(user);
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();


// Adicionar Autoriza��o
builder.Services.AddAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
