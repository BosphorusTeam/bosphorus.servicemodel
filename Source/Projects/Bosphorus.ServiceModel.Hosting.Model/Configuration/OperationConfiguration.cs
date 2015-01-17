using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration
{
    public class OperationConfiguration
    {
        public MethodInfo ExposedMethod { get; set; }
    }
}