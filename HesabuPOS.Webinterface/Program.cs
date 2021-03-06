using HesabuPOS.Webinterface.Models;
using HesabuPOS.Webinterface.Services;
using Microsoft.Extensions.FileProviders;
using System.Net;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<HesabuDatabaseSettings>(
    builder.Configuration.GetSection("HesabuPOSDatabase"));

builder.Services.AddSingleton<ArticleService>();
builder.Services.AddSingleton<StorageService>();
builder.Services.AddSingleton<StocksService>();
builder.Services.AddSingleton<VariantService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5001;
});



// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddSharedServices();

var app = builder.Build();
app.UsePathBase("/HesabuPOS");

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    

    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();
