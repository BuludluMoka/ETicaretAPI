using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Application.Helpers;
using OnionArchitecture.Application.Utilities.Mapper;
using OnionArchitecture.Application.Utilities.Settings;
using OnionArchitecture.Persistence.Repositories;
using System.Reflection;
using System.Text;

namespace OnionArchitecture.Application
{
    public static class ServiceRegistration
    {
     
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration )
        {
            AppSettings.AppSettingsConfigure(configuration);
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "PROJECT API", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                                }
                            },
                            new string[]{}
                        }
                    });

                try
                {
                    var xmlFilename = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                }
                catch (Exception)
                {

                }
            });

            services.AddAutoMapper(typeof(MappingProfile));
            var JwtConfiguration = AppSettings.GetSetting<JwtConfiguration>(SettingOptions.JwtConfiguration);

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidIssuer = JwtConfiguration.Issuer,
            //            ValidAudience = JwtConfiguration.Audience,
            //            ValidateIssuerSigningKey = true,
            //            ClockSkew = TimeSpan.Zero,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfiguration.SecurityKey)),

            //            //IssuerSigningKeys = new List<SymmetricSecurityKey> {
            //            //new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey)),
            //            //new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.RefreshTokenSecurityKey))
            //            //}
            //        };
            //    });


            //services.AddAuthorization(options =>
            //{
            //    options.FallbackPolicy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //});


            services.Configure<ApiBehaviorOptions>(options
              => options.SuppressModelStateInvalidFilter = true);
            ServiceProviderHelper.Create(services);

        }
    }
}