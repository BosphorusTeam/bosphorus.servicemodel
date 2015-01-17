using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.DispatchMessageInspector;
using ServiceConfiguration = Bosphorus.ServiceModel.Hosting.Model.Configuration.ServiceConfiguration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Service.BehaviorProvider
{
    public abstract class AbstractDispatchMessageInspector<TProvider> : IServiceBehaviorProvider
        where TProvider : IDispatchMessageInspectorProvider
    {
        private readonly IList<TProvider> providers;

        protected AbstractDispatchMessageInspector(IList<TProvider> providers)
        {
            this.providers = providers;
        }

        protected IList<TProvider> Providers
        {
            get { return this.providers; }
        }

        public bool IsApplicable(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            bool isApplicable = this.IsApplicableInternal(serviceConfiguration, baseAddresses, serviceHost);

            return isApplicable;
        }

        protected abstract bool IsApplicableInternal(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost);

        public IEnumerable<IServiceBehavior> Get(ServiceConfiguration serviceConfiguration, Uri[] baseAddresses, ServiceHost serviceHost)
        {
            IEnumerable<GenericDispatchMessageInspectorBehavior<TProvider>> behaviors = this.Providers.Select(provider => new GenericDispatchMessageInspectorBehavior<TProvider>(provider));

            return behaviors;
        }
    }
}