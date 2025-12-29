using _1_RentingBS;
using MudBlazor.Services;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using RentingApp.Components;


var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();


try
{
    var builder = WebApplication.CreateBuilder(args);

    // set up NLog 
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();


    logger.Info($"app initialization, ENV ={builder.Environment.EnvironmentName}");


    //conteneur d'injection de dépendances a faire
    builder.Services.AddScoped<IGiteService, GiteService>();
    builder.Services.AddSingleton<ILocalizationService, LocalizationService>();

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

}
catch (Exception e) 
{
    logger.Error(e, "Error during launch");
    throw;
}
