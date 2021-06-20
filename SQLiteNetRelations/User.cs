using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace SQLiteNetRelations
{
    [Table("Users")]
    public class User : IKey
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Permission> Permissions { get; set; }
    }
}