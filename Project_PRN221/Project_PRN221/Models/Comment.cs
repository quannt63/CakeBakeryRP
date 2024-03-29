﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_PRN221.Models
{
    public partial class Comment
    {
        public Comment()
        {
            InverseParent = new HashSet<Comment>();
        }

        [Key]
        public int CommentId { get; set; }
        public string? Description { get; set; }
        public int? BlogId { get; set; }
        public int? Owner { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Blog? Blog { get; set; }
        public virtual User? OwnerNavigation { get; set; }
        public virtual Comment? Parent { get; set; }
        public virtual ICollection<Comment> InverseParent { get; set; }
    }
}
