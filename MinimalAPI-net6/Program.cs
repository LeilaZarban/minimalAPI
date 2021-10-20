using MinimalAPI_net6.Extentions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();
// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPI V1");
    c.RoutePrefix = "";
});
app.UseAuthentication();
app.UseAuthorization();
app.AddEndpoints();


app.Run();