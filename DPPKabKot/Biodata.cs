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
    public partial class Biodata : Form
    {
        string passData = string.Empty;
        string passData1 = string.Empty;
        string passData2 = string.Empty;
        string passData3 = string.Empty;
        string passData4 = string.Empty;
        string Lakilaki;
        string Perempuan;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sXHdVjCFHVOnsZ6gVH7I1NH81HE7yB0a5K7jBdAy",
            BasePath = "https://dppkabkot.firebaseio.com/"
        };

        IFirebaseClient client;

        public Biodata(string sPassing, string sPassing1, string sPassing2, string sPassing3)
        {
            InitializeComponent();
            passData = sPassing;
            passData1 = sPassing1;
            passData2 = sPassing1;
            passData3 = sPassing3;
            label13.Text = sPassing;
            label14.Text = sPassing1;
            label15.Text = sPassing2;
            label16.Text = sPassing3;
           }





        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Biodata_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FirebaseResponse resp1 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahNama/");
            NoNama get1 = resp1.ResultAs<NoNama>();
            FirebaseResponse response = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahLaki/");
            GenderLaki genderLaki = response.ResultAs<GenderLaki>();
            FirebaseResponse response2 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPerempuan");
            GenderCewek genderCewek = response2.ResultAs<GenderCewek>();
            FirebaseResponse response3 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahIslam");
            Islam islam = response3.ResultAs<Islam>();
            FirebaseResponse response4 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahKristen");
            Kristen kristen = response4.ResultAs<Kristen>();
            FirebaseResponse response5 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahKatholik");
            Katholik katholik = response5.ResultAs<Katholik>();
            FirebaseResponse response6 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahHindu");
            Hindu hindu = response6.ResultAs<Hindu>();
            FirebaseResponse response7 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahBudha");
            Bundha bundha = response7.ResultAs<Bundha>();
            FirebaseResponse response8 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahKonghucu");
            Konghucu konghucu = response8.ResultAs<Konghucu>();
            FirebaseResponse response9 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPetani");
            Petani petani = response9.ResultAs<Petani>();
            FirebaseResponse response10 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahNelayan");
            Nelayan nelayan = response10.ResultAs<Nelayan>();
            FirebaseResponse response11 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPedagang");
            Pedagang pedagang = response11.ResultAs<Pedagang>();
            FirebaseResponse response12 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPTP");
            PTP pTP = response12.ResultAs<PTP>();
            FirebaseResponse response13 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSwasta");
            Swasta swasta = response13.ResultAs<Swasta>();
            FirebaseResponse response14 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahBuruh");
            Buruh buruh = response14.ResultAs<Buruh>();
            FirebaseResponse response15 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahWiraswasta");
            Wiraswasta wiraswasta = response15.ResultAs<Wiraswasta>();
            FirebaseResponse response16 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPensiunan");
            Pensiunan pensiunan = response16.ResultAs<Pensiunan>();
            FirebaseResponse response17 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPelajar");
            Pelajar pelajar = response17.ResultAs<Pelajar>();
            FirebaseResponse response18 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahTidakkerja");
            Tidakkerja tidakkerja = response18.ResultAs<Tidakkerja>();
            FirebaseResponse response19 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahTK");
            TK tK = response19.ResultAs<TK>();
            FirebaseResponse response20 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSD");
            SD sD = response20.ResultAs<SD>();
            FirebaseResponse response21 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSMP");
            SMP sMP = response21.ResultAs<SMP>();
            FirebaseResponse response22 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSMA");
            SMA sMA = response22.ResultAs<SMA>();
            FirebaseResponse response23 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS1");
            S1 s1 = response23.ResultAs<S1>();
            FirebaseResponse response24 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS2");
            S2 s2 = response24.ResultAs<S2>();
            FirebaseResponse response25 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS3");
            S3 s3 = response25.ResultAs<S3>();
            FirebaseResponse response26 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahTidaksekolah");
            Tidaksekolah tidaksekolah = response26.ResultAs<Tidaksekolah>();
            FirebaseResponse response27 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSM");
            SM sM = response27.ResultAs<SM>();
            FirebaseResponse response28 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahBM");
            BM bM = response28.ResultAs<BM>();
            FirebaseResponse response29 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPM");
            PM pM = response29.ResultAs<PM>();
            FirebaseResponse response30 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahK");
            K ks = response30.ResultAs<K>();
            FirebaseResponse response31 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS");
            S ss = response31.ResultAs<S>();
            FirebaseResponse response32 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahM");
            M ms = response32.ResultAs<M>();
            FirebaseResponse response33 = await client.GetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahIsidata");
            IsiData isiData = response33.ResultAs<IsiData>();

            var dataNama = new DataNama
            {
                Nonam = (Convert.ToInt32(get1.jmlNama) + 1).ToString(),
                Nama = textBox1.Text
            };

            var dataisi = new DataIsi
            {
                Sno = (Convert.ToInt32(isiData.jmlIsiandata) + 1).ToString(),
                Sname = textBox1.Text,
                Shp = textBox2.Text,
                Sagama = comboBox1.Text,
                Spekerjaan = comboBox2.Text,
                Spendidikan = comboBox3.Text,
                Sstatus = comboBox4.Text,
                Stanggallahirss = dateTimePicker1.Text
            };
            var laki = new Laki
            {
                SKelamin = "Laki-Laki"
            };
            var perempuan = new Perempuan
            {
                SKelamin = "Perempuan"
            };
            var pilk = new PilK
            {
                SPilihan = "K"
            };
            var pils = new PilS
            {
                SPilihan = "S"
            };
            var pilm = new PilM
            {
                SPilihan = "M"
            };

            var obj1 = new NoNama
            {
                jmlNama = dataNama.Nonam
            };

            var obj2 = new NoLaki
            {
                jmlLaki = (Convert.ToInt32(genderLaki.jmlLaki) + 1).ToString()
            };
            var obj0 = new NoIsiData
            {
                jmlIsiandata = dataisi.Sno
            };

            var obj3 = new NoCewek
            {
                jmlcewek = (Convert.ToInt32(genderCewek.jmlcewek) + 1).ToString()
            };

            var obj4 = new NoIslam
            {
                jmlIslam = (Convert.ToInt32(islam.jmlIslam) + 1).ToString()
            };
            var obj5 = new NoKristen
            {
                jmlKristen = (Convert.ToInt32(kristen.jmlKristen) + 1).ToString()
            };
            var obj6 = new NoKatholik
            {
                jmlKatholik = (Convert.ToInt32(katholik.jmlKatholik) + 1).ToString()
            };
            var obj7 = new NoHindu
            {
                jmlHindu = (Convert.ToInt32(hindu.jmlHindu) + 1).ToString()
            };
            var obj8 = new NoBudha
            {
                jmlBudha = (Convert.ToInt32(bundha.jmlBudha) + 1).ToString()
            };
            var obj9 = new NoKonghucu
            {
                jmlKonghucu = (Convert.ToInt32(konghucu.jmlKonghucu) + 1).ToString()
            };
            var obj10 = new NoPetani
            {
                jmlPetani = (Convert.ToInt32(petani.jmlPetani) + 1).ToString()
            };
            var obj11 = new NoNelayan
            {
                jmlNelayan = (Convert.ToInt32(nelayan.jmlNelayan) + 1).ToString()
            };
            var obj12 = new NoPedagang
            {
                jmlPedagang = (Convert.ToInt32(pedagang.jmlPedagang) + 1).ToString()
            };
            var obj13 = new NoPTP
            {
                jmlPTP = (Convert.ToInt32(pTP.jmlPTP) + 1).ToString()
            };
            var obj14 = new NoSwasta
            {
                jmlSwasta = (Convert.ToInt32(swasta.jmlSwasta) + 1).ToString()
            };
            var obj15 = new NoBuruh
            {
                jmlBuruh = (Convert.ToInt32(buruh.jmlburuh) + 1).ToString()
            };
            var obj16 = new NoWiraswasta
            {
                jmlWiraswasta = (Convert.ToInt32(wiraswasta.jmlWiraswasta) + 1).ToString()
            };
            var obj17 = new NoPensiunan
            {
                jmlPensiunan = (Convert.ToInt32(pensiunan.jmlPensiunan) + 1).ToString()
            };
            var obj18 = new NoPelajar
            {
                jmlPElajar = (Convert.ToInt32(pelajar.jmlpelajar) + 1).ToString()
            };
            var obj19 = new NoTidakkerja
            {
                jmlTidakkerja = (Convert.ToInt32(tidakkerja.jmlTidakkerja) + 1).ToString()
            };
            var obj20 = new NoTK
            {
                jmlTK = (Convert.ToInt32(tK.jmlTK) + 1).ToString()
            };
            var obj21 = new NoSD
            {
                jmlSD = (Convert.ToInt32(sD.jmlSD) + 1).ToString()
            };
            var obj22 = new NoSMP
            {
                jmlSMP = (Convert.ToInt32(sMP.jmlSMP) + 1).ToString()
            };
            var obj23 = new NoSMA
            {
                jmlSMA = (Convert.ToInt32(sMA.jmlSMA) + 1).ToString()
            };
            var obj24 = new NoS1
            {
                jmlS1 = (Convert.ToInt32(s1.jmlS1) + 1).ToString()
            };
            var obj25 = new NoS2
            {
                jmlS2 = (Convert.ToInt32(s2.jmlS2) + 1).ToString()
            };
            var obj26 = new NoS3
            {
                jmlS3 = (Convert.ToInt32(s3.jmlS3) + 1).ToString()
            };
            var obj27 = new NoTidaksekolah
            {
                jmlTidaksekolah = (Convert.ToInt32(tidaksekolah.jmlTidaksekolah) + 1).ToString()
            };
            var obj28 = new NoSM
            {
                jmlSM = (Convert.ToInt32(sM.jmlSM) + 1).ToString()
            };
            var obj29 = new NoBM
            {
                jmlBM = (Convert.ToInt32(bM.jmlBM) + 1).ToString()
            };
            var obj30 = new NoPM
            {
                jmlPM = (Convert.ToInt32(pM.jmlPM) + 1).ToString()
            };
            var obj31 = new NoK
            {
                jmlK = (Convert.ToInt32(ks.jmlK) + 1).ToString()
            };
            var obj32 = new NoS
            {
                jmlS = (Convert.ToInt32(ss.jmlS) + 1).ToString()
            };
            var obj33 = new NoM
            {
                jmlM = (Convert.ToInt32(ms.jmlM) + 1).ToString()
            };
            var pk = new PK
            {
                jmlK = (Convert.ToInt32(ks.jmlK) + 1).ToString()
            };
            var ps = new PS
            {
                jmlS = (Convert.ToInt32(ss.jmlS) + 1).ToString()
            };
            var pm = new Pm
            {
                jmlM = (Convert.ToInt32(ms.jmlM) + 1).ToString()
            };
            


            SetResponse resp = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Nama/" + dataNama.Nonam, dataNama);
            DataNama result1 = resp1.ResultAs<DataNama>();
            SetResponse resp3 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahNama/", obj1);

            //Isidata 
            SetResponse response34 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Data/" + dataisi.Sno, dataisi);
            DataIsi dataIsi = response34.ResultAs<DataIsi>();
            SetResponse response35 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahIsidata/", obj0);

            if (radioButton1.Checked)
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahLaki/", obj2);
                SetResponse response36 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Data/" + dataisi.Sno, laki);
                Laki laki1 = response36.ResultAs<Laki>();
            }

            else if (radioButton2.Checked)
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPerempuan/", obj3);
                SetResponse response37 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Data/" + dataisi.Sno, perempuan);
                Perempuan perempuan1 = response37.ResultAs<Perempuan>();
            }

            if (comboBox1.Text == "Islam")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahIslam/", obj4);
            }
            if (comboBox1.Text == "Kristen")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahKristen/", obj5);
            }
            if (comboBox1.Text == "Katholik")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahKatholik/", obj6);
            }
            if (comboBox1.Text == "Hindu")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahHindu/", obj7);
            }
            if (comboBox1.Text == "Budha")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahBudha/", obj8);
            }
            if (comboBox1.Text == "Konghucu")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahKonghucu/", obj9);
            }
            if (comboBox2.Text == "Petani")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPetani/", obj10);
            }
            if (comboBox2.Text == "Nelayan")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahNelayan/", obj11);
            }
            if (comboBox2.Text == "Pedagang")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPedagang/", obj12);
            }
            if (comboBox2.Text == "PNS/TNI/POLRI")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPTP/", obj13);
            }
            if (comboBox2.Text == "Pegawai Swasta")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSwasta/", obj14);
            }
            if (comboBox2.Text == "Buruh")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahBuruh/", obj15);
            }
            if (comboBox2.Text == "Wiraswasta")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahWiraswasta/", obj16);
            }
            if (comboBox2.Text == "Pensiunan")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPensiunan/", obj17);
            }
            if (comboBox2.Text == "Pelajar/Mahasiswa")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPelahar/", obj18);
            }
            if (comboBox2.Text == "Tidak Bekerja")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahTidakkerja/", obj19);
            }
            if (comboBox3.Text == "TK")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahTK/", obj20);
            }
            if (comboBox3.Text == "SD")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSD/", obj21);
            }
            if (comboBox3.Text == "SMP")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSMP/", obj22);
            }
            if (comboBox3.Text == "SMA/SMK")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSMA/", obj23);
            }
            if (comboBox3.Text == "S1")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS1/", obj24);
            }
            if (comboBox3.Text == "S2")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS2/", obj25);
            }
            if (comboBox3.Text == "S3")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS3/", obj26);
            }
            if (comboBox3.Text == "Tidak Sekolah")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahTidaksekolah/", obj27);
            }
            if (comboBox4.Text == "Sudah Menikah")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahSM/", obj28);
            }
            if (comboBox4.Text == "Belum Menikah")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahBM/", obj29);
            }
            if (comboBox4.Text == "Pernah Menikah")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahPM/", obj30);
            }

           if (comboBox5.Text == "K")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahK/", pk);
                K k = response1.ResultAs<K>();
                SetResponse response38 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Data/" + dataisi.Sno, pilk);
                Pilihank pilihank1 = response38.ResultAs<Pilihank>();
            }

            if (comboBox5.Text == "S")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahS/", ps);
                S s = response1.ResultAs<S>();
                SetResponse response39 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Data/" + dataisi.Sno, pils);
                Pilihans pilihans1 = response39.ResultAs<Pilihans>();
            }

            if (comboBox5.Text == "M")
            {
                SetResponse response1 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/JumlahM/", pm);
                M m = response1.ResultAs<M>();
                SetResponse response40 = await client.SetTaskAsync("Data User/" + label13.Text + label14.Text + label15.Text + label16.Text + "/Data/" + dataisi.Sno, pilm);
                Pilihanm pilihanm1 = response40.ResultAs<Pilihanm>();
            }
            
            this.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    internal class PK
    {
        public string jmlK { get; set; }
    }
}
