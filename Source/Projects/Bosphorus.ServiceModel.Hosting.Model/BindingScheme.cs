using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.ServiceModel.Hosting.Model
{
    public class BindingScheme : Enumeration<string>
    {
        public static readonly BindingScheme Http = new BindingScheme { Id = "Http", Name = "Http" };
        public static readonly BindingScheme Https = new BindingScheme { Id = "Https", Name = "Https" };
        public static readonly BindingScheme NetTcp = new BindingScheme {Id = "NetTcp", Name = "Net.Tcp"};
    }
}