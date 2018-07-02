using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birSifirUcuzaUc.Data.Tables
{
   public class airport
    {
       public virtual string AirportCode { get; set; }
       public virtual string AirportName { get; set; }
       public virtual string CountryCode { get; set; }
       public virtual string CountryName { get; set; }
       public virtual string LocalizedCountryName { get; set; }
       public virtual string CityCode { get; set; }
       public virtual string CityName { get; set; }
       public virtual string LocalizedCityName { get; set; }
       public virtual string StateCode { get; set; }
       public virtual string StateName { get; set; }
       public virtual bool IsDomesticDestination { get; set; }
       public virtual double IsActive { get; set; }
       public virtual DateTime CreatedDate { get; set; }
       public virtual double Rating { get; set; }

    }
     
   public class airportMap : ClassMap<airport>
   {
       public airportMap()
       {
           Id(x => x.AirportCode);
           Map(x => x.AirportName);
           Map(x => x.CountryCode);
           Map(x => x.CountryName);
           Map(x => x.LocalizedCountryName);
           Map(x => x.CityCode);
           Map(x => x.CityName);
           Map(x => x.LocalizedCityName);
           Map(x => x.StateCode);
           Map(x => x.StateName);
           Map(x => x.IsDomesticDestination);
           Map(x => x.IsActive);
           Map(x => x.CreatedDate);
           Map(x => x.Rating);
           Table("airport");
       }

   }
}
