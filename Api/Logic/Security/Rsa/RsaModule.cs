namespace Avanssur.AxaDeveloperDashboard.Api.Logic.Security.Rsa
{
    using System;

    using Autofac;
    

    public class RsaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.RegisterType<DefaultRsaHandler>().As<IRsaHandler>();
        }
    }
}
