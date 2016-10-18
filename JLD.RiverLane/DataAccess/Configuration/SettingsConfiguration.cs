using JLD.RiverLane.Models;
using System.Data.Entity.ModelConfiguration;

namespace JLD.RiverLane.DataAccess.Configuration
{
    public class SettingsConfiguration : EntityTypeConfiguration<Settings>
    {
        public SettingsConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}