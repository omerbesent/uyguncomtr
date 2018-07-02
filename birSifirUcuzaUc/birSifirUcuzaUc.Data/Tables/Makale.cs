using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Tables
{
    public class Makale
    {
        public virtual int illerID { get; set; }
        public virtual string illerKapakResim { get; set; }
        public virtual string illerMakale { get; set; }
        public virtual string illerNeredenKod { get; set; }
        public virtual string illerNereyeKod { get; set; }
        public virtual string illerNeredenAdi { get; set; }
        public virtual string illerNereyeAdi { get; set; }
        public virtual decimal illerFiyat { get; set; }
        public virtual DateTime illerTarih { get; set; }
        public virtual string illerBaslik { get; set; }
        public virtual string illerYon { get; set; }

    }


    public class MakaleMap : ClassMap<Makale>
    {
        public MakaleMap()
        {
            Id(x => x.illerID);
            Map(x => x.illerKapakResim);
            Map(x => x.illerMakale).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.illerNeredenKod);
            Map(x => x.illerNereyeKod);
            Map(x => x.illerNeredenAdi);
            Map(x => x.illerNereyeAdi);
            Map(x => x.illerFiyat);
            Map(x => x.illerTarih);
            Map(x => x.illerBaslik);
            Map(x => x.illerYon);
            Table("Makale");
        }

    }
}
