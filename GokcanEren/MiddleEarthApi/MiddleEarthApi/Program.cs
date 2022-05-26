using Characters.Dal;
using Characters.Dal.Repository;
using Characters.Services;
using Characters.Services.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IService, CharacterService>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(CharacterMap));

builder.Services.AddDbContext<ApplicationDbContext>(opt=>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});

builder.Services.AddCors(opt => opt.AddPolicy("allow",corsBuilder =>
{
    corsBuilder.AllowAnyOrigin();
    corsBuilder.AllowAnyMethod();
    corsBuilder.AllowAnyHeader();
}));

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("token:secret").Value));

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

//app.Map("/test", mbuilder =>
//{
//    mbuilder.Run(async (context) =>
//    {
//        if (context.Request.Query.ContainsKey("id"))
//        {
//            int id = int.Parse(context.Request.Query["id"]);
//            await context.Response.WriteAsync($"{id} değeri middleware ulaştı!");
//        }
//        else
//        {
//            await context.Response.WriteAsync($" id middleware ulaşmadı!");
//        }

//    });
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
