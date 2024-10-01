using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPostar
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        private void usresList_Click(object sender, EventArgs e)
        {
            if(!Form2.Instance.PnlContanier.Controls.ContainsKey("UsersList"))
            {
                UsersList usersList = new UsersList();
                usersList.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(usersList);
            }
            Form2.Instance.PnlContanier.Controls["UsersList"].BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddUser"))
            {
                AddUser addUser = new AddUser();
                addUser.Dock = DockStyle.Fill;
                Form2.Instance.setAddUser(addUser);
                addUser.clearInputs();
                addUser.setUserId(0);
                addUser.password.Enabled = true;
                addUser.setCurrentUserStatus(1);
                Form2.Instance.PnlContanier.Controls.Add(addUser);
            } else
            {
                Form2.Instance.getAddUser().password.Enabled = true;
                Form2.Instance.getAddUser().clearInputs();
                Form2.Instance.getAddUser().setUserId(0);
                Form2.Instance.getAddUser().setCurrentUserStatus(1);
            }
            Form2.Instance.PnlContanier.Controls["AddUser"].BringToFront();
        }
    }
}
