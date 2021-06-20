using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SQLiteNetRelations
{
    [Table("Permissions")]
    public class Permission : IKey
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }

        [ManyToOne]
        public User User { get; set; }
    }
}