namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    using Avanssur.AxaDeveloperDashboard.Api.DataAccess.Cqrs;

    public class GetPasswordSaltQuery : IQuery<GetPasswordSaltResult>
    {
        public GetPasswordSaltQuery(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; }
    }
}
