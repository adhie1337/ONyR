<%@ Application Language="C#" %>

<script runat="server">
    
    void Application_Start(object sender, EventArgs e)
    {
        System.Web.ApplicationServices.AuthenticationService.Authenticating +=
            new EventHandler<System.Web.ApplicationServices.AuthenticatingEventArgs>(AuthenticationService_Authenticating);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
    }

    void Session_Start(object sender, EventArgs e)
    {
    }

    void Session_End(object sender, EventArgs e) 
    {
    }

    void AuthenticationService_Authenticating(object sender, System.Web.ApplicationServices.AuthenticatingEventArgs e)
    {
        e.Authenticated = ONyR_server.AuthenticationService.authenticate(e.UserName, e.Password);
        e.AuthenticationIsComplete = true;
        //throw new Exception(String.Format("Username: \"{0}\", Password: \"{1}\"", e.UserName, e.Password));
    }

       
</script>
