using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemPostar
{
    public partial class Form2 : Form
    {
        static int userId;
        static int userRoleId;
        static Form2 instance;
        static AddUser addUserInstance;
        static AddPikaPostare addPikaPostareInstance;
        static AddZonaMbulimi addZonaMbulimiInstance;
        static AddPorosi addPorosiInstance;
        static AddPako addPakoInstance;
        static ViewPako viewPakoInstance;
        static ViewPorosi viewPorosiInstance;
        static AddRruge addRrugeInstance;
        static ShperndaresRaporte shperndaresRaporteInstance;
        static SportelistRaporte sportelistRaporteInstance;
        static TransportuesRaporte transportuesRaporteInstance;


        public static Form2 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form2();
                }
                return instance;
            }
        }

        public void setUserRoleId(int roleId)
        {
            userRoleId = roleId;
        }

        public void setUserId(int user_id)
        {
            userId = user_id;
        }

        public int getUserId()
        {
            return userId;
        }

        public int getUserRoleId()
        {
            return userRoleId;
        }

        public void setAddUser(AddUser addUser)
        {
            addUserInstance = addUser;
        }

        public AddUser getAddUser()
        {
            return addUserInstance;
        }

        public void setAddRruge(AddRruge addRruge)
        {
            addRrugeInstance = addRruge;
        }

        public AddRruge getAddRruge()
        {
            return addRrugeInstance;
        }

        public void setShperndaresRaporte(ShperndaresRaporte shperndaresRaporte)
        {
            shperndaresRaporteInstance = shperndaresRaporte;
        }

        public ShperndaresRaporte getShperndaresRaporte()
        {
            return shperndaresRaporteInstance;
        }

        public void setTransportuesRaporte(TransportuesRaporte transportuesRaporte)
        {
            transportuesRaporteInstance = transportuesRaporte;
        }

        public TransportuesRaporte getTransportuesRaporte()
        {
            return transportuesRaporteInstance;
        }

        public void setSportelistRaporte(SportelistRaporte sportelistRaporte)
        {
            sportelistRaporteInstance = sportelistRaporte;
        }

        public SportelistRaporte getSportelistRaporte()
        {
            return sportelistRaporteInstance;
        }

        public void setAddPikaPostare(AddPikaPostare addPikaPostare)
        {
            addPikaPostareInstance = addPikaPostare;
        }

        public AddPikaPostare getAddPikaPostare()
        {
            return addPikaPostareInstance;
        }

        public void setAddZonaMbulimi(AddZonaMbulimi addZonaMbulimi)
        {
            addZonaMbulimiInstance = addZonaMbulimi;
        }

        public AddZonaMbulimi getAddZonaMbulimi()
        {
            return addZonaMbulimiInstance;
        }

        public void setViewPorosi(ViewPorosi viewPorosi)
        {
            viewPorosiInstance = viewPorosi;
        }

        public ViewPorosi getViewPorosi()
        {
            return viewPorosiInstance;
        }

        public void setAddPorosi(AddPorosi addPorosi)
        {
            addPorosiInstance = addPorosi;
            if (userRoleId == Convert.ToInt32(ConfigurationManager.AppSettings["SportelistId"]))
            {
                addPorosiInstance.setSportelistId(userId);
            }
        }

        public AddPorosi getAddPorosi()
        {
            return addPorosiInstance;
        }

        public void setAddPako(AddPako addPako)
        {
            addPakoInstance = addPako;
            if (userRoleId == Convert.ToInt32(ConfigurationManager.AppSettings["TransportuesId"]) || userRoleId == Convert.ToInt32(ConfigurationManager.AppSettings["AdminId"]))
            {
                addPakoInstance.setTransportuesId(userId);
            }
        }

        public AddPako getAddPako()
        {
            return addPakoInstance;
        }

        public void setViewPako(ViewPako viewPako)
        {
            viewPakoInstance = viewPako;
        }

        public ViewPako getViewPako()
        {
            return viewPakoInstance;
        }

        public Panel PnlContanier
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["Users"].BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["PikaPostare"].BringToFront();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            instance = this;
            Users users = new Users();
            users.Dock = DockStyle.Fill;
            Default defaultScreen = new Default();
            PikaPostare pikaPostare = new PikaPostare();
            ZonaMbulimi zonaMbulimi = new ZonaMbulimi();
            Porosi porosi = new Porosi();
            Pako pako = new Pako();
            Raporte raporte = new Raporte();
            Logs logs = new Logs();
            raporte.setUserId(userId);
            raporte.setUserRole(userRoleId);
            raporte.showButtons();
            panelContainer.Controls.Add(users);
            panelContainer.Controls.Add(pikaPostare);
            panelContainer.Controls.Add(zonaMbulimi);
            panelContainer.Controls.Add(porosi);
            panelContainer.Controls.Add(pako);
            panelContainer.Controls.Add(defaultScreen);
            panelContainer.Controls.Add(raporte);
            panelContainer.Controls.Add(logs);
            panelContainer.Controls["Default"].BringToFront();
        }

        public void displayUserButtons()
        {
            int adminId = Convert.ToInt32(ConfigurationManager.AppSettings["AdminId"]);
            int transportuesId = Convert.ToInt32(ConfigurationManager.AppSettings["TransportuesId"]);
            int shperndaresId = Convert.ToInt32(ConfigurationManager.AppSettings["ShperndaresId"]);
            int sportelistId = Convert.ToInt32(ConfigurationManager.AppSettings["SportelistId"]);

            if (userRoleId == adminId)
            {
                enableAllButtons();
            }
            if (userRoleId == transportuesId)
            {
                pakoButton.Visible = true;
            }
            if (userRoleId == sportelistId)
            {
                ordersButton.Visible = true;
            }
            if (userRoleId == shperndaresId)
            {
                shperndaresButon1.Visible = true;
            }
            raporteButton.Visible = true;
            logOutButton.Visible = true;
        }

        private void enableAllButtons()
        {
            pakoButton.Visible = true;
            pikaPostareButton.Visible = true;
            zonaMbulimi.Visible = true;
            ordersButton.Visible = true;
            usersButton.Visible = true;
        }

        private void zonaMbulimi_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["ZonaMbulimi"].BringToFront();
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["Porosi"].BringToFront();
        }

        private void pakoButton_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["Pako"].BringToFront();
        }

        private void shperndaresButon_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("ShperndaresList"))
            {
                ShperndaresList shperndaresList = new ShperndaresList(Form2.Instance.getUserId());
                shperndaresList.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(shperndaresList);
            }
            Form2.Instance.PnlContanier.Controls["ShperndaresList"].BringToFront();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void shperndaresButon1_Click(object sender, EventArgs e)
        {
            if (!Form2.Instance.PnlContanier.Controls.ContainsKey("ShperndaresList"))
            {
                ShperndaresList shperndaresList = new ShperndaresList(Form2.Instance.getUserId());
                shperndaresList.Dock = DockStyle.Fill;
                Form2.Instance.PnlContanier.Controls.Add(shperndaresList);
            }
            Form2.Instance.PnlContanier.Controls["ShperndaresList"].BringToFront();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void raporteButton_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["Raporte"].BringToFront();
        }

        private void logsButton_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["Logs"].BringToFront();
        }
    }
}
