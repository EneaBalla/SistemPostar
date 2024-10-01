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
    public partial class ZonaMbulimi : UserControl
    {
        public ZonaMbulimi()
        {
            InitializeComponent();
        }

        private void zonaMbulimiList_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("ZonaMbulimiList"))
            {
                ZonaMbulimiList zonaMbulimiList = new ZonaMbulimiList();
                zonaMbulimiList.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(zonaMbulimiList);
            }
            Form2.Instance.PnlContanier.Controls["ZonaMbulimiList"].BringToFront();
        }

        private void addZonaMbulimiButton_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddZonaMbulimi"))
            {
                AddZonaMbulimi addZonaMbulimi = new AddZonaMbulimi();
                addZonaMbulimi.Dock = DockStyle.Fill;
                Form2.Instance.setAddZonaMbulimi(addZonaMbulimi);
                addZonaMbulimi.clearInputs();
                addZonaMbulimi.setZonaMbulimiId(0);
                addZonaMbulimi.setCurrentZonaMbulimiStatus(1);
                Form2.Instance.PnlContanier.Controls.Add(addZonaMbulimi);
            }
            else
            {
                Form2.Instance.getAddZonaMbulimi().clearInputs();
                Form2.Instance.getAddZonaMbulimi().setZonaMbulimiId(0);
                Form2.Instance.getAddZonaMbulimi().setCurrentZonaMbulimiStatus(1);
            }
            Form2.Instance.PnlContanier.Controls["AddZonaMbulimi"].BringToFront();
        }
    }
}
