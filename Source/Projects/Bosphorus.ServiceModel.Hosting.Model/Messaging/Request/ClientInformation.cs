using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Model.Messaging.Request
{
    public class ClientInformation
    {
        public int? AccountId { get; set; }
        public string EmployeeId { get; set; }
        public int? UnitId { get; set; }
        public int? ApplicationId { get; set; }
        public string ApplicationVersion { get; set; }
       // public string NetworkCardId { get; set; }
    }
}