using Bl.Api;
using Bl.Services;
using Dal.Api;
using Dal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Dal.models.dbClass>();
builder.Services.AddScoped<IOptometrist, OptometristDAL>();
builder.Services.AddScoped<IOptometristBL, OptometristBL>();
builder.Services.AddScoped<IQueue, QueueDAL>();
builder.Services.AddScoped<IQueueBL, QueueBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
