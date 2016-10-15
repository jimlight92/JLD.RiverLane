using System.Configuration;

namespace JLD.RiverLane.Infrastructure
{
    public sealed class SettingsSection : WebConfigSettingsSection
    {
        [ConfigurationProperty("emailTo", IsRequired = true)]
        public string EmailTo
        {
            get { return (string)base["emailTo"]; }
            set { base["emailTo"] = value; }
        }

        [ConfigurationProperty("contactNumber", IsRequired = true)]
        public string ContactNumber
        {
            get { return (string)base["contactNumber"]; }
            set { base["contactNumber"] = value; }
        }

        [ConfigurationProperty("imageFolder", IsRequired = true)]
        public string ImageFolder
        {
            get { return (string)base["imageFolder"]; }
            set { base["imageFolder"] = value; }
        }
    }
}