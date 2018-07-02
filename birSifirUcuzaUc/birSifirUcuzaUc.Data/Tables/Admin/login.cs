using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Tables.Admin
{
    public class login
    {
        public virtual int logID { get; set; }
        public virtual string logKulAdi { get; set; }
        public virtual string logPass { get; set; }
        public virtual string logMail { get; set; }
        public virtual bool logYetkiliMi { get; set; }
    }

    public class loginMap : ClassMap<login>
    {
        public loginMap()
        {
            Id(x => x.logID);
            Map(x => x.logKulAdi);
            Map(x => x.logPass);
            Map(x => x.logMail);
            Map(x => x.logYetkiliMi); 
            Table("Login");
        }

    }
}
