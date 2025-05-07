using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SkillSearch.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ElasticService>();

var app = builder.Build();

app.MapControllers();
app.Run();
