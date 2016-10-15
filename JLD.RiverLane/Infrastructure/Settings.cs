using System.Web.Configuration;

namespace JLD.RiverLane.Infrastructure
{
    public class Settings<TSection> where TSection : WebConfigSettingsSection
    {
        private static TSection section = null;
        public static TSection Section
        {
            get
            {
                if (section == null)
                {
                    section = (TSection)WebConfigurationManager
                         .GetSection("settings");
                }
                return section;
            }
        }

        public static bool SendErrorEmails
        {
            get
            {
                return Section.SendErrors;
            }
        }

        public static bool SendContactEmails
        {
            get
            {
                return Section.SendContactEmails;
            }
        }
    }
}