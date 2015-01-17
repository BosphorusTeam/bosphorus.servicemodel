using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.ServiceModel.Dispatcher;

namespace Bosphorus.ServiceModel.Hosting.Default.Dispatcher
{
    public class PocoServiceOperationInvoker : IOperationInvoker
    {
        private readonly MethodInfo methodInfo;

        public PocoServiceOperationInvoker(MethodInfo methodInfo)
        {
            this.methodInfo = methodInfo;
        }

        public object[] AllocateInputs()
        {
            return new object[this.methodInfo.GetParameters().Length];
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            outputs = new object[0];
            try
            {
                object result = this.methodInfo.Invoke(instance, inputs);
                return result;
            }
            catch (TargetInvocationException exception)
            {
                ExceptionDispatchInfo innerExceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception.InnerException);
                innerExceptionDispatchInfo.Throw();
                return null;
            }
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new NotSupportedException();
        }

        public bool IsSynchronous
        {
            get { return true; }
        }
    }
}
