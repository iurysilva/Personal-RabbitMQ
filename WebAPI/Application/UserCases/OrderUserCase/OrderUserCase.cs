using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Models;

namespace WebAPI.Application.UserCases.OrderUserCase
{
    public class OrderUserCase : IOrderUserCase
    {
        private ILogger<OrderUserCase> _logger;

        public OrderUserCase(ILogger<OrderUserCase> logger)
        {
            _logger = logger;
        }

        public async Task<Order> InsertOrder(Order order)
        {
            try
            {
                return order;
            }catch(Exception ex)
            {
                _logger.LogError("Error trying to create a new order", ex);
                throw new Exception();
            }
        }
    }
}
