using HesabuPOS.Webinterface.Models;
using HesabuPOS.Webinterface.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<HesabuDatabaseSettings>(
    builder.Configuration.GetSection("HesabuPOSDatabase"));

builder.Services.AddSingleton<InventoryService>();
builder.Services.AddSingleton<ProductService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
