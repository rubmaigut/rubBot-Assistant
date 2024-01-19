using Microsoft.EntityFrameworkCore;
using RubBotApi.Data;
using RubBotApi.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RubBotContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("rubBotAssistantDatabase")));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();  //set the allowed origin
});


app.MapControllers();

app.Run();
