using Kharaei.Infra.Ioc;
using Kharaei.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
 
 
builder.Services.AddDbContext(app.Configuration);
SiteSettings _siteSetting = app.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddCustomIdentity(_siteSetting.IdentitySettings);

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
