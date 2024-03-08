using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_PRN221.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(400)]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string? Name { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Dob { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(600)]
        public string? Avatar { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
