using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN221.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? Description { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Image { get; set; }

        public virtual User? CreateByNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
