using LagerStatusEksamen.Interfaces;
using LagerStatusEksamen.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();//Swagger

builder.Services.AddSingleton<IServicePackageType>(new ServicePackageType());
builder.Services.AddSingleton<IServiceShelf>(new ServiceShelf());

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

app.UseCors(CorsName);//CORS

app.UseAuthorization();

app.MapControllers();

app.Run();
