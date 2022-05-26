using BookCategory.Business;
using BookCategory.Business.Mapping;
using BookCategory.DataAccess.Data;
using BookCategory.DataAccess.Repositories;
using BookCategory.API.Extensions;
using Microsoft.EntityFrameworkCore;
using BookCategory.API.Middlewares;
using BookCategory.API.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, EFBookRepository>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<BookCategoryDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(opt => opt.AddPolicy("allow", cpb =>
{
    cpb.AllowAnyOrigin();
    cpb.AllowAnyHeader();
    cpb.AllowAnyMethod();
}));

var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(builder.Configuration.GetSection("token:Secret").Value));

//builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("Basic",null);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateActor = true,
                        ValidIssuer = "http://www.kodluyoruz.com",
                        ValidAudience = "http://client.kodluyoruz.com",
                        IssuerSigningKey = key

                    };
                });
var app = builder.Build();

//app.UseWelcomePage();
//app.Run(async (context) => {
//    await context.Response.WriteAsync("Talep, middleware tarafindan yakalandi");

//});
//app.Map("/test", middleBuilder =>
//{
//    middleBuilder.Run(async (ctx) =>
//    {
//        if (ctx.Request.Query.ContainsKey("id"))
//        {
//            int id = int.Parse(ctx.Request.Query["id"]);
//            await ctx.Response.WriteAsync($"{id} degeri, middleware'a geldi! ");
//            using var scope =  middleBuilder.ApplicationServices.CreateScope();
//            var bookService = scope.ServiceProvider.GetRequiredService<IBookService>();

//            if (await bookService.IsBookExists(id))
//            {
//                await ctx.Response.WriteAsync($"{id} degeri, db'de var!");
//            }
//            else
//            {
//                await ctx.Response.WriteAsync($"{id} degeri, db'de yok!");
//            }
//        }
//        else
//        {
//            await ctx.Response.WriteAsync($"id degeri, middleware'a gelmedi! ");
//        }
//    });
//});

//Yukaridaki kod yerine, bu extension metot cagiriliyor!!
app.UseBookIsExistTestPage();



app.Use((ctx, next) =>
{
    Console.WriteLine($"{ctx.Request.Path} adresinden, {ctx.Request.Method} talebi geldi!");
    return next();
});

//app.UseMiddleware<CheckBrowserIsIEMiddleware>();

//app.UseMiddleware<ResponseEditingMiddleware>();

//app.UseMiddleware<RedirectMiddleware>();

app.UseCheckIE();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("allow");


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
