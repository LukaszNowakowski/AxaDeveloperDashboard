using System;
using System.Collections.Generic;
using System.Text;

namespace Avanssur.AxaDeveloperDashboard.Api.DataAccess.Environments
{
    public class EnvironmentInformation
    {
        public EnvironmentInformation(
            int environmentId,
            string environmentName,
            int environmentOrder)
        {
            this.EnvironmentId = environmentId;
            this.EnvironmentName = environmentName;
            this.EnvironmentOrder = environmentOrder;
        }

        public int EnvironmentId { get; set; }

        public string EnvironmentName { get; set; }

        public int EnvironmentOrder { get; set; }
    }
}
