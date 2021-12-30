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
    public class BeheerHuizen
    {
        private IHuizenRepository repo;

        public BeheerHuizen(IHuizenRepository repo)
        {
            this.repo = repo;
        }

        public void VoegNieuwHuisToe(string straat,int nummer,Park park)
        {
            try
            {
                if (repo.HeeftHuis(straat, nummer, park)) throw new BeheerderException("voeghuistoe");
                Huis h = new Huis(straat,nummer, park);
                repo.VoegHuisToe(h);

            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        public void UpdateHuis(Huis huis)
        {
            try
            {
                if (!repo.HeeftHuis(huis.Id)) throw new BeheerderException("updatehuis");
                repo.UpdateHuis(huis);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        public void ArchiveerHuis(Huis huis)
        {
            try
            {
                if (!repo.HeeftHuis(huis.Id)) throw new BeheerderException("archiveerhuis");
                huis.Actief = false;
                repo.UpdateHuis(huis);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
        public Huis GeefHuis(int id)
        {
            try
            {
                return repo.GeefHuis(id);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("", ex);
            }
        }
    }
}
