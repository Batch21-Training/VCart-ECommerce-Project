using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vcart.Core.Entities;

namespace vcart.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrderDetailWithItem(string id);
    }
}
