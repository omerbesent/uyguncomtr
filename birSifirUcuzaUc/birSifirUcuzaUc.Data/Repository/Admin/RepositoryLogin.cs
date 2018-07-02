using birSifirUcuzaUc.Data.Tables.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Repository.Admin
{
    public class RepositoryLogin
    {

        //public login GetMakale(string kulAdi, string pass)
        //{
        //    using (var session = Baglanti.OpenSession())
        //    {
        //        //Aşağıdaki Sorguların Hepsi Denendi Çalışıyor..

        //        //var list2 = session.QueryOver<HavayoluFirmalari>().Where(x => x.AirlineName.IsLike(name, MatchMode.Anywhere)).List();
        //        //var list3 = session.QueryOver<HavayoluFirmalari>().Where(t => t.AirlineName.IsLike("SunExpress")).List();

        //        var list = session.QueryOver<login>().Where(x => x.logKulAdi == kulAdi && x.logPass == pass).List().FirstOrDefault();

        //        return list;
        //    }
        //}

        public login KullaniciGetir(string kulAdi, string pass)
        {

            using (var session = Baglanti.OpenSession())
            {
                var list = session.QueryOver<login>().Where(x => x.logKulAdi == kulAdi && x.logPass == pass).List().FirstOrDefault();


                return list;
            }

        }

    }
}
