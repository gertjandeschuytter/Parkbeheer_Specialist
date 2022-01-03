using Microsoft.EntityFrameworkCore;
using ParkBeheerDataLayer.Mappers;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories {
    public class ContractenRepositoryEF : IContractenRepository {
        private ParkBeheerContext ctx;


        public ContractenRepositoryEF(string connectionString)
        {
            this.ctx = new ParkBeheerContext(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                ctx.HuurContracten.Remove(new EFHuurContractModel() { Id = contract.Id });
                SaveAndClear();
            }
            catch (Exception ex)
            {

                throw new RepositoryException("ContractRepositoyEF - AnnuleerContract", ex);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                return MapContract.MapToDomain(
                    ctx.HuurContracten
                    .Where(x => x.Id == id)
                    .Include(x => x.Huis)
                    .ThenInclude(x => x.Park)
                    .Include(x => x.Huurder)
                    .AsNoTracking().FirstOrDefault(), ctx);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepository - GeefContract(id)", ex);
            }
        }


        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return ctx.HuurContracten.Any(x => x.StartDatum == startDatum
                && x.Huurder.Id == huurderid && x.Huis.Id == huisid);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepository - HeeftContract", ex);
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return ctx.HuurContracten.Any(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepository - HeeftContract", ex);
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                ctx.HuurContracten.Update(MapContract.MapToDB(contract, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepository - UpdateContract", ex);
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                ctx.HuurContracten.Add(MapContract.MapToDB(contract, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("ContractRepository - VoegContractToe", ex);
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            if (dtEinde == null)
            {
                var lijst = ctx.HuurContracten
                        .Include(h => h.Huis)
                        .ThenInclude(h => h.Park)
                        .Include(h => h.Huurder)
                        .Where(h => h.StartDatum >= dtBegin)
                        .Select(h => MapContract.MapToDomain(h, ctx))
                        .AsNoTracking()
                        .ToList();
                return lijst;
            }
            else
            {
                var lijst = ctx.HuurContracten
                    .Include(h => h.Huis)
                    .ThenInclude(h => h.Park)
                    .Include(h => h.Huurder)
                    .Where(h => h.StartDatum >= dtBegin && h.EindDatum <= dtEinde)
                    .Select(h => MapContract.MapToDomain(h, ctx))
                    .AsNoTracking()
                    .ToList();
                return lijst;
            }
        }
    }
}
