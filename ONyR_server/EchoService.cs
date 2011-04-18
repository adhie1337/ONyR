using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.ApplicationServices;

namespace ONyR_server
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EchoService : IEchoService
    {
        public string Echo(string value)
        {
            return String.Format("You said: {0}", value);
        }
    }
}
