using birSifirUcuzaUc.Data.Tables;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data
{
    public class Baglanti
    {
        public static ISession OpenSession()
        {
            string connectionString = @"server=.;database=birSifirUcuzaUc;uid=sa;password=123456a.A;";
            //string connectionString = @"server=hostsql1.isimtescil.net,1433;database=poyun-Cw_makine;uid=poyun-Cw_oyuncu;password=s1s2s3S4;";
            var sessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(connectionString).ShowSql()
                 )
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<airport>())
                 .ExposeConfiguration(cfg => new SchemaExport(cfg)
                 .Create(false, false))
                 .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
