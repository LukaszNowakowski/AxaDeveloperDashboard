namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    public class LinkInformation
    {
        public LinkInformation(
            int environmentId,
            string environmentName,
            int linkId,
            string linkName,
            string linkIcon,
            string url)
        {
            this.EnvironmentId = environmentId;
            this.EnvironmentName = environmentName;
            this.LinkId = linkId;
            this.LinkIcon = linkIcon;
            this.LinkName = linkName;
            this.Url = url;
        }

        public int EnvironmentId { get; set; }

        public string EnvironmentName { get; set; }

        public int LinkId { get; set; }

        public string LinkName { get; set; }

        public string LinkIcon { get; set; }

        public string Url { get; set; }
    }
}
