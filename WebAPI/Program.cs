using WebAPI.Application.Routes;
using WebAPI.Application.UserCases.OrderUserCase;
using Adapters.RabbitMQ.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRabbitMQAdapter();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderUserCase, OrderUserCase>();
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.AddEndpoints();

app.Run();
