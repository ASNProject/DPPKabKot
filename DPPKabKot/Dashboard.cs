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

            loadkecamatan();
            loaddesa();

            dt.Columns.Add("No");
            dt.Columns.Add("Kecamatan");

            dt2.Columns.Add("No");
            dt2.Columns.Add("Desa");

            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt2;
  
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
        Biodata biodata;
        public Dashboard(Biodata _biodata)
        {
            InitializeComponent();
            this.biodata = _biodata;
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
            FirebaseResponse respons1 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahKecamatan/");
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
                    FirebaseResponse respose2 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/Kecamatan/" + i);
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
            FirebaseResponse respons3 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahDesa/");
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
                    FirebaseResponse respose2 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/Desa/" + a);
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
                Biodata bio = new Biodata(label5.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text);
                bio.Show();
                
            }
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
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
                
                FirebaseResponse resp1 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahLaki/");
                NoLaki no = resp1.ResultAs<NoLaki>();
                FirebaseResponse response = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPerempuan/");
                NoCewek noCewek = response.ResultAs<NoCewek>();
                FirebaseResponse response1 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahSM/");
                SM sM = response1.ResultAs<SM>();
                FirebaseResponse response2 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahBM/");
                BM bM = response2.ResultAs<BM>();
                FirebaseResponse response3 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPM/");
                PM pM = response3.ResultAs<PM>();
                FirebaseResponse response4 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahTK/");
                TK tK = response4.ResultAs<TK>();
                FirebaseResponse response5 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahSD/");
                SD sD = response5.ResultAs<SD>();
                FirebaseResponse response6 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahSMP/");
                SMP sMP = response6.ResultAs<SMP>();
                FirebaseResponse response7 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahSMA/");
                SMA sMA = response7.ResultAs<SMA>();
                FirebaseResponse response8 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahS1/");
                S1 s1 = response8.ResultAs<S1>();
                FirebaseResponse response9 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahS2/");
                S2 s2 = response9.ResultAs<S2>();
                FirebaseResponse response10 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahS3/");
                S3 s3 = response10.ResultAs<S3>();
                FirebaseResponse response11 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahTidaksekolah/");
                Tidaksekolah tidaksekolah = response11.ResultAs<Tidaksekolah>();
                FirebaseResponse response12 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahKK/");
                KKs kKs = response12.ResultAs<KKs>();
                FirebaseResponse response13 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahIslam/");
                Islam islam = response13.ResultAs<Islam>();
                FirebaseResponse response14 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahKristen/");
                Kristen kristen = response14.ResultAs<Kristen>();
                FirebaseResponse response15 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahKatholik/");
                Katholik katholik = response15.ResultAs<Katholik>();
                FirebaseResponse response16 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahBudha/");
                Bundha bundha = response16.ResultAs<Bundha>();
                FirebaseResponse response17 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahHindu/");
                Hindu hindu = response17.ResultAs<Hindu>();
                FirebaseResponse response18 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahKonghucu/");
                Konghucu konghucu = response18.ResultAs<Konghucu>();
                FirebaseResponse response19 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPetani/");
                Petani petani = response19.ResultAs<Petani>();
                FirebaseResponse response20 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahNelayan/");
                Nelayan nelayan = response20.ResultAs<Nelayan>();
                FirebaseResponse response21 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPedagang/");
                Pedagang pedagang = response21.ResultAs<Pedagang>();
                FirebaseResponse response22 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPTP/");
                PTP pTP = response22.ResultAs<PTP>();
                FirebaseResponse response23 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahSwasta/");
                Swasta swasta = response23.ResultAs<Swasta>();
                FirebaseResponse response24 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahBuruh/");
                Buruh buruh = response24.ResultAs<Buruh>();
                FirebaseResponse response25 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahWiraswasta/");
                Wiraswasta wiraswasta = response25.ResultAs<Wiraswasta>();
                FirebaseResponse response26 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPensiunan/");
                Pensiunan pensiunan = response26.ResultAs<Pensiunan>();
                FirebaseResponse response27 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahPelajar/");
                Pelajar pelajar = response27.ResultAs<Pelajar>();
                FirebaseResponse response28 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahTidakkerja/");
                Tidakkerja tidakkerja = response28.ResultAs<Tidakkerja>();
                FirebaseResponse response29 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahK/");
                K k = response29.ResultAs<K>();
                FirebaseResponse response30 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahS/");
                S s = response30.ResultAs<S>();
                FirebaseResponse response31 = await client.GetTaskAsync("Data User/" + label5.Text + comboBox1.Text + comboBox2.Text + comboBox3.Text + "/JumlahM/");
                M m = response31.ResultAs<M>();

                label10.Text = no.jmlLaki;
                label11.Text = noCewek.jmlcewek;
                label16.Text = pM.jmlPM;
                label17.Text = bM.jmlBM;
                label18.Text = pM.jmlPM;
                label20.Text = kKs.jmlkk;
                label25.Text = islam.jmlIslam;
                label26.Text = kristen.jmlKristen;
                label27.Text = katholik.jmlKatholik;
                label28.Text = bundha.jmlBudha;
                label29.Text = hindu.jmlHindu;
                label30.Text = konghucu.jmlKonghucu;
                label41.Text = petani.jmlPetani;
                label42.Text = nelayan.jmlNelayan;
                label43.Text = pedagang.jmlPedagang;
                label44.Text = pTP.jmlPTP;
                label45.Text = swasta.jmlSwasta;
                label46.Text = buruh.jmlburuh;
                label47.Text = wiraswasta.jmlWiraswasta;
                label48.Text = pensiunan.jmlPensiunan;
                label49.Text = pelajar.jmlpelajar;
                label50.Text = tidakkerja.jmlTidakkerja;

                chart1.Series["Pendidikan"].Points.Clear();
                chart1.Series["Pendidikan"].IsValueShownAsLabel = true;
                chart1.Series["Pendidikan"].Points.AddXY("TK", tK.jmlTK);
                chart1.Series["Pendidikan"].Points.AddXY("SD", sD.jmlSD);
                chart1.Series["Pendidikan"].Points.AddXY("SMP", sMP.jmlSMP);
                chart1.Series["Pendidikan"].Points.AddXY("SMA/SMK", sMA.jmlSMA);
                chart1.Series["Pendidikan"].Points.AddXY("S1", s1.jmlS1);
                chart1.Series["Pendidikan"].Points.AddXY("S2", s2.jmlS2);
                chart1.Series["Pendidikan"].Points.AddXY("S3", s3.jmlS3);
                chart1.Series["Pendidikan"].Points.AddXY("Tidak Sekolah", tidaksekolah.jmlTidaksekolah);

                chart2.Series["K"].Points.Clear();
                chart2.Series["K"].IsValueShownAsLabel = true;
                chart2.Series["K"].Points.AddXY("K", k.jmlK);
                chart2.Series["S"].Points.AddXY("S", s.jmlS);
                chart2.Series["M"].Points.AddXY("M", m.jmlM);

            }
        }
    }
}
