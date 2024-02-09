using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vcart.Core.Entities;
using vcart.Repositories.Interfaces;
using vcart.Services.Interfaces;

namespace vcart.Services.Implementations
{
    public class OrderService : Service<Order>, IOrderService
    {
        IRepository<Order> _orderRepo;
        IOrderRepository _orderRepository;
        public OrderService(IRepository<Order> orderRepo, IOrderRepository orderRepository) :
            base(orderRepo)
        {
            _orderRepo = orderRepo;
            _orderRepository = orderRepository;
        }

        public Order GetOrderDetailWithItem(string id)
        {
            return _orderRepository.GetOrderDetailWithItem(id);
        }
    }
}
