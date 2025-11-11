using Construlink.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MudBlazor;

using Construlink.Data;
using Construlink.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<Utils>();
builder.Services.AddScoped<LayoutUpdateService>();
builder.Services.AddScoped<EnumOptions>();
builder.Services.AddScoped<IDbContextFactoryService, DbContextFactoryService>();
builder.Services.AddControllers();
builder.Services.AddScoped<ILocalPdfService, LocalPdfService>();


builder.Services.AddControllers();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options =>
    {
        options.DetailedErrors = true;
    });
builder.Services.AddHttpClient();




builder.Services.AddMudServices();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
//builder.Services.AddScoped<AxClock.Services.FichaTecnicaPdfService>();
//QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//mimi para permitir o download de ficheiros apk
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/octet-stream",
    OnPrepareResponse = ctx =>
    {
        if (ctx.File.Name.EndsWith(".apk", StringComparison.OrdinalIgnoreCase))
        {
            ctx.Context.Response.ContentType = "application/vnd.android.package-archive";
        }
    }
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();      // depois de app.UseRouting()

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
