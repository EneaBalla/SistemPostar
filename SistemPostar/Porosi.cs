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
    public partial class Porosi : UserControl
    {
        public Porosi()
        {
            InitializeComponent();
        }

        private void addPorosiButton_Click(object sender, EventArgs e)
        {
            AddPorosi addPorosi;
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddPorosi"))
            {
                addPorosi = new AddPorosi();
                addPorosi.Dock = DockStyle.Fill;
                Form2.Instance.setAddPorosi(addPorosi);
                Form2.Instance.PnlContanier.Controls.Add(addPorosi);
            }
            else
            {
                addPorosi = Form2.Instance.getAddPorosi();
            }
            addPorosi.clearInputs();
            addPorosi.setPorosiId(0);
            addPorosi.setSportelistId(Form2.Instance.getUserId());
            addPorosi.LoadPrices();
            addPorosi.initializeStatusCombobox(false);
            addPorosi.saveStatus.Visible = false;
            Form2.Instance.PnlContanier.Controls["AddPorosi"].BringToFront();
        }

        private void porosiListButton_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("PorosiList"))
            {
                PorosiList porosiList = new PorosiList();
                porosiList.Dock = DockStyle.Fill;
                porosiList.setSportelistId(Form2.Instance.getUserId());
                Form2.Instance.PnlContanier.Controls.Add(porosiList);
            }
            Form2.Instance.PnlContanier.Controls["PorosiList"].BringToFront();
        }
    }
}
