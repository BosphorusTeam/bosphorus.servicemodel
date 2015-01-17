using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Bosphorus.Container.Castle.Extra;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Dispatcher
{
    internal class ServiceRegistryInstanceProvider : IInstanceProvider
    {
        private readonly IServiceRegistry serviceRegistry;
        private readonly Type serviceType;

        public ServiceRegistryInstanceProvider(IServiceRegistry serviceRegistry, Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            this.serviceRegistry = serviceRegistry;
            this.serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var serviceInstance = this.serviceRegistry.Get(this.serviceType);
            return serviceInstance;
        }

        public void ReleaseInstance(InstanceContext instanceContext, Object instance)
        {
            
        }
    }
}
