using JLD.RiverLane.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
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
        /// Retrieves every <see cref="Message"/> from the database
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Retrieves every <see cref="ExtraAlbum"/> from the database
        /// </summary>
        public DbSet<ExtraAlbum> ExtraAlbums { get; set; }

        /// <summary>
        /// Retrieves every <see cref="ExtraPoint"/> from the database
        /// </summary>
        public DbSet<ExtraPoint> ExtraPoints { get; set; }

        /// <summary>
        /// Retrieves every <see cref="Price"/> from the database
        /// </summary>
        public DbSet<Price> Prices { get; set; }

        /// <summary>
        /// Retrieves every <see cref="Recommend"/> from the database
        /// </summary>
        public DbSet<Recommend> Recommends { get; set; }

        /// <summary>
        /// Retrieves the single Settings row from the database
        /// </summary>
        public virtual Settings Settings => Set<Settings>().Single();

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

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}