var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Makes Swagger UI the default page
});
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();