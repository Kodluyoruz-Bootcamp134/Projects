using Microsoft.EntityFrameworkCore;
using Valorant.Business;
using Valorant.Business.Mapping;
using Valorant.DataAccess.Data;
using Valorant.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IAgentRepository, EFAgentRepository>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<ValorantDbContext>(option=> option.UseSqlServer(builder.Configuration.GetConnectionString("db")));


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
