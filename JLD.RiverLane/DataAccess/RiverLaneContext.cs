using JLD.RiverLane.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BaseClasses.DataAccess.Conventions;
using BaseClasses.Models;

namespace JLD.RiverLane.DataAccess
{
    public class RiverLaneContext : DbContext
    {

        public RiverLaneContext()
        {
            Database.SetInitializer<RiverLaneContext>(null);
        }

        /// <summary>
        /// Retrieves the single Settings row from the database
        /// </summary>
        public virtual Settings Settings => SettingsSet.Single();

        public virtual DbSet<Settings> SettingsSet { get; set; }

        /// <summary>
        /// Retrieves all users in from the database
        /// </summary>
        public virtual DbSet<UserAccount> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<TableNameConvention>();
            modelBuilder.Conventions.Add<ColumnNameConvention>();
            modelBuilder.Conventions.Add<PrimaryKeyConvention>();
            modelBuilder.Conventions.Add<ForeignKeyConvention>();
        }
    }
}