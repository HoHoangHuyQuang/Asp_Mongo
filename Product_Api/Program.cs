using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Product_Api.Data;
using Product_Api.Repository;
using Product_Api.Repository.Implement;
using Product_Api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ProductDatabaseSettings>(builder.Configuration.GetSection("ProductDatabase"));
builder.Services.AddSingleton<IProductDatabaseSettings>(p=> p.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);

builder.Services.AddScoped<IMongoContext, MongoContext>();

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();


// End add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
