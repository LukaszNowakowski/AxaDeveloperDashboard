namespace Avanssur.AxaDeveloperDashboard.Api.Logic.EnvironmentsManagement
{
    public class Link
    {
        public Link(int id, string displayName, string icon, string url, int order)
        {
            this.Id = id;
            this.DisplayName = displayName;
            this.Icon = icon;
            this.Url = url;
            this.Order = order;
        }

        public int Id { get; }

        public string DisplayName { get; }

        public string Icon { get; }

        public string Url { get; }

        public int Order { get; }
    }
}
