using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.DataAccess.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}