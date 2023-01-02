using WebAPI.Application.UserCases.OrderUserCase;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Routes
{
    public static class Endpoints
    {
        public static WebApplication AddEndpoints(this WebApplication app)
        {
            app.MapPost("/api/order", async Task<bool> (IOrderUserCase usercase, Order order) =>
            {
                return await usercase.InsertOrder(order);
            });
            return app;
        }
    }
}
