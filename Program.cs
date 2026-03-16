using Microsoft.EntityFrameworkCore;
using TrelloAPI.Data;
using TrelloAPI.Repositories;
using TrelloAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<TrelloDbContext>(options =>
    options.UseSqlite("Data Source=trello.db"));

// Repositories
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<ITaskListRepository, TaskListRepository>();
builder.Services.AddScoped<ITasksItemRepository, TasksItemRepository>();

// Services
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<ITaskListService, TaskListService>();
builder.Services.AddScoped<ITasksItemService, TasksItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Interfaz visual en /swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();