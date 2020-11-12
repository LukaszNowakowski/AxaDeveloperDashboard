namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    public class LinkInformation
    {
        public LinkInformation(
            int environmentId,
            int linkId,
            string linkName,
            string linkIcon,
            string url,
            int linkOrder)
        {
            this.EnvironmentId = environmentId;
            this.LinkId = linkId;
            this.LinkIcon = linkIcon;
            this.LinkName = linkName;
            this.Url = url;
            this.LinkOrder = linkOrder;
        }

        public int EnvironmentId { get; set; }

        public int LinkId { get; set; }

        public string LinkName { get; set; }

        public string LinkIcon { get; set; }

        public string Url { get; set; }

        public int LinkOrder { get; set; }
    }
}
