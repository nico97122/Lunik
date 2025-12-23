using MudBlazor.Services;
using RentingApp.Components;
using _1_RentingBS;
var builder = WebApplication.CreateBuilder(args);

//conteneur d'injection de dépendances a faire
builder.Services.AddScoped<IGiteService, GiteService>();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Ajout des services MudBlazor
builder.Services.AddMudServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
