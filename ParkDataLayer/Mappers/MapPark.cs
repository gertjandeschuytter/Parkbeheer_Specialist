using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBeheerDataLayer.Mappers {
    public class MapPark {


        public static Park MapToDomain(EFParkModel dbObject)
        {
            try
            {
                Park park = new Park(dbObject.Id, dbObject.Naam, dbObject.Locatie);
                if (dbObject.Huizen.Count > 0)
                {
                    foreach (var huis in dbObject.Huizen)
                    {
                        Huis Huisje = new(huis.Straat, huis.Nr, park);
                        Huisje.ZetId(huis.Id);
                        park.VoegHuisToe(Huisje);
                    }
                }
                return park;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain - Park - failed", ex);
            }
        }


        public static EFParkModel MapToDB(Park h) {
            try {
                return new EFParkModel(h.Id, h.Naam, h.Locatie);
            }
            catch (Exception ex) {
                throw new MapperException("MapToDB - ParkEF - gefaald", ex);
            }
        }
    }
}
