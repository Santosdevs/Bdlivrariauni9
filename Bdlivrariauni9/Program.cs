using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using LivrariaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração da String de Conexão MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configuração do DbContext para usar MySQL
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

// 4. Adicionar serviços ao contêiner
builder.Services.AddControllers(); // Adiciona suporte para controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirTudo"); // Aplicar a política de CORS

app.UseAuthorization();

// 6. Habilitar arquivos estáticos
app.UseStaticFiles();  // Isso permite servir arquivos da pasta wwwroot

// 7. Configuração do mapeamento de controladores
app.MapControllers();

// 8. Configuração para servir o front-end (index.html ou outro arquivo principal)
app.MapFallbackToFile("Index.html");  // Isso serve o front-end se a rota não for encontrada

app.Run();
