using System;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.ServiceModel.Hosting.Demo.PocoService
{
    public class Identifiable<T>
    {
        public T Id
        {
            get;
            set;
        }
    }
}