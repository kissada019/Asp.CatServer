using CatServerApi.IRepo;
using CatServerApi.Model.Data;
using CatServerApi.Repo;

var builder = WebApplication.CreateBuilder(args);

var configValue = builder.Configuration["Swagger"];

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<DapperDbContext>();


builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
