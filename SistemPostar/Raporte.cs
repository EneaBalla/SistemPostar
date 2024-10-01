using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPostar
{
    public partial class Raporte : UserControl
    {
        int userRole = 0;
        int userId = 0;
        public Raporte()
        {
            InitializeComponent();
        }

        public void setUserRole(int roleId)
        {
            userRole = roleId;
        }

        public void setUserId(int id)
        {
            userId = id;
        }

        public void showButtons()
        {
            shperdaresButton.Visible = false;
            transportuesButton.Visible = false;
            sportelistButton.Visible = false;
            if (userRole == Convert.ToInt32(ConfigurationManager.AppSettings["SportelistId"]))
            {
                sportelistButton.Visible = true;
            }
            if (userRole == Convert.ToInt32(ConfigurationManager.AppSettings["TransportuesId"]))
            {
                transportuesButton.Visible = true;
            }
            if (userRole == Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]))
            {
                shperdaresButton.Visible = true;
            }
            if (userRole == Convert.ToInt32(ConfigurationManager.AppSettings["AdminId"]))
            {
                sportelistButton.Visible = true;
                transportuesButton.Visible = true;
                shperdaresButton.Visible = true;
            }
        }

        private void shperdaresButton_Click(object sender, EventArgs e)
        {
            ShperndaresRaporte shperndaresRaporte;
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("ShperndaresRaporte"))
            {
                shperndaresRaporte = new ShperndaresRaporte();
                shperndaresRaporte.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(shperndaresRaporte);
            } else
            {
                shperndaresRaporte = Form2.Instance.getShperndaresRaporte();
            }
            shperndaresRaporte.setShperndaresId(userId);
            shperndaresRaporte.setShperndaresRole(userRole);
            Form2.Instance.PnlContanier.Controls["ShperndaresRaporte"].BringToFront();
        }

        private void transportuesButton_Click(object sender, EventArgs e)
        {
            TransportuesRaporte transportuesRaporte;
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("TransportuesRaporte"))
            {
                transportuesRaporte = new TransportuesRaporte();
                transportuesRaporte.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(transportuesRaporte);
            } else
            {
                transportuesRaporte = Form2.Instance.getTransportuesRaporte();
            }
            transportuesRaporte.setTransportuesId(userId);
            transportuesRaporte.setRoleId(userRole);
            Form2.Instance.PnlContanier.Controls["TransportuesRaporte"].BringToFront();
        }

        private void sportelistButton_Click(object sender, EventArgs e)
        {
            SportelistRaporte sportelistRaporte;
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("SportelistRaporte"))
            {
                sportelistRaporte = new SportelistRaporte();
                sportelistRaporte.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(sportelistRaporte);
            } else
            {
                sportelistRaporte = Form2.Instance.getSportelistRaporte();
            }
            sportelistRaporte.setSportelistId(userId);
            sportelistRaporte.setRoleId(userRole);
            Form2.Instance.PnlContanier.Controls["SportelistRaporte"].BringToFront();
        }
    }
}
