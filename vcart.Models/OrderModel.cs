using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vcart.Models
{
    public class OrderModel
    {
        public string Id { get; set; }
        public string PaymentId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }

        [DisplayName("Order Date")]
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<OrderItemModel> OrderItems { get; set; }
    }
}
