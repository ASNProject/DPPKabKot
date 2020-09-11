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
    public partial class TambahData : Form
    {
     
        string passData = string.Empty;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sXHdVjCFHVOnsZ6gVH7I1NH81HE7yB0a5K7jBdAy",
            BasePath = "https://dppkabkot.firebaseio.com/"
        };

        IFirebaseClient client;

        public TambahData()
        {
            InitializeComponent();
        }

        public TambahData(string sPassing)
        {
            InitializeComponent();
            passData = sPassing;
            label4.Text = sPassing;
        }
        public string dariDasboard
        {
            get
            {
                return label4.Text;
            }
        }

        private void TambahData_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FirebaseResponse resp1 = await client.GetTaskAsync("Data User/" + label4.Text + "/JumlahKecamatan/");
            NoKecamatan get1 = resp1.ResultAs<NoKecamatan>();
            FirebaseResponse resp2 = await client.GetTaskAsync("Data User/" + label4.Text + "/JumlahDesa/");
            NoDesa get2 = resp2.ResultAs<NoDesa>();

            var DataKecamatan = new InTambahData
            {
                NoKec = (Convert.ToInt32(get1.jmlKecamatan)+1).ToString(),
                NamaKec = textBox1.Text
            };

            var DataDesa = new InTambahDataDesa
            {
                NoDes = (Convert.ToInt32(get2.jmlDesa)+1).ToString(),
                NamaDes = textBox2.Text
            };
            var obj2 = new NoDesa
            {
                jmlDesa = DataDesa.NoDes
            };
            var obj1 = new NoKecamatan
            {
                jmlKecamatan = DataKecamatan.NoKec
            };

            if (textBox1.Text == "")
            {
                SetResponse resp4 = await client.SetTaskAsync("Data User/" + label4.Text + "/Desa/" + DataDesa.NoDes, DataDesa);
                InTambahDataDesa result4 = resp4.ResultAs<InTambahDataDesa>();
                SetResponse resp6 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahDesa/", obj2);

            }
            else if (textBox2.Text == "")
            {
                SetResponse resp3 = await client.SetTaskAsync("Data User/" + label4.Text + "/Kecamatan/" + DataKecamatan.NoKec, DataKecamatan);
                InTambahData result3 = resp3.ResultAs<InTambahData>();
                SetResponse resp5 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahKecamatan/", obj1);
            }
            else
            {
                SetResponse resp3 = await client.SetTaskAsync("Data User/" + label4.Text + "/Kecamatan/" + DataKecamatan.NoKec, DataKecamatan);
                InTambahData result3 = resp3.ResultAs<InTambahData>();

                SetResponse resp4 = await client.SetTaskAsync("Data User/" + label4.Text + "/Desa/" + DataDesa.NoDes, DataDesa);
                InTambahDataDesa result4 = resp4.ResultAs<InTambahDataDesa>();

                SetResponse resp5 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahKecamatan/", obj1);
                SetResponse resp6 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahDesa/", obj2);
            }
            this.Close();
            Peringatan peringatan = new Peringatan();
            peringatan.Show();
        }
    }
}
