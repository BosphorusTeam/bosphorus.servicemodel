namespace Bosphorus.ServiceModel.Hosting.Security.Authentication.Provider
{
    public interface IAuthenticationProvider<in TModel>
    {
        AuthenticationResult Authenticate(TModel model);
    }
}