using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakIhlalTespitSistemi
{
    public class Yetkilics
    {
        private string yetkili_kodu;
        private string yetkili_adi;
        private string yetkkili_soyadi;
        private string yetkili_parolasi;
        private string yetkili_subesi;
        private static Object _object = new Object();
        private static Yetkilics myyetkili;
        private Yetkilics() { }
        public static Yetkilics getuser
        {
            get
            {
                lock (_object)
                {
                    return myyetkili ?? new Yetkilics();
                }
            }
        }

        public string _Yetkili_adi { get => yetkili_adi; set => yetkili_adi = value; }
        public string _Yetkkili_soyadi { get => yetkkili_soyadi; set => yetkkili_soyadi = value; }
        public string _Yetkili_parolasi { get => yetkili_parolasi; set => yetkili_parolasi = value; }
        public string _Yetkili_subesi { get => yetkili_subesi; set => yetkili_subesi = value; }
        public string _Yetkili_kodu { get => yetkili_kodu; set => yetkili_kodu = value; }

        public void YetkiliBilgi_func(string yetkilikod)
        {
            using (DurakIhlalTespitiEntities1 database = new DurakIhlalTespitiEntities1())
            {
                var bilgi = (from b in database.Yetkili_Bilgi
                             where b.Yetkili_kodu == yetkilikod
                             select b).FirstOrDefault();
                yetkili_adi = bilgi.Yetkili_adı;
                yetkkili_soyadi = bilgi.Yetkili_soyad;
                yetkili_subesi = bilgi.Yetkili_sube;
                yetkili_parolasi = bilgi.Yetkili_parola;
                yetkili_kodu = bilgi.Yetkili_kodu;
            }
        }

        public void BilgileriGuncelle_func(string y_kod)
        {
            using (DurakIhlalTespitiEntities1 ctx = new DurakIhlalTespitiEntities1())
            {
                var yetkiliGuncelle = (from s in ctx.Yetkili_Bilgi
                                       where s.Yetkili_kodu == y_kod
                                       select s).FirstOrDefault();
                yetkiliGuncelle.Yetkili_adı = _Yetkili_adi;
                yetkiliGuncelle.Yetkili_soyad = _Yetkkili_soyadi;
                yetkiliGuncelle.Yetkili_kodu = _Yetkili_kodu;
                yetkiliGuncelle.Yetkili_parola = _Yetkili_parolasi;
                yetkiliGuncelle.Yetkili_sube = _Yetkili_subesi;
                ctx.SaveChanges();
            }
        }
        public bool LoginKontrol(string yetkiliKod, string parola_)
        {
            using (DurakIhlalTespitiEntities1 entity = new DurakIhlalTespitiEntities1())
            {
                foreach (var x in entity.Yetkili_Bilgi)
                {
                    if (x.Yetkili_kodu == yetkiliKod && x.Yetkili_parola == parola_)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
