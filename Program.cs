using Supabase;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Configurar Supabase
var url = Environment.GetEnvironmentVariable("API_URL");
var key = Environment.GetEnvironmentVariable("API_KEY");
builder.Services.AddSingleton<Client>(sp =>
{
    var client = new Supabase.Client(url, key);
    client.InitializeAsync().GetAwaiter().GetResult(); 
    return client;
});

builder.Services.AddControllers();

// CONFIGURAR CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
