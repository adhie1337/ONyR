﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ONyR_client.EchoServiceSkeleton {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EchoServiceSkeleton.IEchoService")]
    public interface IEchoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEchoService/Echo", ReplyAction="http://tempuri.org/IEchoService/EchoResponse")]
        string Echo(string value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEchoServiceChannel : ONyR_client.EchoServiceSkeleton.IEchoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EchoServiceClient : System.ServiceModel.ClientBase<ONyR_client.EchoServiceSkeleton.IEchoService>, ONyR_client.EchoServiceSkeleton.IEchoService {
        
        public EchoServiceClient() {
        }
        
        public EchoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EchoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EchoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EchoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Echo(string value) {
            return base.Channel.Echo(value);
        }
    }
}