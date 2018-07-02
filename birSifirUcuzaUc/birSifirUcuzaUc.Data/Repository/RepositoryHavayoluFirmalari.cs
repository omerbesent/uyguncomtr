using birSifirUcuzaUc.Data.Tables;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Repository
{
    public class RepositoryHavayoluFirmalari
    {
        public IList<HavayoluFirmalari> havayoluKodlari(string name)
        {
            using (var session = Baglanti.OpenSession())
            {
                //Aşağıdaki Sorguların Hepsi Denendi Çalışıyor..

                //var list2 = session.QueryOver<HavayoluFirmalari>().Where(x => x.AirlineName.IsLike(name, MatchMode.Anywhere)).List();
                //var list3 = session.QueryOver<HavayoluFirmalari>().Where(t => t.AirlineName.IsLike("SunExpress")).List();

                var list = session.QueryOver<HavayoluFirmalari>().Where(t => t.AirlineName.IsLike(name)).List();

                return list;
            }
        }
 
    }
}
