using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using Bosphorus.ServiceModel.Hosting.Model.Configuration;

namespace Bosphorus.ServiceModel.Hosting.Default.Description.Operation.BehaviorProvider
{
    public class WebInvoke : IOperationBehaviorProvider
    {
        public bool IsApplicable(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription)
        {
            //TODO: Could this be WebHttp?
            return true;
        }

        public IEnumerable<IOperationBehavior> Get(ContractDescription contractDescription, OperationConfiguration operationConfiguration, OperationDescription operationDescription)
        {
            MethodInfo methodInfo = operationConfiguration.ExposedMethod;
            IEnumerable<ParameterInfo> stringParameters = methodInfo.GetParameters().Where(pi => pi.ParameterType == typeof(string));
            string uriTemplate = stringParameters.Aggregate(
                new StringBuilder(methodInfo.Name),
                (builder, parameterInfo) => builder.AppendFormat("/{{{0}}}", parameterInfo.Name),
                builder => builder.ToString());

            WebInvokeAttribute webInvokeBehavior = new WebInvokeAttribute();
            webInvokeBehavior.BodyStyle = WebMessageBodyStyle.Bare;
            webInvokeBehavior.RequestFormat = WebMessageFormat.Json;
            webInvokeBehavior.ResponseFormat = WebMessageFormat.Json;
            webInvokeBehavior.Method = "POST";
            webInvokeBehavior.UriTemplate = uriTemplate;

            return new[] {webInvokeBehavior};
        }
    }
}
