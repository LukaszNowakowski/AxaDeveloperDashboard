namespace Avanssur.AxaDeveloperDashboard.Api.Controllers.Environments
{
    public class Link
    {
        public Link(int id, string displayName, string icon, string url)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Icon = icon;
            this.Url = url;
        }

        public int Id { get; }

        public string DisplayName { get; }

        public string Icon { get; }

        public string Url { get; }
    }
}
