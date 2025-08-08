var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles(); // Serve index.html by default
app.UseStaticFiles();  // Serve static files like CSS and JS from wwwroot folder

// Define a GET endpoint /convert that accepts a 'number' query parameter
app.MapGet("/convert", (string number) =>
{
    // Validate input can be parsed as decimal
    if (!decimal.TryParse(number, out var value))
        return Results.BadRequest("Invalid number format");

    // Convert to words using our converter class
    var words = NumberToWordsConverter.Convert(value);
    return Results.Ok(words);
});

app.Run();
