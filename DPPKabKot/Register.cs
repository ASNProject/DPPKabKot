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
    public partial class Register : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sXHdVjCFHVOnsZ6gVH7I1NH81HE7yB0a5K7jBdAy",
            BasePath = "https://dppkabkot.firebaseio.com/"
        };

        IFirebaseClient client;

        public Register()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var datas = new data
            {
                user = textBox1.Text,
                provinsi = textBox2.Text,
                kabupatenkota = textBox3.Text,
                namacalon = textBox4.Text,
                namawakilcalon = textBox5.Text,
                partai = textBox6.Text,
                pilihan = comboBox1.Text,
                passwords = textBox7.Text
            };

            SetResponse response = await client.SetTaskAsync("Data User/" + textBox1.Text,datas);
            data result = response.ResultAs<data>();
            MessageBox.Show("Pendaftaran Berhasil");
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }
    }
}
