using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model {
    public class ParkBeheerContext : DbContext {
        public DbSet<EFHuisModel> Huizen { get; set; }
        public DbSet<EFHuurContractModel> HuurContracten { get; set; }
        public DbSet<EFHuurderModel> Huurders { get; set; }
        public DbSet<EFParkModel> Parken { get; set; }

        private readonly string _connectionstring;

        public ParkBeheerContext(string connectionstring)
        {
            this._connectionstring = connectionstring;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }
    }
}
