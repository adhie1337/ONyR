﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ONyR_client.AuthenticationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://asp.net/ApplicationServices/v200", ConfigurationName="AuthenticationService.AuthenticationService")]
    public interface AuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://asp.net/ApplicationServices/v200/AuthenticationService/ValidateUser", ReplyAction="http://asp.net/ApplicationServices/v200/AuthenticationService/ValidateUserRespons" +
            "e")]
        bool ValidateUser(string username, string password, string customCredential);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://asp.net/ApplicationServices/v200/AuthenticationService/Login", ReplyAction="http://asp.net/ApplicationServices/v200/AuthenticationService/LoginResponse")]
        bool Login(string username, string password, string customCredential, bool isPersistent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://asp.net/ApplicationServices/v200/AuthenticationService/IsLoggedIn", ReplyAction="http://asp.net/ApplicationServices/v200/AuthenticationService/IsLoggedInResponse")]
        bool IsLoggedIn();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://asp.net/ApplicationServices/v200/AuthenticationService/Logout", ReplyAction="http://asp.net/ApplicationServices/v200/AuthenticationService/LogoutResponse")]
        void Logout();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AuthenticationServiceChannel : ONyR_client.AuthenticationService.AuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<ONyR_client.AuthenticationService.AuthenticationService>, ONyR_client.AuthenticationService.AuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidateUser(string username, string password, string customCredential) {
            return base.Channel.ValidateUser(username, password, customCredential);
        }
        
        public bool Login(string username, string password, string customCredential, bool isPersistent) {
            return base.Channel.Login(username, password, customCredential, isPersistent);
        }
        
        public bool IsLoggedIn() {
            return base.Channel.IsLoggedIn();
        }
        
        public void Logout() {
            base.Channel.Logout();
        }
    }
}
