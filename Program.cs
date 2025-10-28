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

var app = builder.Build();

app.MapControllers();

app.Run();
