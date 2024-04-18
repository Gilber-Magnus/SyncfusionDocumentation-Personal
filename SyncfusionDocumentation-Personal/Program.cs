using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SyncfusionDocumentation_Personal.Data;
using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Globalization;
using SyncfusionDocumentation_Personal.Culture;
using BoldReports.Web.ReportViewer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//enable overall Right-To-Left while registering syncfusion
//options => { options.EnableRtl = true; }
builder.Services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Default;});
builder.Services.AddDbContext<OrderDetailsDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDetailsDatabase")));
//custom adaptor as component service
builder.Services.AddScoped<Order>();
//Register the Syncfusion locale service to localize Syncfusion Blazor components.
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();



var supportedCultures = new[] { "en-US", "de-DE", "fr-FR", "ar-AE", "zh-HK" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

var app = builder.Build();

//dynamically setting the culture
app.UseRequestLocalization(localizationOptions);
//Register Syncfusion License
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIyOTM3MEAzMjM1MmUzMDJlMzBlT2FhK0FNc2xDRVJCSm04ZW5SQTl5MmQvckxBdUhJQTZPUUJCOXFzdjVJPQ==");

//Register Bold license
Bold.Licensing.BoldLicenseProvider.RegisterLicense("YOUR LICENSE TOKEN HERE");

//statically setting the culture
//app.UseRequestLocalization("fr-FR");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.MapDefaultControllerRoute();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
