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
    public partial class Form1 : Form
    {
        
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sXHdVjCFHVOnsZ6gVH7I1NH81HE7yB0a5K7jBdAy",
            BasePath= "https://dppkabkot.firebaseio.com/"
        };

        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Data User/" + textBox1.Text + "/Akun/");

            data Obj = response.ResultAs<data>();
            
            if (textBox2.Text == Obj.passwords)
            {
                Dashboard dashboard = new Dashboard(textBox1.Text);
                dashboard.Show();
                textBox1.Text = " ";
                textBox2.Text = " ";
            }
            else
            {
                MessageBox.Show("Login gagal, Periksa Kembali Username atau Password!");
            }
        }
    }
}
