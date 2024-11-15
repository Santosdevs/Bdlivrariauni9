using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using LivrariaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura��o da String de Conex�o MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configura��o do DbContext para usar MySQL
builder.Services.AddDbContext<LivrariaContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 3. Habilitar CORS para permitir chamadas do front-end
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 4. Adicionar servi�os ao cont�iner
builder.Services.AddControllers(); // Adiciona suporte para controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configura��o do pipeline de requisi��es
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirTudo"); // Aplicar a pol�tica de CORS

app.UseAuthorization();

// 6. Habilitar arquivos est�ticos
app.UseStaticFiles();  // Isso permite servir arquivos da pasta wwwroot

// 7. Configura��o do mapeamento de controladores
app.MapControllers();

// 8. Configura��o para servir o front-end (index.html ou outro arquivo principal)
app.MapFallbackToFile("Index.html");  // Isso serve o front-end se a rota n�o for encontrada

app.Run();
