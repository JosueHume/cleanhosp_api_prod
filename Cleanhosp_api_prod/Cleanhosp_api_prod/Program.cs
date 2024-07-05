using CleanHosp.API.Services;
using CleanHosp.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("CleanHospConnection");
builder.Services.AddDbContext<CleanHospContext>(options =>
    options.UseNpgsql(connectionString));

// Adição de serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro dos serviços
builder.Services.AddScoped<AlaService>();
builder.Services.AddScoped<LocalService>();
builder.Services.AddScoped<LimpezaService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<EquipamentoService>();
builder.Services.AddScoped<ProdutosUtilizadosService>();
builder.Services.AddScoped<EquipamentosUtilizadosService>();
builder.Services.AddScoped<LimpezaAndamentoService>();

var app = builder.Build();

// Configuração do CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
