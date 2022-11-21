using Kharaei.Infra; 
using Kharaei.Application; 

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container. 
builder.Services.AddDbContext(builder.Configuration);
var _siteSetting = builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddCustomIdentity(_siteSetting.IdentitySettings);
builder.Services.AddJwtAuthentication(_siteSetting.JwtSettings);
builder.Services.AddCustomApiVersioning();

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
