using System.Reflection;
using Kharaei.Infra.Ioc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddCustomIdentity(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddCustomApiVersioning();
builder.Services.AddControllers(); 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(options =>
{    
    var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "Documentation.xml");
    options.IncludeXmlComments(xmlDocPath, true);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
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
            new List<string>()
        }
    });
});
var app = builder.Build();
app.UseCors(builder => builder.WithOrigins("https://insta.kharaei.ir").AllowAnyHeader().AllowAnyOrigin());
app.UseCustomExceptionHandler();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options => {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        };
        options.DefaultModelsExpandDepth(-1);
    });
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();