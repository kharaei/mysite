using Kharaei.Infra; 
using Kharaei.Application; 
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container. 
builder.Services.AddDbContext(builder.Configuration); 
builder.Services.AddCustomIdentity(builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>().IdentitySettings);
builder.Services.AddJwtAuthentication(builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>().JwtSettings);
builder.Services.AddCustomApiVersioning();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "API V1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "API V2" });  
});


var app = builder.Build();  
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2");
    }); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();