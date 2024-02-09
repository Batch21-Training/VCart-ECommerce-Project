using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        AppDbContext dbContext
        {
            get { return _db as AppDbContext; }
        }

        public OrderRepository(AppDbContext db) : base(db)
        {

        }

        public Order GetOrderDetailWithItem(string id)
        {
            return dbContext.Orders.Include(o => o.OrderItems).
                Where(i => i.Id == id).FirstOrDefault();
        }
    }
}
