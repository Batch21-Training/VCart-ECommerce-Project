using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vcart.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImageUrl { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string OrderId { get; set; }

        public virtual OrderModel Order { get; set; }
    }
}
