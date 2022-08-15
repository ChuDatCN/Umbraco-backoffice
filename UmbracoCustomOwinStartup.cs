//public class UmbracoCustomOwinStartup : UmbracoOwinStartup
//{
//    static readonly string Caption = "Keycloak";
//    static readonly string ClientId = "umbraco";
//    static readonly string Style = "btn-github";
//    static readonly string Icon = "fa-key";

//    /// <summary>
//    /// Configures the <see cref="BackOfficeUserManager"/> for Umbraco
//    /// </summary>
//    /// <param name="app"></param>
//    protected override void ConfigureUmbracoUserManager(IAppBuilder app)
//    {
//        // There are several overloads of this method that allow you to customize the BackOfficeUserManager or even custom BackOfficeUserStore.
//        app.ConfigureUserManagerForUmbracoBackOffice(
//            Services,
//            Mapper,
//            UmbracoSettings.Content,
//            GlobalSettings,
//            //The Umbraco membership provider needs to be specified in order to maintain backwards compatibility with the 
//            // user password formats. The membership provider is not used for authentication, if you require custom logic
//            // to validate the username/password against an external data source you can create create a custom UserManager
//            // and override CheckPasswordAsync
//            global::Umbraco.Core.Security.MembershipProviderExtensions.GetUsersMembershipProvider().AsUmbracoMembershipProvider());
//    }

//    protected override void ConfigureUmbracoAuthentication(IAppBuilder app)
//    {
//        base.ConfigureUmbracoAuthentication(app);

//        app.UseUmbracoBackOfficeTokenAuth(new BackOfficeAuthServerProviderOptions());

//        var identityOptions = new OpenIdConnectAuthenticationOptions
//        {
//            Caption = Caption,
//            Authority = "http://localhost:8080/",
//            AuthenticationType = "http://localhost:8080/",
//            ClientId = ClientId,
//            RedirectUri = "http://umbraco.bifrost.localhost/umbraco",
//            PostLogoutRedirectUri = "http://umbraco.bifrost.localhost/umbraco",
//            ResponseType = "code",
//            Scope = "openid profile roles email",
//            RequireHttpsMetadata = false,
//            MetadataAddress = "http://localhost:8080/auth/realms/umbracorealm/.well-known/openid-configuration",
//            SignInAsAuthenticationType = Constants.Security.BackOfficeExternalAuthenticationType,
//            Notifications = new OpenIdConnectAuthenticationNotifications
//            {
//                SecurityTokenValidated = ClaimsTransformer.GenerateUserIdentityAsync
//            }
//        };

//        identityOptions.ForUmbracoBackOffice(Style, Icon);
//        identityOptions.Caption = Caption;
//        identityOptions.AuthenticationType = "http://localhost:8080/";

//        var providerOptions = new BackOfficeExternalLoginProviderOptions { AutoLinkOptions = new ExternalSignInAutoLinkOptions(true) };
//        identityOptions.SetBackOfficeExternalLoginProviderOptions(providerOptions);

//        app.UseOpenIdConnectAuthentication(identityOptions);
//    }
//}
//public class ClaimsTransformer
//{
//    public static async Task GenerateUserIdentityAsync(
//        SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
//    {
//        // Now this contains ID claims (e.g. GivenName in my case)
//        var id = notification.AuthenticationTicket.Identity;

//        var identityUser = new ClaimsIdentity(
//            id.Claims, // copy the claims I have
//            notification.AuthenticationTicket.Identity.AuthenticationType,
//            // set the nameType, so Umbraco can use the 'ExternalLogin.Name' for auto-link to work
//            ClaimTypes.GivenName, // <-- You have to set a correct nameType claim
//            ClaimTypes.Role);

//        notification.AuthenticationTicket = new AuthenticationTicket(identityUser,
//               notification.AuthenticationTicket.Properties);
//    }
//}





