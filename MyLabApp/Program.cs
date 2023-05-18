using Infraestructure.Core.Context;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyLabApp.Handlers;

var builder = WebApplication.CreateBuilder(args);


#region Context SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQLServer"));

});
#endregion


#region Inyection
DependencyInyectionHandler.DependencyInyectionConfig(builder.Services);
#endregion



// Add services to the container.

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("CorsPolicy", policy => 
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();

    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("CorsPolicy");

//app.UseCors("NewPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
