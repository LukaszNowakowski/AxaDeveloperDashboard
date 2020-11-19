namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Security
{
    public class VerifyCredentialsResult
    {
        public VerifyCredentialsResult(int entriesCount)
        {
            this.EntriesCount = entriesCount;
        }

        public int EntriesCount { get; }
    }
}
