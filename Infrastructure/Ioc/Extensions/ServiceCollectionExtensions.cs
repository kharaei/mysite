using System.Text;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Kharaei.Common;
using Kharaei.Domain;
using Kharaei.Application;
using Kharaei.Infra.Data;
using Microsoft.Extensions.Configuration;

namespace Kharaei.Infra.Ioc;

public static class ServiceCollectionExtensions
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));
        services.AddTransient<IBaseRepository<Article>, BaseRepository<Article>>(); 
        services.AddTransient<IBaseRepository<ArticleCategory>, BaseRepository<ArticleCategory>>();  
        services.AddTransient<IArticleCategoryService, ArticleCategoryService>();
        services.AddTransient<IArticleService, ArticleService>();  
        services.AddScoped<IUserService, UserService>();  
        services.AddScoped<IJwtService, JwtService>();   
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var _connectionString = configuration.GetConnectionString("MySql");
        services.AddDbContext<KharaeiDbContext>(options =>
        {
            // for SqlServer:
            //options.UseSqlServer(configuration.GetConnectionString("SqlServer")); 

            // for MySql
            options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        });
    }

    public static void AddCustomIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>().IdentitySettings;
        services.AddIdentity<User, Role>(identityOptions =>
        {
            //Password Settings
            identityOptions.Password.RequireDigit = settings.PasswordRequireDigit;
            identityOptions.Password.RequiredLength = settings.PasswordRequiredLength;
            identityOptions.Password.RequireNonAlphanumeric = settings.PasswordRequireNonAlphanumic; //#@!
            identityOptions.Password.RequireUppercase = settings.PasswordRequireUppercase;
            identityOptions.Password.RequireLowercase = settings.PasswordRequireLowercase;

            //UserName Settings
            identityOptions.User.RequireUniqueEmail = settings.RequireUniqueEmail;            
            
            //Singin Settings
            identityOptions.SignIn.RequireConfirmedEmail = false;
            identityOptions.SignIn.RequireConfirmedPhoneNumber = true;

            //Lockout Settings
            //identityOptions.Lockout.MaxFailedAccessAttempts = 5;
            //identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //identityOptions.Lockout.AllowedForNewUsers = false;
        })
        .AddEntityFrameworkStores<KharaeiDbContext>()
        .AddDefaultTokenProviders();
    }
   
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>().JwtSettings;
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var secretkey = Encoding.UTF8.GetBytes(settings.SecretKey);
            var encryptionkey = Encoding.UTF8.GetBytes(settings.Encryptkey);

            var validationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero, // default: 5 min
                RequireSignedTokens = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ValidateAudience = true, //default : false
                ValidAudience = settings.Audience,

                ValidateIssuer = true, //default : false
                ValidIssuer = settings.Issuer,

                TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
            };

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = validationParameters;
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    //var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                    //logger.LogError("Authentication failed.", context.Exception);

                    if (context.Exception != null)
                        throw new AppException(ApiResultStatusCode.UnAuthorized, "Authentication failed.", HttpStatusCode.Unauthorized, context.Exception, null);

                    return Task.CompletedTask;
                },
                OnTokenValidated = async context =>
                {
                    //var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<User>>();
                    //var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();

                    var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                    if (claimsIdentity.Claims?.Any() != true)
                        context.Fail("This token has no claims.");

                    //var securityStamp = claimsIdentity.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
                    //if (!securityStamp.HasValue())
                    //    context.Fail("This token has no secuirty stamp");

                    //Find user and token from database and perform your custom validation
                    //var userId = claimsIdentity.GetUserId<int>();
                    //var user = await userRepository.GetByIdAsync(context.HttpContext.RequestAborted, userId);

                    //if (user.SecurityStamp != Guid.Parse(securityStamp))
                    //    context.Fail("Token secuirty stamp is not valid.");

                    //var validatedUser = await signInManager.ValidateSecurityStampAsync(context.Principal);
                    //if (validatedUser == null)
                    //    context.Fail("Token secuirty stamp is not valid.");

                    //if (!user.IsActive)
                    //    context.Fail("User is not active.");

                    //await userRepository.UpdateLastLoginDateAsync(user, context.HttpContext.RequestAborted);
                },
                OnChallenge = context =>
                {
                    //var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                    //logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);

                    if (context.AuthenticateFailure != null)
                        throw new AppException(ApiResultStatusCode.UnAuthorized, "Authenticate failure.", HttpStatusCode.Unauthorized, context.AuthenticateFailure, null);
                        
                    throw new AppException(ApiResultStatusCode.UnAuthorized, "You are unauthorized to access this resource.", HttpStatusCode.Unauthorized);

                    //return Task.CompletedTask;
                }
            };
        });
    }

    public static void AddCustomApiVersioning(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddApiVersioning(options =>
        { 
           options.AssumeDefaultVersionWhenUnspecified = true;
           options.DefaultApiVersion = new ApiVersion(2, 0);
           options.ReportApiVersions = true;
        }); 

        services.AddVersionedApiExplorer(options => 
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });   

    }

}