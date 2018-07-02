using birSifirUcuzaUc.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Repository
{
    public class RepositoryAirport
    {

        public List<airport> list()
        {
            using (var session = Baglanti.OpenSession())
            {
                var list = session.QueryOver<airport>().List<airport>().ToList();

                return list;
            }
        }

        public List<airport> customList(string sql)
        {
            using (var session = Baglanti.OpenSession())
            {
                //var query =
                //       session.CreateSQLQuery(sql)
                //           .AddEntity("airport", typeof(airport))
                //           .List<airport>();
                sql = "EXEC TR_AIRPORT_LIST '" + sql + "'";
                var query =
                     session.CreateSQLQuery(sql)
                         .AddEntity("airport", typeof(airport))
                         .List<airport>();

                return query.ToList();
            }
        }


        public List<airport> customList2(string sql)
        {
            //Procedur
            using (var session = Baglanti.OpenSession())
            {
                var sql2 = "EXEC TR_AIRPORT_LIST 'IST' ";
                //session.CreateSQLQuery("EXEC TR_AIRPORT_LIST @StrValue = N'" + sql + "'").executeUpdate();
                //.AddEntity("airport", typeof(airport))
                //.List<airport>();

                //return query.ToList();

                var query =
                     session.CreateSQLQuery(sql2)
                         .AddEntity("airport", typeof(airport))
                         .List<airport>();

                return query.ToList();
            }
        }

        public IList<airport> ulkeKodu(string code)
        {
            using (var session = Baglanti.OpenSession())
            {
                //Aşağıdaki Sorguların Hepsi Denendi Çalışıyor..

                //var list3 = session.QueryOver<airport>().Where(t => t.AirportCode.Equals("SAW")).List();

                //equals Kullanılmıyor..!
                //var list = session.QueryOver<airport>().Where(t => t.AirportCode.Equals(code)).List();
                var list = session.QueryOver<airport>().Where(p => p.AirportCode == code || p.CityCode == code).List();

                return list;
            }
        }


    }
}
