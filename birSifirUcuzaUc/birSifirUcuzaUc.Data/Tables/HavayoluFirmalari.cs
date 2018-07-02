using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Tables
{
    public class HavayoluFirmalari
    {
        public virtual string AirlineCode { get; set; }
        public virtual string AirlineName { get; set; }
    }

    public class HavayoluFirmalariMap : ClassMap<HavayoluFirmalari>
    {
        public HavayoluFirmalariMap()
        {
            Id(x => x.AirlineCode);
            Map(x => x.AirlineName);
       
            Table("HavayoluFirmalari");
        }

    }
}
