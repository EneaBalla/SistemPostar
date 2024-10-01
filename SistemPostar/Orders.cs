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
    public partial class Orders : UserControl
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void addOrdersButton_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddOrder"))
            {
                AddOrder addOrder = new AddOrder();
                addOrder.Dock = DockStyle.Fill;
                Form2.Instance.setAddOrder(addOrder);
                addOrder.clearInputs();
                addOrder.setOrderId(0);
                addOrder.setCurrentOrderStatus(1);
                Form2.Instance.PnlContanier.Controls.Add(addOrder);
            }
            else
            {
                Form2.Instance.getAddOrder().clearInputs();
                Form2.Instance.getAddOrder().setOrderId(0);
                Form2.Instance.getAddOrder().setCurrentOrderStatus(1);
            }
            Form2.Instance.PnlContanier.Controls["AddOrder"].BringToFront();
        }
    }
}
