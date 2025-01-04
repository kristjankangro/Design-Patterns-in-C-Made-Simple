namespace FluentBuilder.Clip05
{
    internal interface IExpectsInitialCatalog
    {
        IExpectAuthentication WithInitialCatalog(string initialCatalog);
    }

    internal interface IExpectAuthentication
    {
        IOptionalBuilder WithCredentials(string username, string password);
        IOptionalBuilder UsingIntegratedSecurity();
        IOptionalBuilder UsingTrustedConnection();
    }

    internal interface IOptionalBuilder
    {
        IOptionalBuilder WithTimeout(int seconds);
        IOptionalBuilder WithProvider(string provider);
        string Build();
    }
}