using ParkBusinessLayer.Exceptions;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Beheerders
{
    public class BeheerHuurders
    {
        private IHuurderRepository repo;

        public BeheerHuurders(IHuurderRepository repo)
        {
            this.repo = repo;
        }

        public void VoegNieuweHuurderToe(string Naam,Contactgegevens contact)
        {
            try
            {
                if (repo.HeeftHuurder(Naam, contact)) throw new BeheerderException("huurder bestaat al");
                Huurder h = new Huurder(Naam, contact);
                repo.VoegHuurderToe(h);
            }
            catch(Exception ex)
            {
                throw new BeheerderException("nieuwe huurder", ex);
            }
        }
        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                if (!repo.HeeftHuurder(huurder.Id)) throw new BeheerderException("huurder bestaat niet");
                repo.UpdateHuurder(huurder);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("updatehuurder", ex);
            }
        }
        public Huurder GeefHuurder(int id)
        {
            try
            {
                return repo.GeefHuurder(id);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("geefhuurder", ex);
            }
        }
        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return repo.GeefHuurders(naam);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("geefhuurders", ex);
            }
        }
    }
}
