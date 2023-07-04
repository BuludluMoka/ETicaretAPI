using System.Security.Principal;


public class CurrentScopeDataContainer : IIdentity
{
    internal CurrentScopeDataContainer()
    {

    }

    public string RequestUrl { get; internal set; }

    public int UserId { get; internal set; }

    public bool IsAuthenticated { get; internal set; }

    public string Name { get; internal set; }

    public string Email { get; internal set; }

    public string Language { get; internal set; }

    [Obsolete("AuthenticationType is not provided.")]
    public string AuthenticationType => string.Empty;

    public static CurrentScopeDataContainer Instance
        => (CurrentScopeDataContainer)Thread.CurrentPrincipal.Identity;
}
