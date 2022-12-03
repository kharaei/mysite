using Kharaei.Infra.Ioc;    
using Microsoft.AspNetCore.Mvc.ApiExplorer; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddDependencies(builder.Configuration); 
builder.Services.AddDbContext(builder.Configuration);  
builder.Services.AddCustomIdentity(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddCustomApiVersioning();
builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen();

var app = builder.Build();  

app.UseCustomExceptionHandler();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options => {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    }); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();