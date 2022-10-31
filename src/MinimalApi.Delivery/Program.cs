var builder = WebApplication.CreateBuilder(args);

builder.AddServices();
builder.AddOpenApi();
builder.AddEFCore();

var app = builder.Build();

app.UseServices();
app.MapCarter();
app.UseOpenApi(string.Empty);

await app.MigrateData();

app.Run();
