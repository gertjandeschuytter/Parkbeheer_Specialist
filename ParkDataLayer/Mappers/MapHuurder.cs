using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers {
    public static class MapHuurder {
        public static Huurder MapToDomain(EFHuurderModel db)
        {
            try
            {
                return new Huurder(db.Id, db.Naam,
                    new Contactgegevens(db.Email, db.Telefoon, db.Adres));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDomain - Huurder - failed", ex);
            }
        }

        public static EFHuurderModel MapToDB(Huurder h)
        {
            try
            {
                return new EFHuurderModel(h.Id,h.Naam, h.Contactgegevens.Tel,
                    h.Contactgegevens.Email, h.Contactgegevens.Adres);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapToDB - Huurder - failed", ex);
            }
        }
    }
}
