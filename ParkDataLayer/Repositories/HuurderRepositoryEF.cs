using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private ParkBeheerContext ctx;

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public HuurderRepositoryEF(string conn)
        {
            this.ctx = new ParkBeheerContext(conn);
        }
        public Huurder GeefHuurder(int id)
        {
            try
            {
                return MapHuurder.MapToDomain(ctx.Huurders.Where(x => x.Id == id).AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurder", ex);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return ctx.Huurders.Select(p => MapHuurder.MapToDomain(p)).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurders", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return ctx.Huurders.Any(h => h.Naam == naam
                && h.Telefoon == contact.Tel
                && h.Email == contact.Email
                && h.Adres == contact.Adres);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder", ex);
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return ctx.Huizen.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder", ex);
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                ctx.Huurders.Update(MapHuurder.MapToDB(huurder));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateHuurder", ex);
            }
        }

        public void VoegHuurderToe(Huurder h)
        {
            try
            {
                ctx.Huurders.Add(MapHuurder.MapToDB(h));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("VoegHuurderToe", ex);
            }
        }
    }
}
