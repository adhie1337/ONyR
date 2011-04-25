using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Net;
using System.Web;
using System.Web.ApplicationServices;
using ONyRDataSetTableAdapters;

[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class EchoService : IEchoService
{
    public string Echo(string value)
    {
        // Log mechanism
        ONyRDataSetTableAdapters.LogTableAdapter adapter = new ONyRDataSetTableAdapters.LogTableAdapter();
        adapter.Insert("EchoService", "Echo", value, "?");
        adapter.Dispose();

        if (HttpContext.Current.User.Identity.IsAuthenticated == false)
        {
            throw new Exception("Authentication needed to use this method");
        }


        return String.Format("You said: {0}", value);
    }
}
