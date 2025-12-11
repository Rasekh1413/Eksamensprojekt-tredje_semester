using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add /swagger/index.html URL for Swagger UI


// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();//Swagger

// Dependency injection
builder.Services.AddSingleton<IServicePackageType>(new ServicePackageType());
builder.Services.AddSingleton<IServiceShelf>(new ServiceShelf());
builder.Services.AddHttpClient(); // required for IHttpClientFactory
builder.Services.AddHostedService<UDPreciever>();


const string CorsName = "allow all";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsName,
        builder =>
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// enable CORS
app.UseCors(CorsName);//CORS

// Serve default files like index.html
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();


// Optional: test DB connectivity at startup (logs error if fails)
try
{
    using (var conn = new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")))
    {
        conn.Open();
        app.Logger.LogInformation("Database connection successful.");
    }
}
catch (Exception ex)
{
    app.Logger.LogError("Database connection failed: {Message}", ex.Message);
}

// Run the app
app.Run();
