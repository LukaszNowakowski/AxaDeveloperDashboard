namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security
{
    using System;

    public class CreateAccountResponse
    {
        public CreateAccountResponse(
            Guid? id)
        {
            this.Id = id;
        }

        public Guid? Id { get; }
    }
}
