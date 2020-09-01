using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace DPPKabKot
{
    public partial class Dashboard : Form
    {
        string passData = string.Empty; 
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sXHdVjCFHVOnsZ6gVH7I1NH81HE7yB0a5K7jBdAy",
            BasePath = "https://dppkabkot.firebaseio.com/"
        };

        IFirebaseClient client;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                label4.Text = "Connected";
                label4.ForeColor = Color.Green;
            }
            else
            {
                label4.Text = "Not Connected";
                label4.ForeColor = Color.Red;
            }

        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public string dariDasboard
        {
            get
            {
                return label5.Text;
            }
        }
        public Dashboard(string sPassing)
        {
            InitializeComponent();
            passData = sPassing;
            label5.Text = sPassing;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
