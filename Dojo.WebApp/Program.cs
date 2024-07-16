using Dojo.BLL;
using Dojo.DAO.Context;
using Dojo.DAO.Repository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbdojoContext>((serviceProvider, options) =>
{
	var isTest = Environment.GetEnvironmentVariable("IS_TEST");
	if (isTest == "True")
	{
		options.UseInMemoryDatabase("TestDatabase");
	}
	else
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	}
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependencia no IoC Repository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// Injeção de dependencia no IoC Service
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

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

app.Run();
