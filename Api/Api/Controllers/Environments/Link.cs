namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    public class Link
    {
        public Link(string displayName, string icon, string url)
        {
            this.DisplayName = displayName;
            this.Icon = icon;
            this.Url = url;
        }

        public string DisplayName { get; }

        public string Icon { get; }

        public string Url { get; }
    }
}
