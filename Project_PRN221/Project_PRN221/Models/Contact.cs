using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN221.Models
{
    public partial class Contact
    {
        [Key] 
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? WorkTime { get; set; }
    }
}
