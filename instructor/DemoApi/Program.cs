


using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ABove Here is configuring the "guts" the internals of our API (Services mostly)
var app = builder.Build();
// After this is configuring the "Http Pipeline" - how will it handle requests and make responses.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Is it close enough to go to lunch
app.MapGet("/lunchtime", () =>
{
    if (DateTime.Now.Hour == 12 && (DateTime.Now.Minute > 27))
    {
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

// Start the Kestrel Web Server - Listen on the assigned port (1338) for HTTP Requests.
app.Run();

