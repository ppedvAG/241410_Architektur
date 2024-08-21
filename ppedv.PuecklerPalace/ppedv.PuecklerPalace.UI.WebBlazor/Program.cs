using ppedv.PuecklerPalace.Logic;
using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.Contracts.Services;
using ppedv.PuecklerPalace.UI.WebBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

string conString = "Server=(localdb)\\mssqllocaldb;Database=PücklerDb_Test;Trusted_Connection=true;";
builder.Services.AddTransient<IRepository>(x => new ppedv.PuecklerPalace.Data.Db.PuecklerContextRepositoryAdapter(conString));
builder.Services.AddScoped<IEisService, EisService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
