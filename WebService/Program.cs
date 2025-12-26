var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();