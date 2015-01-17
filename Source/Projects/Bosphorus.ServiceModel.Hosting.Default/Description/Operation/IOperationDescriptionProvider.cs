using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation
{
    public interface IOperationDescriptionProvider
    {
        OperationDescription Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration);
    }
}