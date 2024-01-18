using Microsoft.EntityFrameworkCore;
using RubBotApi.Data;
using RubBotApi.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<RubBotContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("rubBotAssistant")));

builder.Services.AddControllers();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
