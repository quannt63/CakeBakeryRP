using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN221.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }

        public virtual User? Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
