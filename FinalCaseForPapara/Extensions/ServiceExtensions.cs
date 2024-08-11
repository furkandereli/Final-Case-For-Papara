using FinalCaseForPapara.Business.Helpers;
using FinalCaseForPapara.Business.Jwt;
using FinalCaseForPapara.Business.Services.CategoryServices;
using FinalCaseForPapara.Business.Services.CouponServices;
using FinalCaseForPapara.Business.Services.JwtServices;
using FinalCaseForPapara.Business.Services.OrderDetailServices;
using FinalCaseForPapara.Business.Services.OrderServices;
using FinalCaseForPapara.Business.Services.ProductServices;
using FinalCaseForPapara.Business.Services.UserServices;
using FinalCaseForPapara.DataAccess.Context;
using FinalCaseForPapara.DataAccess.Repositories.CouponRepositories;
using FinalCaseForPapara.DataAccess.Repositories.GenericRepositories;
using FinalCaseForPapara.DataAccess.Repositories.OrderRepositories;
using FinalCaseForPapara.DataAccess.Repositories.ProductRepositories;
using FinalCaseForPapara.DataAccess.Repositories.UserRepositories;
using FinalCaseForPapara.DataAccess.UnitOfWork;
using FinalCaseForPapara.Entity.Entities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace FinalCaseForPapara.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaparaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MssqlConnection")));

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<PaparaDbContext>();

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<OrderHelper>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpContextAccessor();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();
            var key = Encoding.ASCII.GetBytes(jwtConfig.SecretKey);
            
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Papara Final Case Api", Version = "v1.0" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Papara Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[] { } }
                });
            });

            return services;
        }
    }
}
