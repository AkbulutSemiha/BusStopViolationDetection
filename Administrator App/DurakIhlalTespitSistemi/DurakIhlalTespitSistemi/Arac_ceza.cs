using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakIhlalTespitSistemi
{
    public class Arac_ceza
    {
        private string arackey;
        private string plaka;
        private string yıl;
        private string ay;
        private string gun;
        private int sayac = 1;

        public void splitjson(string veri)
        {
            string[] arac = veri.Split('}');
            string[] seri2;
            string[] seri1;
            for (int i = 0; i < arac.Length; i++)
            {
                try
                {
                    seri1 = arac[i].Split('"');
                    arackey = seri1[1];
                    plaka = seri1[5];
                    ay = seri1[8];
                    gun = seri1[10];
                    seri2 = seri1[12].Split('}');
                    yıl = seri2[0];
                    using (DurakIhlalTespitiEntities1 entity = new DurakIhlalTespitiEntities1())
                    {
                        Arac_cezalı cz_arac = new Arac_cezalı();
                        cz_arac.ID = Convert.ToString(sayac);
                        cz_arac.plaka = this.Plaka;
                        cz_arac.gun = this.Gun;
                        cz_arac.ay = this.Ay;
                        cz_arac.yıl = this.Yıl;
                        entity.Arac_cezalı.Add(cz_arac);

                        entity.SaveChanges();

                    }

                }
                catch
                {

                }


                sayac++;
            }



        }
        public string Gun { get => gun; set => gun = value; }
        public string Ay { get => ay; set => ay = value; }
        public string Yıl { get => yıl; set => yıl = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string Arackey { get => arackey; set => arackey = value; }
    }
}
