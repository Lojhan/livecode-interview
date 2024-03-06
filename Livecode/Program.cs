using Livecode.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidatorsConfig();
builder.Services.AddDatabaseContext();
builder.Services.AddParsersConfig();
builder.Services.AddRepositoriesConfig();
builder.Services.AddUsecasesConfig();
builder.Services.AddServicesConfig();
builder.Services.AddProjectConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddCorsConfig();
builder.Services.AddHealthChecksConfig();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();