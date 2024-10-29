using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions; 
using LivrariaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conexão MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar o contexto para usar o MySQL
builder.Services.AddDbContext<LivrariaContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();
