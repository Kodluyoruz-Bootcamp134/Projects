using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using MovieStore.Api.Filters;
using MovieStore.Business;
using MovieStore.DataAccess;
using MovieStore.DataAccess.Context;
using MovieStore.Business.Validations;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Middlewares;
using MovieStore.DataAccess.Repositories.Abstract;
using MovieStore.DataAccess.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddMovieDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCustomExeptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
