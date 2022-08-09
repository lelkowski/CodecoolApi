using CodecoolApi.Identity.Context;
using CodecoolApi.Middlewares;
using CodecoolApi.Services.Services;
using System.Reflection;

namespace CodeCoolApi.Extensions
{
    public static class IServiceCollectionExtensions
    {
      public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
      {
            services.AddDbContext<CodecoolApiContext>(options => options.UseSqlServer(configuration["ConnectionStrings:Api"]));
            services.AddDbContext<CodecoolApiIdentityContext>(options => options.UseSqlServer(configuration["ConnectionStrings:Identity"]));
      }
       
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISetupService, SetupService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ITypeService, TypeService>();
        }

        public static void AddCustomMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddScoped<LogHandlerMiddleware>();
        }

        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddDefaultPolicy(builder => {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
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
        }
    }
}
