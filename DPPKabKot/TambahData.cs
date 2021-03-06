﻿using System;
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
                InTambahDataDesa re4 = resp4.ResultAs<InTambahDataDesa>();
                SetResponse resp6 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahDesa/", obj2);

            }
            else if (textBox2.Text == "")
            {
                SetResponse resp3 = await client.SetTaskAsync("Data User/" + label4.Text + "/Kecamatan/" + DataKecamatan.NoKec, DataKecamatan);
                InTambahData res3 = resp3.ResultAs<InTambahData>();
                SetResponse resp5 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahKecamatan/", obj1);
            }
            else
            {
                SetResponse resp3 = await client.SetTaskAsync("Data User/" + label4.Text + "/Kecamatan/" + DataKecamatan.NoKec, DataKecamatan);
                InTambahData re3 = resp3.ResultAs<InTambahData>();

                SetResponse resp4 = await client.SetTaskAsync("Data User/" + label4.Text + "/Desa/" + DataDesa.NoDes, DataDesa);
                InTambahDataDesa res4 = resp4.ResultAs<InTambahDataDesa>();

                SetResponse resp5 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahKecamatan/", obj1);
                SetResponse resp6 = await client.SetTaskAsync("Data User/" + label4.Text + "/JumlahDesa/", obj2);
            }

            var isidata = new IsiData
            {
                jmlIsiandata = "0"
            };

            var kec = new NoKecamatan
            {
                jmlKecamatan = "0"
            };

            var des = new NoDesa
            {
                jmlDesa = "0"
            };

            var nam = new NoNama
            {
                jmlNama = "0"
            };

            var genderlaki = new GenderLaki
            {
                jmlLaki = "0"
            };
            var gendercewek = new GenderCewek
            {
                jmlcewek = "0"
            };
            var islam = new Islam
            {
                jmlIslam = "0"
            };
            var kristen = new Kristen
            {
                jmlKristen = "0"
            };
            var katholik = new Katholik
            {
                jmlKatholik = "0"
            };
            var hindu = new Hindu
            {
                jmlHindu = "0"
            };
            var budha = new Bundha
            {
                jmlBudha = "0"
            };
            var konghucu = new Konghucu
            {
                jmlKonghucu = "0"
            };
            var petani = new Petani
            {
                jmlPetani = "0"
            };
            var nelayan = new Nelayan
            {
                jmlNelayan = "0"
            };
            var pedagang = new Pedagang
            {
                jmlPedagang = "0"
            };
            var ptp = new PTP
            {
                jmlPTP = "0"
            };
            var swasta = new Swasta
            {
                jmlSwasta = "0"
            };
            var buruh = new Buruh
            {
                jmlburuh = "0"
            };
            var wiraswasta = new Wiraswasta
            {
                jmlWiraswasta = "0"
            };
            var pensiunan = new Pensiunan
            {
                jmlPensiunan = "0"
            };
            var pelajar = new Pelajar
            {
                jmlpelajar = "0"
            };
            var tidakkerja = new Tidakkerja
            {
                jmlTidakkerja = "0"
            };
            var tk = new TK
            {
                jmlTK = "0"
            };
            var sd = new SD
            {
                jmlSD = "0"
            };
            var smp = new SMP
            {
                jmlSMP = "0"
            };
            var sma = new SMA
            {
                jmlSMA = "0"
            };
            var s1 = new S1
            {
                jmlS1 = "0"
            };
            var s2 = new S2
            {
                jmlS2 = "0"
            };
            var s3 = new S3
            {
                jmlS3 = "0"
            };
            var tidaksekolah = new Tidaksekolah
            {
                jmlTidaksekolah = "0"
            };
            var sm = new SM
            {
                jmlSM = "0"
            };
            var bm = new BM
            {
                jmlBM = "0"
            };
            var pm = new PM
            {
                jmlPM = "0"
            };
            var k = new K
            {
                jmlK = "0"
            };
            var s = new S
            {
                jmlS = "0"
            };
            var m = new M
            {
                jmlM = "0"
            };
            var kk = new KKs
            {
                jmlkk = textBox3.Text
            };


            SetResponse response0 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahKK/", kk);
            data result0 = response0.ResultAs<data>();
            SetResponse response1 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahKecamatan/", kec);
            data result1 = response1.ResultAs<data>();
            SetResponse response2 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahDesa/", des);
            data result2 = response2.ResultAs<data>();
            SetResponse response3 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahNama/", nam);
            NoNama result3 = response3.ResultAs<NoNama>();
            SetResponse response4 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahLaki/", genderlaki);
            GenderLaki result4 = response4.ResultAs<GenderLaki>();
            SetResponse response5 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPerempuan/", gendercewek);
            GenderCewek result5 = response5.ResultAs<GenderCewek>();
            SetResponse response6 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahIslam/", islam);
            Islam islam1 = response6.ResultAs<Islam>();
            SetResponse response7 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahKristen/", kristen);
            Kristen kristen1 = response7.ResultAs<Kristen>();
            SetResponse response8 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahKatholik/", katholik);
            Katholik katholik1 = response8.ResultAs<Katholik>();
            SetResponse response9 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahHindu/", hindu);
            Hindu hindu1 = response9.ResultAs<Hindu>();
            SetResponse response10 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahBudha/", budha);
            Bundha bundha = response10.ResultAs<Bundha>();
            SetResponse response11 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahKonghucu/", konghucu);
            Konghucu konghucu1 = response11.ResultAs<Konghucu>();
            SetResponse response12 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPetani/", petani);
            Petani petani1 = response12.ResultAs<Petani>();
            SetResponse response13 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahNelayan/", nelayan);
            Nelayan nelayan1 = response13.ResultAs<Nelayan>();
            SetResponse response14 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPedagang/", pedagang);
            Pedagang pedagang1 = response14.ResultAs<Pedagang>();
            SetResponse response15 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPTP/", ptp);
            PTP pTP = response15.ResultAs<PTP>();
            SetResponse response16 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahSwasta/", swasta);
            Swasta swasta1 = response16.ResultAs<Swasta>();
            SetResponse response17 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahBuruh/", buruh);
            Buruh buruh1 = response17.ResultAs<Buruh>();
            SetResponse response18 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahWiraswasta/", wiraswasta);
            Wiraswasta wiraswasta1 = response18.ResultAs<Wiraswasta>();
            SetResponse response19 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPensiunan/", pensiunan);
            Pensiunan pensiunan1 = response19.ResultAs<Pensiunan>();
            SetResponse response20 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPelajar/", pelajar);
            Pelajar pelajar1 = response20.ResultAs<Pelajar>();
            SetResponse response21 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahTidakkerja/", tidakkerja);
            Tidakkerja tidakkerja1 = response21.ResultAs<Tidakkerja>();
            SetResponse response22 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahTK/", tk);
            TK tK = response22.ResultAs<TK>();
            SetResponse response23 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahSD/", sd);
            SD sD = response23.ResultAs<SD>();
            SetResponse response24 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahSMP/", smp);
            SMP sMP = response24.ResultAs<SMP>();
            SetResponse response25 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahSMA/", sma);
            SMA sMA = response25.ResultAs<SMA>();
            SetResponse response26 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahS1/", s1);
            S1 s11 = response26.ResultAs<S1>();
            SetResponse response27 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahS2/", s2);
            S2 s21 = response27.ResultAs<S2>();
            SetResponse response28 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahS3/", s3);
            S3 s31 = response28.ResultAs<S3>();
            SetResponse response29 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahTidaksekolah/", tidaksekolah);
            Tidaksekolah tidaksekolah1 = response29.ResultAs<Tidaksekolah>();
            SetResponse response30 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahSM/", sm);
            SM sM = response30.ResultAs<SM>();
            SetResponse response31 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahBM/", bm);
            BM bM = response31.ResultAs<BM>();
            SetResponse response32 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahPM/", pm);
            PM pM = response32.ResultAs<PM>();
            SetResponse response33 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahK/", k);
            K ks = response33.ResultAs<K>();
            SetResponse response34 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahS/", s);
            S ss = response34.ResultAs<S>();
            SetResponse response35 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahM/", m);
            M ms = response35.ResultAs<M>();
            SetResponse response36 = await client.SetTaskAsync("Data User/" + label4.Text + textBox1.Text + textBox2.Text + comboBox1.Text + "/JumlahIsidata", isidata);

            this.Close();
            Peringatan peringatan = new Peringatan();
            peringatan.Show();
        }
    }
}
