using Bike.Api.Application.Abstract;
using Bike.Api.Application.Concrete;
using Bike.Api.WebApi.Middleware;
using Bike.Common;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBikeService, BikeService>();

builder.Services.AddHttpClient("bike-api", c =>
{
    c.BaseAddress = new Uri(BikeConstants.BaseUrl);
})
.AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(6)))
.AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddlewareExtension>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
