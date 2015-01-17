using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace Bosphorus.ServiceModel.Hosting.Activation
{
    public static class DynamicServiceHelper
    {
        private static readonly object SyncRoot = new object();
        private static readonly Hashtable ServiceActivations;

        static DynamicServiceHelper()
        {
            ServiceHostingEnvironment.EnsureInitialized();

            FieldInfo hostingManagerField = typeof(ServiceHostingEnvironment).GetField("hostingManager", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
            object hostingManager = hostingManagerField.GetValue(null);
            FieldInfo serviceActivationsField = hostingManager.GetType().GetField("serviceActivations", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            ServiceActivations = (Hashtable)serviceActivationsField.GetValue(hostingManager);
        }

        public static void RegisterService(string address, Type factory, Type service)
        {
            lock (SyncRoot)
            {
                if (ServiceActivations.ContainsKey(address))
                {
                    return;
                }

                string factoryAssemblyQualifiedName = factory == null ? string.Empty : factory.AssemblyQualifiedName;
                string serviceActivationEntry = string.Format("{0}|{1}|{2}", address, factoryAssemblyQualifiedName, service.AssemblyQualifiedName);
                ServiceActivations.Add(address, serviceActivationEntry);
            }
        }
    }
}