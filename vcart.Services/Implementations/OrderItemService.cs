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
    public class OrderItemService : Service<OrderItem>, IOrderItemService
    {
        IRepository<OrderItem> _orderItemRepo;
        public OrderItemService(IRepository<OrderItem> orderItemRepo) :
            base(orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }
    }
}
