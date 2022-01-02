using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBeheerDataLayer.Mappers {
    public static class MapContract {
        public static Huurcontract MapToDomain(EFHuurContractModel ef, ParkBeheerContext ctx) {
            try {
                EFHuurderModel hef = ctx.Huurders.Find(ef.HuurderId);
                EFHuisModel hx = ctx.Huizen.Find(ef.HuisId);
                return new Huurcontract(ef.Id, new Huurperiode(
                    ef.StartDatum, ef.AantalDagenVerblijf),
                    MapHuurder.MapToDomain(ef.Huurder),
                    MapHuis.MapToDomain(ef.Huis));
            }catch(Exception ex) {
                throw new MapperException("MapToDomain - HuurContract - gefaald", ex);
            }
        }

        public static List<Huurcontract> MapListToDomain(List<EFHuurContractModel> ef, ParkBeheerContext ctx)
        {
            try
            {
                var lijstMetContracten = new List<Huurcontract>();

                foreach (var item in ef)
                {
                    lijstMetContracten.Add(new(item.Id,
                    new(item.StartDatum, item.AantalDagenVerblijf), 
                    MapHuurder.MapToDomain(ctx.Huurders.Find(item.HuurderId)), 
                    MapHuis.MapToDomain(ctx.Huizen.Find(item.HuisId))));
                }
                return lijstMetContracten;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain - HuurContract - gefaald", ex);
            }
        }

        public static EFHuurContractModel MapToDB(Huurcontract h, ParkBeheerContext ctx) {
            try {
                EFHuurderModel hef = ctx.Huurders.Where(x => x.Naam == h.Huurder.Naam).FirstOrDefault();
                if(hef == null) {
                    hef = MapHuurder.MapToDB(h.Huurder);
                }

                EFHuisModel hsef = ctx.Huizen.Where(hy => hy.Nr == h.Huis.Nr && hy.Park.Id
                == h.Huis.Park.Id).FirstOrDefault();
                if(hsef == null) {
                    hsef = MapHuis.MapToDB(h.Huis, ctx);
                }

                EFParkModel pef = ctx.Parken.Where(pol => pol.Naam == h.Huis.Park.Naam).FirstOrDefault();
                if(pef == null) {
                    pef = MapPark.MapToDB(h.Huis.Park);
                }

                hsef.Park = pef;

                return new EFHuurContractModel(h.Id, h.Huurperiode.StartDatum, 
                    h.Huurperiode.EindDatum,
                    h.Huurperiode.Aantaldagen, hsef.Id, hsef, hef.Id, hef);
            }catch(Exception ex) {
                throw new MapperException("MapToDB - HuurContract", ex);
            }
        }

    }
}
