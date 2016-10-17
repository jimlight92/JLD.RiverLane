using JLD.RiverLane.DataAccess.Conventions;
using JLD.RiverLane.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JLD.RiverLane.DataAccess
{
    public class RiverLaneContext : DbContext
    {

        public RiverLaneContext()
            : base()
        {
            Database.SetInitializer<RiverLaneContext>(null);
        }

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