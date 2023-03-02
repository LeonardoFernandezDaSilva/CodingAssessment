using CodingAssessment.API.Middlewares;
using CodingAssessment.Application.Features.Cars.Queries;
using CodingAssessment.Domain.Features.Cars;
using CodingAssessment.Infrastructure.Features.Cars;
using CodingAssessment.Infrastructure.Mocks;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(GetAllCarsQuery).Assembly);

//services cors
builder.Services.AddCors(p => p.AddPolicy("MyCorsPolicy", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//Register repositories
builder.Services.AddTransient<ICarsRepository, CarsRepository>();
builder.Services.AddSingleton(new CarsMockDatabase());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
