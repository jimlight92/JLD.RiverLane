using System.Configuration;

namespace JLD.RiverLane.Infrastructure
{
    public abstract class WebConfigSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("sendErrors", IsRequired = true)]
        public bool SendErrors
        {
            get { return (bool)base["sendErrors"]; }
            set { base["sendErrors"] = value; }
        }

        [ConfigurationProperty("sendContactEmails", IsRequired = true)]
        public bool SendContactEmails
        {
            get { return (bool)base["sendContactEmails"]; }
            set { base["sendContactEmails"] = value; }
        }
    }
}
