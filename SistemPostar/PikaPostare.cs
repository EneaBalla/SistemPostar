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
    public partial class PikaPostare : UserControl
    {
        public PikaPostare()
        {
            InitializeComponent();
        }

        private void usresList_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("PikaPostareList"))
            {
                PikaPostareList pikaPostareList = new PikaPostareList();
                pikaPostareList.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(pikaPostareList);
            }
            Form2.Instance.PnlContanier.Controls["PikaPostareList"].BringToFront();
        }

        private void addPikaPostareButton_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("AddPikaPostare"))
            {
                AddPikaPostare addPikaPostare = new AddPikaPostare();
                addPikaPostare.Dock = DockStyle.Fill;
                Form2.Instance.setAddPikaPostare(addPikaPostare);
                addPikaPostare.clearInputs();
                addPikaPostare.setPikePostareId(0);
                addPikaPostare.setCurrentPikePostareStatus(1);
                Form2.Instance.PnlContanier.Controls.Add(addPikaPostare);
            }
            else
            {
                Form2.Instance.getAddPikaPostare().clearInputs();
                Form2.Instance.getAddPikaPostare().setPikePostareId(0);
                Form2.Instance.getAddPikaPostare().setCurrentPikePostareStatus(1);
            }
            Form2.Instance.PnlContanier.Controls["AddPikaPostare"].BringToFront();
        }
    }
}
