using ChatApp.ChatHubDirectory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000", "http://192.168.0.102:3000")
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();

app.MapControllers();

app.MapHub<ChatHub>("api/chatHub");


app.Run();
