using EFRemoveManyToManyDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFRemoveManyToManyDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Query();
        }

        private  void Query()
        {
            using (var cxt = new ManyToManyRemoveContext())
            {
                var users = cxt.Users.ToList();
                users.ForEach(x =>
                {
                    Console.WriteLine("User First Name:{0},Last Name:{1},Create On:{2}\n |__Roles:{3}", x.FirstName, x.LastName, x.CreatedOn, string.Join(",", x.Roles.Select(r => r.Name)));
                });
            }
        }

        private void  Update()
        {
            using (var cxt = new ManyToManyRemoveContext())
            {
                var user = cxt.Users.FirstOrDefault(x => x.LastName.ToString().ToUpper()=="LIN");
                user.FirstName = "ShuHao";
                cxt.SaveChanges();
            }
        }

        private void Remove()
        {
            using (var cxt = new ManyToManyRemoveContext())
            {
                var user = cxt.Users.FirstOrDefault(x => x.LastName.ToString().ToUpper() == "LIN");
                cxt.Users.Remove(user);
                cxt.SaveChanges();
            }
        }

        private void Add()
        {
            List<Role> roles;
            using (var cxt = new ManyToManyRemoveContext())
            {
                roles = cxt.Roles.ToList();
                cxt.Users.Add(new User
                {
                    Id = 3,
                    FirstName = "jerimy",
                    LastName = "Lin",
                    CreatedOn = DateTime.Now,
                    Roles = roles.Where(x => x.Name=="管理员").ToList()
                });
                cxt.SaveChanges();
            }
        }

        private void RemoveManyToMany()
        {
            using (var cxt = new ManyToManyRemoveContext())
            {
                var user = cxt.Users.FirstOrDefault(x => x.LastName.ToString().ToUpper() == "LIN");
                var roles = new List<Role>();
                roles.AddRange(user.Roles.Select(x => x));
                foreach (var role in roles)
                {
                    user.Roles.Remove(role);
                }
                cxt.Users.Remove(user);
                cxt.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveManyToMany();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var cxt = new ManyToManyRemoveContext())
            {
                List<User> User_List = cxt.Users.ToList();

                foreach (var item in User_List)
                {
                    cxt.Users.Remove(item);
                }

                List<Role> Role_List = cxt.Roles.ToList();

                foreach (var item in Role_List)
                {
                    cxt.Roles.Remove(item);
                }

                cxt.SaveChanges();
            }
        }
    }
}
