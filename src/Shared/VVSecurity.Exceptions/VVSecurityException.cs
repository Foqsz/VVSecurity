using System.Net;

namespace VVSecurity.Exceptions;

public abstract class VVSecurityException : System.Exception
{
    public abstract HttpStatusCode GetStatusCode();
    public abstract List<string> GetErrorMessages();
}
