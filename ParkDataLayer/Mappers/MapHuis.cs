using ParkBeheerDataLayer.Mappers;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers {
    public static class MapHuis {
        public static EFHuisModel MapToDB(Huis h, ParkBeheerContext ctx)
        {
            try
            {
                EFParkModel p = ctx.Parken.Where(x => x.Naam == h.Park.Naam).FirstOrDefault();
                if (p == null)
                {
                    MapPark.MapToDB(h.Park);
                }
                return new EFHuisModel(h.Id, h.Straat, h.Nr, h.Actief, p);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDB - huis - gefaald", ex);
            }
        }
        public static Huis MapToDomain(EFHuisModel db)
        {
            try
            {
                Dictionary<Huurder, List<Huurcontract>> dicContracten = new Dictionary<Huurder, List<Huurcontract>>();

                //Map over the dictionary
                foreach (var huurcontract in db.HuurContracten)
                {
                    //Herken alle waarden
                    Huurder h = new Huurder(huurcontract.HuurderId, huurcontract.Huurder.Naam,
                        new Contactgegevens(huurcontract.Huurder.Email, huurcontract.Huurder.Telefoon,
                        huurcontract.Huurder.Adres));

                    var contract = new Huurcontract(huurcontract.Id, new Huurperiode(
                        huurcontract.StartDatum, huurcontract.AantalDagenVerblijf), h, new Huis(
                            huurcontract.Huis.Id, huurcontract.Huis.Straat, huurcontract.Huis.Nr, huurcontract.Huis.Actief, new Park(
                                huurcontract.Huis.Park.Id, huurcontract.Huis.Park.Naam, huurcontract.Huis.Park.Locatie)));

                    if (!dicContracten.ContainsKey(h))
                    {
                        dicContracten.Add(h, new List<Huurcontract>() { contract });
                    }
                    else
                    {
                        dicContracten[h].Add(contract);
                    }
                }
                //Aangezien huis er nog niet is, voeg toe!
                return new Huis(db.Id, db.Straat, db.Nr, db.Actief, MapPark.MapToDomain(db.Park), dicContracten);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain - huis - failed", ex);
            }
        }
    }
}
