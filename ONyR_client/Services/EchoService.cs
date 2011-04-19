using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ONyR_client.EchoServiceSkeleton;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace ONyR_client.Services
{
    class EchoService
    {
        public static string Echo(string message)
        {
            string retVal;

            EchoServiceClient client = new EchoServiceClient();
            OperationContextScope scope = new OperationContextScope(client.InnerChannel);

            //* Add our cookie into the request header
            var prop = new HttpRequestMessageProperty();
            prop.Headers.Add(HttpRequestHeader.Cookie, SessionCookieContainer.cookies);
            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = prop;

            //* Make the data services call - the cookie will be sent and the client authenticated
            retVal = client.Echo(message);

            client.Close();

            return retVal;
        }
    }
}
