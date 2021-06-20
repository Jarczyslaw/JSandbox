using EntityFrameworkTest.DataAccess;
using EntityFrameworkTest.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<User> Users
        {
            set
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = value;
            }
        }

        public List<Group> Groups
        {
            set
            {
                dgvGroups.DataSource = null;
                dgvGroups.DataSource = value;
            }
        }

        public List<User> UsersInGroup
        {
            set
            {
                dgvUsersInGroup.DataSource = null;
                dgvUsersInGroup.DataSource = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            try
            {
                using (var db = new MyContext())
                {
                    Users = db.Users.ToList();
                    Groups = db.Groups.ToList();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void LoadUsersInGroup(Group group)
        {
            try
            {
                using (var db = new MyContext())
                {
                    UsersInGroup = db.Users
                        .Where(x => x.GroupId == group.Id)
                        .ToList();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                var selectedGroup = (Group)dgvGroups.SelectedRows[0].DataBoundItem;
                LoadUsersInGroup(selectedGroup);
            }
            else
            {
                UsersInGroup = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Group group;
                using (var db = new MyContext())
                {
                    group = db.Groups.OfType<Group>().Include(s => s.Users).First();
                }

                group.Users.Clear();

                using (var db = new MyContext())
                {
                    db.Entry(group).Collection(s => s.Users).CurrentValue = group.Users;
                    db.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}