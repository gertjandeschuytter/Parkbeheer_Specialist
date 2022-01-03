using Microsoft.EntityFrameworkCore;
using ParkBeheerDataLayer.Mappers;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private ParkBeheerContext ctx;

        public HuizenRepositoryEF(string conn)
        {
            this.ctx = new ParkBeheerContext(conn);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public Huis GeefHuis(int id)
        {
            try
            {
                return
                    MapHuis.MapToDomain(
                    ctx.Huizen.Where(p => p.Id == id)
                    .Include(p => p.HuurContracten)
                    .ThenInclude(p => p.Huurder)
                    .Include(p => p.Park)
                    .AsNoTracking()
                    .FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuizenRepository - GeefHuis", ex);
            }
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                if (ctx.Huizen.Where(h => h.Straat == straat && h.Nr == nummer && h.Park ==
                 MapPark.MapToDB(park)).AsNoTracking().FirstOrDefault() != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuizenRepository - HeeftHuis", ex);
            }
        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return ctx.Huizen.Any(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuizenRepository - HeeftHuis", ex);
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                ctx.Huizen.Update(MapHuis.MapToDB(huis, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuizenRepository - UpdateHuis", ex);
            }
        }

        public void VoegHuisToe(Huis h)
        {
            try
            {
                ctx.Huizen.Add(MapHuis.MapToDB(h, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HuizenRepository: VoegHuisToe - gefaald", ex);
            }
        }
    }
}
