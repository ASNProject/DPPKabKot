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
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        string passData = string.Empty; 
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sXHdVjCFHVOnsZ6gVH7I1NH81HE7yB0a5K7jBdAy",
            BasePath = "https://dppkabkot.firebaseio.com/"
        };

        IFirebaseClient client;
        private string a;
        public Biodata Biodata;

        public Dashboard()
        {
            InitializeComponent();
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

//            if (client != null)
  //          {
    //            label4.Text = "Connected";
      //          label4.ForeColor = Color.Green;
        //    }
          //  else
           // {
            //    label4.Text = "Not Connected";
             //   label4.ForeColor = Color.Red;
           // }

            loadkecamatan();
            loaddesa();

            dt.Columns.Add("No");
            dt.Columns.Add("Kecamatan");

            dt2.Columns.Add("No");
            dt2.Columns.Add("Desa");

            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;

            FirebaseResponse resp1 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahLaki/");
            NoLaki no = resp1.ResultAs<NoLaki>();
            FirebaseResponse response = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahPerempuan/");
            NoCewek noCewek = response.ResultAs<NoCewek>();
            FirebaseResponse response1 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahSM/");
            SM sM = response1.ResultAs<SM>();
            FirebaseResponse response2 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahBM/");
            BM bM = response2.ResultAs<BM>();
            FirebaseResponse response3 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahPM/");
            PM pM = response3.ResultAs<PM>();
            FirebaseResponse response4 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahTK/");
            TK tK = response4.ResultAs<TK>();
            FirebaseResponse response5 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahSD/");
            SD sD = response5.ResultAs<SD>();
            FirebaseResponse response6 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahSMP/");
            SMP sMP = response6.ResultAs<SMP>();
            FirebaseResponse response7 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahSMA/");
            SMA sMA = response7.ResultAs<SMA>();
            FirebaseResponse response8 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahS1/");
            S1 s1 = response8.ResultAs<S1>();
            FirebaseResponse response9 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahS2/");
            S2 s2 = response9.ResultAs<S2>();
            FirebaseResponse response10 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahS3/");
            S3 s3 = response10.ResultAs<S3>();
            FirebaseResponse response11 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahTidaksekolah/");
            Tidaksekolah tidaksekolah = response11.ResultAs<Tidaksekolah>();

            label10.Text = no.jmlLaki;
            label11.Text = noCewek.jmlcewek;
            label16.Text = pM.jmlPM;
            label17.Text = bM.jmlBM;
            label18.Text = pM.jmlPM;

            chart1.Series["Pendidikan"].IsValueShownAsLabel = true;
            chart1.Series["Pendidikan"].Points.AddXY("TK", tK.jmlTK);
            chart1.Series["Pendidikan"].Points.AddXY("SD", sD.jmlSD);
            chart1.Series["Pendidikan"].Points.AddXY("SMP", sMP.jmlSMP);
            chart1.Series["Pendidikan"].Points.AddXY("SMA/SMK", sMA.jmlSMA);
            chart1.Series["Pendidikan"].Points.AddXY("S1", s1.jmlS1);
            chart1.Series["Pendidikan"].Points.AddXY("S2", s2.jmlS2);
            chart1.Series["Pendidikan"].Points.AddXY("S3", s3.jmlS3);
            chart1.Series["Pendidikan"].Points.AddXY("Tidak Sekolah", tidaksekolah.jmlTidaksekolah);
           
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
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

        public async void loadkecamatan()
        {
           int i = 0;
            FirebaseResponse respons1 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahKecamatan/");
            NoKecamatan obj1 = respons1.ResultAs<NoKecamatan>();
            int jumlahkecamatans = Convert.ToInt32(obj1.jmlKecamatan);

            while (true)
            {
                if (i == jumlahkecamatans)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse respose2 = await client.GetTaskAsync("Data User/" + label5.Text + "/Kecamatan/" + i);
                    InTambahData obj2 = respose2.ResultAs<InTambahData>();

                    DataRow row = dt.NewRow();
                    row["No"] = obj2.NoKec;
                    row["Kecamatan"] = obj2.NamaKec;

                    dt.Rows.Add(row);
                    //FirebaseResponse response = client.Get("Data User/" + label5.Text + "/Data Kecamatan/");
                    //Dictionary<String, data> getdata = response.ResultAs<Dictionary<String, data>>();

                    //foreach (var get in getdata)
                    // {
                    // dataGridView1.Rows.Add(
                    //       get.Value.NoKec,
                    //   get.Value.Nama
                    //  );
                    // }
                }
                catch
                {
                    MessageBox.Show("No Data Stored");
                }
            } 
           
        }
        public async void loaddesa()
        {
            int a = 0;
            FirebaseResponse respons3 = await client.GetTaskAsync("Data User/" + label5.Text + "/JumlahDesa/");
            NoDesa obj3 = respons3.ResultAs<NoDesa>();
            int jumlahdesa = Convert.ToInt32(obj3.jmlDesa);

            while (true)
            {
                if (a == jumlahdesa)
                {
                    break;
                }
                a++;
                try
                {
                    FirebaseResponse respose2 = await client.GetTaskAsync("Data User/" + label5.Text + "/Desa/" + a);
                    InTambahDataDesa obj2 = respose2.ResultAs<InTambahDataDesa>();

                    DataRow row = dt2.NewRow();
                    row["No"] = obj2.NoDes;
                    row["Desa"] = obj2.NamaDes;
                    dt2.Rows.Add(row);
                    //FirebaseResponse response = client.Get("Data User/" + label5.Text + "/Data Kecamatan/");
                    //Dictionary<String, data> getdata = response.ResultAs<Dictionary<String, data>>();

                    //foreach (var get in getdata)
                    // {
                    // dataGridView1.Rows.Add(
                    //       get.Value.NoKec,
                    //   get.Value.Nama
                    //  );
                    // }
                }
                catch
                {
                    MessageBox.Show("No Data Stored");
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TambahData tambahData = new TambahData(label5.Text);
            tambahData.Show();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
                label4.Text = "Connected";
                label4.ForeColor = Color.Green;
                DataRow row = dt2.NewRow();
                dt2.Rows.InsertAt(row, 0);
                comboBox2.ValueMember = "No";
                comboBox2.DisplayMember = "Desa";
                comboBox2.DataSource = dt2;
                DataRow row1 = dt.NewRow();
                dt.Rows.InsertAt(row1, 0);
                comboBox1.ValueMember = "No";
                comboBox1.DisplayMember = "Kecamatan";
                comboBox1.DataSource = dt;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Silahkan pilih Kecamatan!");
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Silahkan pilih Desa/Kelurahan!");
            }
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Silahkan pilih TPS!");
            }
            else
            {
                Biodata bio = new Biodata(label5.Text);
                bio.Show();
            }
        }
    }
}
