using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.ServiceModel.Hosting.Model;

namespace Bosphorus.ServiceModel.Hosting.Default.Addressing.Port
{
    public interface IBindingSchemePortProvider
    {
        int Get(BindingScheme bindingScheme);
    }
}