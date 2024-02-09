using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vcart.Core;
using vcart.Core.Entities;
using vcart.Repositories.Interfaces;

namespace vcart.Repositories.Implementations
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        AppDbContext dbContext
        {
            get { return _db as AppDbContext; }
        }

        public OrderItemRepository(AppDbContext db) : base(db)
        {

        }
    }
}
