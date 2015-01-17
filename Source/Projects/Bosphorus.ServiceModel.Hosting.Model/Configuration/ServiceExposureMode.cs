using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.ServiceModel.Hosting.Model.Configuration
{
    public class ServiceExposureMode : Enumeration<string>
    {
        public static readonly ServiceExposureMode Intranet = new ServiceExposureMode {Id = "Intranet", Name = "int"};
        public static readonly ServiceExposureMode Extranet = new ServiceExposureMode {Id = "Extranet", Name = "ext"};
    }
}