using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;

namespace Bosphorus.ServiceModel.Hosting.Activation
{
    public class AssemblyProvider : IAssemblyProvider
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
            AssemblyFilter assemblyFilter = new AssemblyFilter(path);
            IEnumerable<Assembly> assemblies = ReflectionUtil.GetAssemblies(assemblyFilter);
            
            return assemblies;
        }
    }
}