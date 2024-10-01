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
    public partial class Pako : UserControl
    {
        public Pako()
        {
            InitializeComponent();
        }

        private void addPakoButton_Click(object sender, EventArgs e)
        {
            AddPako addPako;
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddPako"))
            {
                addPako = new AddPako();
                addPako.Dock = DockStyle.Fill;
                Form2.Instance.setAddPako(addPako);
                Form2.Instance.PnlContanier.Controls.Add(addPako);
            }
            else
            {
                addPako = Form2.Instance.getAddPako();
            }
            addPako.setTransportuesId(Form2.Instance.getUserId());
            Form2.Instance.PnlContanier.Controls["AddPako"].BringToFront();
        }

        private void pakoListButton_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("PakoList"))
            {
                PakoList pakoList = new PakoList();
                pakoList.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(pakoList);
                pakoList.setTransportuesId(Form2.Instance.getUserId());
            }
            Form2.Instance.PnlContanier.Controls["PakoList"].BringToFront();
        }
    }
}
