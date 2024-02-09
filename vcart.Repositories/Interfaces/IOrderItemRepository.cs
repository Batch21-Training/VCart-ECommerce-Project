using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vcart.Core.Entities;
using vcart.Repositories.Implementations;

namespace vcart.Repositories.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }
}
