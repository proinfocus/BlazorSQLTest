using BlazorSQLTest.Data;
using QuickDBS;

var builder = WebApplication.CreateBuilder(args);

string connectionString = @"Server=localhost\SqlExpress; Database=AdventureWorksLT2019; Trusted_Connection=true;";
var db = new SQLServer(connectionString);

// This line needs to be removed after first run.
// It will generate a folder by name 'Models' with all
// the classes for each table available in the database.
db.GenerateClassesForTables("Table");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
