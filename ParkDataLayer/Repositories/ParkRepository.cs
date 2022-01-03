using Microsoft.EntityFrameworkCore;
using ParkBeheerDataLayer.Mappers;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBeheerDataLayer.Repositories {
    public class ParkRepository : IParkRepository {
        private ParkBeheerContext ctx;

        public ParkRepository(string conn)
        {
            this.ctx = new ParkBeheerContext(conn);
        }

        public Park GeefPark(string id)
        {
            try
            {
                return MapPark.MapToDomain(
                    ctx.Parken
                    .Include(h => h.Huizen)
                    .Where(x => x.Id == id)
                    .AsNoTracking()
                    .FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefPark", ex);
            }
        }
        public void UpdatePark(Park p)
        {
            try
            {
                ctx.Parken.Update(MapPark.MapToDB(p));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdatePark", ex);
            }
        }

        public void VoegParkToe(Park p)
        {
            try
            {
                EFParkModel parkje = MapPark.MapToDB(p);
                ctx.Parken.Add(parkje);
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("VoegParkToe", ex);
            }
        }


        //METHODE BEST MAKEN IN PROJECT!
        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }
    }
}
