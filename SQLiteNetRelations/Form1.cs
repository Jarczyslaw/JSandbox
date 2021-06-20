using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SQLiteNetRelations
{
    public partial class Form1 : Form
    {
        private readonly Random r = new Random();
        private readonly string dbName = "test.db";
        private readonly SQLiteConnectionString connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = new SQLiteConnectionString(dbName);
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var dbName = "test.db";
                if (!File.Exists(dbName))
                {
                    var db = new SQLiteConnection(connectionString);
                    db.CreateTable<User>();
                    db.CreateTable<Permission>();

                    var usersCount = 20000;
                    var users = new List<User>();
                    for (int i = 0; i < usersCount; i++)
                    {
                        users.Add(new User
                        {
                            Name = "UserUserUser_" + (i + 1)
                        });
                    }
                    db.InsertAll(users);

                    var permissionsCount = 50000;
                    var permissions = new List<Permission>();
                    for (int i = 0; i < permissionsCount; i++)
                    {
                        permissions.Add(new Permission
                        {
                            Name = "PermissionPermission_" + (i + 1),
                            UserId = r.Next(1, usersCount + 1)
                        });
                    }
                    db.InsertAll(permissions);
                    MessageBox.Show($"DB initialized with {usersCount} users and {permissionsCount} permissions");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var s = Stopwatch.StartNew();
                List<User> users = new List<User>();
                using (var db = new SQLiteConnection(connectionString))
                {
                    users = db.GetAllWithChildren<User>(u => u.Id > 10000).ToList();
                }
                ShowResult(s, users);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var s = Stopwatch.StartNew();
                List<User> users = new List<User>();
                List<Permission> permissions = new List<Permission>();
                using (var db = new SQLiteConnection(connectionString))
                {
                    users = db.Table<User>().Where(u => u.Id > 10000).ToList();
                    permissions = db.Table<Permission>().ToList();
                }
                IncludeMany(users, permissions, p => p.UserId, (u, p) => u.Permissions = p);
                ShowResult(s, users);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void ShowResult(Stopwatch stopwatch, List<User> users)
        {
            MessageBox.Show($"Users: {users.Count}, permissions: {users.Sum(x => x.Permissions.Count)} fetched in {stopwatch.Elapsed.TotalSeconds}s");
        }

        protected void IncludeMany<T1, T2>(List<T1> collection, List<T2> toInclude,
            Func<T2, int> foreignKeySelector, Action<T1, List<T2>> includeAction)
            where T1 : IKey
        {
            var dict = toInclude.GroupBy(foreignKeySelector).ToDictionary(a => a.Key, a => a.ToList());
            foreach (var entity in collection)
            {
                var list = new List<T2>();
                if (dict.TryGetValue(entity.Id, out List<T2> value))
                {
                    list = value;
                }
                includeAction(entity, list);
            }
        }
    }
}