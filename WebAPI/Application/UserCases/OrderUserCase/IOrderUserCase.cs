using WebAPI.Domain.Models;

namespace WebAPI.Application.UserCases.OrderUserCase
{
    public interface IOrderUserCase
    {
        Task<bool> InsertOrder(Order order);
    }
}
