var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();


var api = app.MapGroup("api");

api.MapPost("login", (Credentials credentials) =>
{
    var response = new Response(credentials.Username);
    return Results.Ok(response);
});

app.Run();


record Credentials(string Username, string Password);

record Response(string Username);