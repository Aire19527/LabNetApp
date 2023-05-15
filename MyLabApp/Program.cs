using Infraestructure.Core.Context;
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
