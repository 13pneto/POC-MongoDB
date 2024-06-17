using POC.MongoDB2;

var builder = WebApplication.CreateBuilder(args);

builder
    .MapControllers()
    .AddSwaggerGen();

builder.Services.RegisterDependencies(builder.Configuration);


var app = builder.Build();

app
    .ConfigurePort()
    .ConfigureSwaggerAndControllers()
    .Run();