using MongoDB.Driver;
using MyCQRSProject.Domain.Interfaces;
using MyCQRSProject.Infrastructure.Repositories;
using MyCQRSProject.Commands;
using MyCQRSProject.Queries;

var builder = WebApplication.CreateBuilder(args);

#region addedService
builder.Services.AddSingleton<IMongoClient, MongoClient>(s =>
{
    var uri = s.GetRequiredService<IConfiguration>()["MongoDb:LocalConnectionString"];
    return new MongoClient(uri);
});
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddQueries();
builder.Services.AddCommands();
#endregion

#region  defaultService
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();