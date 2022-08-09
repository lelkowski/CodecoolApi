using CodecoolApi.Data.Context;
using CodecoolApi.Data.DAL;
using CodecoolApi.Data.DAL.Interfaces;
using CodecoolApi.Identity.Context;
using CodecoolApi.Middlewares;
using CodecoolApi.Services.Services;
using CodecoolApi.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("CodecoolApiDb");
var authConnectionString = builder.Configuration.GetConnectionString("CodecoolApiIdentityDb");
builder.Services.AddDbContext<CodecoolApiContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<CodecoolApiIdentityContext>(options => options.UseSqlServer(authConnectionString));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Services.AddScoped<LogHandlerMiddleware>();


builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<CodecoolApiIdentityContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddCors(o => o.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer Authorization",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string [] {}
                }
            });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CodecoolApi",
        Description = "An ASP.NET Core Web API for managing Educational Materials items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
