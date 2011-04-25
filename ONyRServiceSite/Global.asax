<%@ Application Language="C#" %>

<script runat="server">
    
    void Application_Start(object sender, EventArgs e)
    {
        System.Web.ApplicationServices.AuthenticationService.Authenticating +=
            new EventHandler<System.Web.ApplicationServices.AuthenticatingEventArgs>(AuthenticationService.Authenticating);

        System.Web.ApplicationServices.AuthenticationService.CreatingCookie +=
            new EventHandler<System.Web.ApplicationServices.CreatingCookieEventArgs>(AuthenticationService.CreationCookie);
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

       
</script>
