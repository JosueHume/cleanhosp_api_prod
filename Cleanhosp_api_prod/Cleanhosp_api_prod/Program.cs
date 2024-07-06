using CleanHosp.API.Services;
using CleanHosp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da conex�o com o PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("CleanHospConnection");
builder.Services.AddDbContext<CleanHospContext>(options =>
    options.UseNpgsql(connectionString));

// Adi��o de servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o da autentica��o JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Registro dos servi�os
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

// Configura��o do CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configura��o do pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Adicionar autentica��o e autoriza��o ao pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
