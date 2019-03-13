using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace DurakIhlalTespitSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Yetkilics yetkilim = Yetkilics.getuser;
        string yetkod;
        public string seciliislem;
        private void panel_yetkiliişlem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (yetkilim.LoginKontrol(txtBoxUserCode.Text, txtBoxUserPassword.Text) == true)
            {
                yetkilim._Yetkili_kodu = txtBoxUserCode.Text;
                yetkod = txtBoxUserCode.Text;
                panel_yetkiliişlem.Visible = true;
                groupBoxBilgiler.Visible = true;
            }

            else
            {
                MessageBox.Show("Yetkili bilgileri geçerli değil !! ", "HATA MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            txtBoxUserCode.Clear();
            txtBoxUserPassword.Clear();
        }

        private void btn_yetkiliBilgi_Click(object sender, EventArgs e)
        {
            yetkilim.YetkiliBilgi_func(yetkilim._Yetkili_kodu);
            lblAd.Text = yetkilim._Yetkili_adi;
            lblSoyad.Text = yetkilim._Yetkkili_soyadi;
            lblYetkiliKod.Text = yetkilim._Yetkili_kodu;
        }

        private void btn_bilgiGuncelle_Click(object sender, EventArgs e)
        {
            groupBoxGüncelle.Visible = true;
            groupBoxBilgiler.Visible = false;
        }

        private void btnIşlemtamamla_Click(object sender, EventArgs e)
        {

            yetkilim._Yetkili_adi = txtBoxAd.Text;
            yetkilim._Yetkkili_soyadi = txtBoxSoyad.Text;
            yetkilim._Yetkili_kodu = txtBoxKod.Text;
            yetkilim._Yetkili_parolasi = txtBoxParola.Text;
            yetkilim._Yetkili_subesi = txtBoxSube.Text;
            yetkilim.BilgileriGuncelle_func(yetkod);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Arac_ceza cezalıarac = new Arac_ceza();

            //string URL = "https://tablocezali.firebaseio.com/tablocezali/-LCFiJ0HruUzdCA0Jn_B/.json";
            //HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            //request1.ContentType = "application/json charset=utf-8";
            //HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;

            //using (Stream responsestream = response1.GetResponseStream())
            //{
            //    StreamReader read = new StreamReader(responsestream, Encoding.UTF8);
            //    var veri = read.ReadToEnd();
            //    cezalıarac.splitjson(veri);

            //    //  MessageBox.Show(cezalıarac.Plaka + cezalıarac.Gun + cezalıarac.Ay + cezalıarac.Yıl + "//" + veri.Length, "Geldimi");
            //}

        }

        private void btnKameralistesi_Click(object sender, EventArgs e)
        {
            DurakIhlalTespitiEntities1 libraryentity = new DurakIhlalTespitiEntities1();

            var kamera = from x in libraryentity.Kamera_bilgi
                         select new
                         {
                             x.Kamera_kodu,
                             x.Il,
                             x.Ilce,
                             x.Cadde,
                             x.Arıza_durum
                         };
            dataGridViewkamera.DataSource = kamera.ToList();
            dataGridViewkamera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //lblCountofuser.Text = users.Count().ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DurakIhlalTespitiEntities1 entityihlal = new DurakIhlalTespitiEntities1();

            if (radioButton_Gunluk.Checked == true)
            {
                seciliislem = "Gunluk";
                var ihlal = from p in entityihlal.Arac_cezalı
                            group p by p.gun into g
                            select new
                            {
                                Gun = g.Key,
                                İhlal_Sayısı = g.Count()
                            };
                dataGridViewSorgu.DataSource = ihlal.ToList();
                dataGridViewSorgu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewSorgu.Visible = true;
                radioButton_Gunluk.Checked = false;
            }
            else if (radioButton_Aylik.Checked == true)
            {
                seciliislem = "Aylık";
                var ihlal = from p in entityihlal.Arac_cezalı
                            group p by p.ay into g
                            select new
                            {
                                Ay = g.Key,
                                İhlal_Sayısı = g.Count()
                            };
                dataGridViewSorgu.DataSource = ihlal.ToList();
                dataGridViewSorgu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewSorgu.Visible = true;
                radioButton_Aylik.Checked = false;
            }
            else if (radioButton_Yillik.Checked == true)
            {
                seciliislem = "Yıllık";
                var ihlal = from p in entityihlal.Arac_cezalı
                            group p by p.yıl into g
                            select new
                            {
                                Yıl = g.Key,
                                İhlal_Sayısı = g.Count()
                            };
                dataGridViewSorgu.DataSource = ihlal.ToList();
                dataGridViewSorgu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewSorgu.Visible = true;
                radioButton_Yillik.Checked = false;

            }
            else
            {
                var ihlal = from tablo in entityihlal.Arac_cezalı
                            select new
                            {
                                tablo.plaka,
                                tablo.gun,
                                tablo.ay,
                                tablo.yıl

                            };
                dataGridViewSorgu.DataSource = ihlal.ToList();
                dataGridViewSorgu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewSorgu.Visible = true;
            }

        }

        private void btn_Sorgula_Click(object sender, EventArgs e)
        {

            using (DurakIhlalTespitiEntities1 database = new DurakIhlalTespitiEntities1())
            {
                var bilgi = (from b in database.Arac_cezalı
                             where b.plaka == txtBoxPlakaSorgu.Text
                             select new
                             {
                                 b.plaka,
                                 b.gun,
                                 b.ay,
                                 b.yıl
                             });

                if (bilgi == null)
                    MessageBox.Show("Plakaya ait Ceza bulunmamakta", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {

                    dataGridViewSorgu.DataSource = bilgi.ToList();
                    dataGridViewSorgu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewSorgu.Visible = true;
                }

            }
        }

        private void dataGridViewSorgu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(seciliislem== "Gunluk")
            {
                string deger = dataGridViewSorgu.CurrentRow.Cells["Gun"].Value.ToString();
                using (DurakIhlalTespitiEntities1 en = new DurakIhlalTespitiEntities1())
                {
                    var bilgiler = (from b in en.Arac_cezalı
                                    where b.gun == deger
                                    select new
                                    {
                                        b.plaka,
                                        b.gun,
                                        b.ay,
                                        b.yıl
                                    });
                    dataGridViewSecilPlaka.DataSource = bilgiler.ToList();
                    dataGridViewSecilPlaka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewSecilPlaka.Visible = true;
                    btnKapat.Visible = true;
                    PanelSeciliArac.Visible = true;
                }
            }
            else if (seciliislem == "Aylık")
            {
                string deger = dataGridViewSorgu.CurrentRow.Cells["Ay"].Value.ToString();
                using (DurakIhlalTespitiEntities1 en = new DurakIhlalTespitiEntities1())
                {
                    var bilgiler = (from b in en.Arac_cezalı
                                    where b.ay == deger
                                    select new
                                    {
                                        b.plaka,
                                        b.gun,
                                        b.ay,
                                        b.yıl
                                    });
                    dataGridViewSecilPlaka.DataSource = bilgiler.ToList();
                    dataGridViewSecilPlaka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewSecilPlaka.Visible = true;
                    btnKapat.Visible = true;
                    PanelSeciliArac.Visible = true;
                }
            }
            else if (seciliislem == "Yıllık")
            {
                string deger = dataGridViewSorgu.CurrentRow.Cells["Yıl"].Value.ToString();
                using (DurakIhlalTespitiEntities1 en = new DurakIhlalTespitiEntities1())
                {
                    var bilgiler = (from b in en.Arac_cezalı
                                    where b.yıl == deger
                                    select new
                                    {
                                        b.plaka,
                                        b.gun,
                                        b.ay,
                                        b.yıl
                                    });
                    dataGridViewSecilPlaka.DataSource = bilgiler.ToList();
                    dataGridViewSecilPlaka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewSecilPlaka.Visible = true;
                    btnKapat.Visible = true;
                    PanelSeciliArac.Visible = true;
                }
            }
            else 
            {
                string deger = dataGridViewSorgu.CurrentRow.Cells["Plaka"].Value.ToString();
                using (DurakIhlalTespitiEntities1 en = new DurakIhlalTespitiEntities1())
                {
                    var bilgiler = (from b in en.Arac_cezalı
                                    where b.plaka == deger
                                    select new
                                    {
                                        b.plaka,
                                        b.gun,
                                        b.ay,
                                        b.yıl
                                    });
                    dataGridViewSecilPlaka.DataSource = bilgiler.ToList();
                    dataGridViewSecilPlaka.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewSecilPlaka.Visible = true;
                    btnKapat.Visible = true;
                    PanelSeciliArac.Visible = true;
                }
            }

        }
       
        private void btnKapat_Click_1(object sender, EventArgs e)
        {
            PanelSeciliArac.Visible = false;
        }
    }
}
