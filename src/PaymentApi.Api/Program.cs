using Microsoft.EntityFrameworkCore;
using PaymentApi.Application.Interfaces;
using PaymentApi.Application.Services;
using PaymentApi.Infrastructure.Commands;
using PaymentApi.Infrastructure.Data;
using PaymentApi.Infrastructure.Queries;

var builder = WebApplication.CreateBuilder(args);

// enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MicroserviceCorsPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Payment Services
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddScoped<IPaymentCommand, PaymentCommand>();
builder.Services.AddScoped<IPaymentQuery, PaymentQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MicroserviceCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();