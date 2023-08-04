using System.Security.Principal;


public class CurrentScopeDataContainer : IIdentity
{
    public CurrentScopeDataContainer()
    {

    }

    public string RequestUrl { get;  set; }

    public int UserId { get;  set; }

    public bool IsAuthenticated { get;  set; }

    public string Name { get;  set; }

    public string Email { get; set; }

    public string Language { get; set; }

    [Obsolete("AuthenticationType is not provided.")]
    public string AuthenticationType => string.Empty;

    public static CurrentScopeDataContainer Instance
        => (CurrentScopeDataContainer)Thread.CurrentPrincipal.Identity;
}
