using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract]
public interface IEchoService
{
    [OperationContract]
    string Echo(string value);
}
