using Microsoft.EntityFrameworkCore;
using RandomUserGeneratorPaschoalotto.Application.Services;
using RandomUserGeneratorPaschoalotto.Infrastructure.Database;
using RandomUserGeneratorPaschoalotto.Infrastructure.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RandomUserGeneratorPaschoalottoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RandomUserGeneratorPaschoalottoContext") ?? throw new InvalidOperationException("Connection string 'RandomUserGeneratorPaschoalottoContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();
builder.Services.AddScoped<UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .AllowAnyOrigin() // Permite qualquer origem
            .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
            .AllowAnyHeader()); // Permite qualquer header
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
