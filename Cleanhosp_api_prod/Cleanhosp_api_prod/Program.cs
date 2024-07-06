using CleanHosp.API.Services;
using CleanHosp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("CleanHospConnection");
builder.Services.AddDbContext<CleanHospContext>(options =>
    options.UseNpgsql(connectionString));

// Adição de serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração da autenticação JWT
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

// Adicionar autenticação e autorização ao pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
