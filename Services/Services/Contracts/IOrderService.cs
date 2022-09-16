using Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Contracts
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order orders);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
