using Microsoft.EntityFrameworkCore;
using MinimalAPI;
using MinimalAPI.Data;
using MinimalAPI.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MinimalContextDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user/{username}&&{password}", async (string username, string password, MinimalContextDb context) =>

 await context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password)
              is User user
                  ? Results.Ok(new Userdata(user.Name, user.BirthDate, user.City, user.Phone))
                  : Results.NotFound())
        .Produces<Userdata>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);



app.MapPost("/user", async (
    MinimalContextDb context,
    User user) =>
{
    context.Users.Add(user);
    var result = await context.SaveChangesAsync();
})
        .Produces<User>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest);

app.Run();
