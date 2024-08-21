using ppedv.PuecklerPalace.Logic;
using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.Contracts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conString = "Server=(localdb)\\mssqllocaldb;Database=PücklerDb_Test;Trusted_Connection=true;";
builder.Services.AddTransient<IRepository>(x => new ppedv.PuecklerPalace.Data.Db.PuecklerContextRepositoryAdapter(conString));
builder.Services.AddScoped<IEisService, EisService>();
builder.Services.AddScoped<IOrderService, OrderService>();

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
