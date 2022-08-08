using CodecoolApi.Data.Context;
using CodecoolApi.Data.DAL;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Middlewares;
using CodecoolApi.Services.Services;
using CodecoolApi.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("CodecoolApiDb");
builder.Services.AddDbContext<CodecoolApiContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Services.AddScoped<LogHandlerMiddleware>();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<LogHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
