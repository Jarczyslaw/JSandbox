using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkTest.DataAccess.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }
    }
}