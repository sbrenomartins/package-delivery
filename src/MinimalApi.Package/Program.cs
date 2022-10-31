var builder = WebApplication.CreateBuilder(args);

builder.AddDapper();
builder.AddServices();
builder.AddOpenApi();
builder.AddMessages();

var app = builder.Build();

app.UseServices();
app.MapCarter();
app.UseOpenApi(string.Empty);

app.Run();
