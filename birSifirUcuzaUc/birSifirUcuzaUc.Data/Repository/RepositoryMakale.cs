using birSifirUcuzaUc.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Repository
{
    public class RepositoryMakale
    {
        public IList<Makale> Makaleler()
        {
            using (var session = Baglanti.OpenSession())
            {
                //Aşağıdaki Sorguların Hepsi Denendi Çalışıyor..

                //var list2 = session.QueryOver<HavayoluFirmalari>().Where(x => x.AirlineName.IsLike(name, MatchMode.Anywhere)).List();
                //var list3 = session.QueryOver<HavayoluFirmalari>().Where(t => t.AirlineName.IsLike("SunExpress")).List();

                var list = session.QueryOver<Makale>().List();

                return list;
            }
        }

        public Makale GetMakale(int id)
        {
            using (var session = Baglanti.OpenSession())
            {
                //Aşağıdaki Sorguların Hepsi Denendi Çalışıyor..

                //var list2 = session.QueryOver<HavayoluFirmalari>().Where(x => x.AirlineName.IsLike(name, MatchMode.Anywhere)).List();
                //var list3 = session.QueryOver<HavayoluFirmalari>().Where(t => t.AirlineName.IsLike("SunExpress")).List();

                var list = session.QueryOver<Makale>().Where(x => x.illerID == id).List().FirstOrDefault();

                return list;
            }
        }

        public Makale Makaleler(int id)
        {
            using (var session = Baglanti.OpenSession())
            {
                //Aşağıdaki Sorguların Hepsi Denendi Çalışıyor..

                //var list2 = session.QueryOver<HavayoluFirmalari>().Where(x => x.AirlineName.IsLike(name, MatchMode.Anywhere)).List();
                //var list3 = session.QueryOver<HavayoluFirmalari>().Where(t => t.AirlineName.IsLike("SunExpress")).List();

                var list = session.QueryOver<Makale>().Where(x => x.illerID == id).SingleOrDefault();

                return list;
            }
        }

        public bool Save(Makale makale)
        {
            try
            {
                using (var session = Baglanti.OpenSession())
                {
                    session.Save(makale);
                    // sıradan commit
                    session.Flush();

                    return true;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public bool Update(Makale makale)
        {
            try
            {
                using (var session = Baglanti.OpenSession())
                {
                    session.Update(makale);
                    // sıradan commit
                    session.Flush();

                    return true;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public bool Sil(int makaleId)
        {
            try
            {
                using (var session = Baglanti.OpenSession())
                {
                    var makale = session.QueryOver<Makale>().Where(x => x.illerID == makaleId).List().FirstOrDefault();
                    session.Delete(makale);
                    // sıradan commit
                    session.Flush();

                    return true;
                }
            }
            catch (Exception exc)
            {
                return false;
            }
        }

    }
}
