using lms.context;
using lms.DataAccess.Abstract;
using lms.DataAccess.Implementation;
using lms.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//configuring our database
builder.Services.AddDbContext<AppDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.....")),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddTransient<IUser, User>();
builder.Services.AddTransient<IOrder, Order>();
builder.Services.AddTransient<IBook, Book>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDBContext>();
    SeedData(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
options.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//registering cord origin in pipeline always do this before auth
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

static void SeedData(AppDBContext dbContext)
{
    if (!dbContext.Users.Any(user => user.name == "User1" && user.username == "User1@"))
    {
        var user1 = new user
        {
            name = "User1",
            username = "User1",
            password = "User1@",
            token = 0
        };
        dbContext.Users.Add(user1);
    }
    if (!dbContext.Users.Any(user => user.name == "User2" && user.username == "User2@"))
    {
        var user2 = new user
        {
            name = "User2",
            username = "User2",
            password = "User2@",
            token = 0
        };
        dbContext.Users.Add(user2);
    }
    if (!dbContext.Users.Any(user => user.name == "User3" && user.username == "User3@"))
    {
        var user3 = new user
        {
            name = "User3",
            username = "User3",
            password = "User3@",
            token = 0
        };
        dbContext.Users.Add(user3);
    }
    if (!dbContext.Users.Any(user => user.name == "User4" && user.username == "User4@"))
    {
        var user4 = new user
        {
            name = "User4",
            username = "User4",
            password = "User4@",
            token = 0
        };
        dbContext.Users.Add(user4);
    }
    dbContext.SaveChanges();
}