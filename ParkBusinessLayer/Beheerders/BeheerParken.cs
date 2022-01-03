using ParkBusinessLayer.Exceptions;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBeheerBussinesLayer.Beheerders {
    public class BeheerParken : IParkRepository {


        private IParkRepository repo;

        public BeheerParken(IParkRepository p)
        {
            this.repo = p;
        }

        public Park GeefPark(string id)
        {
            try
            {
                return repo.GeefPark(id);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("GeefPark", ex);
            }
        }

        public void UpdatePark(Park p)
        {
            try
            {
                repo.UpdatePark(p);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("udatePark", ex);
            }
        }

        public void VoegParkToe(Park p)
        {
            try
            {
                repo.VoegParkToe(p);
            }
            catch (Exception ex)
            {
                throw new BeheerderException("VoegParkToe", ex);
            }
        }
    }
}
