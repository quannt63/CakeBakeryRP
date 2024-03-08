using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_PRN221.Models
{
    public partial class OrderItem
    {
        [Key, Column(Order = 1)]
        public int OrderItemId { get; set; }
        //[Key, Column(Order = 2)]
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
