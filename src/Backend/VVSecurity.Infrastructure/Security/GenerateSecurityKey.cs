using System.Security.Cryptography;
using VVSecurity.Domain.Repositories;

namespace VVSecurity.Infrastructure.Repository;

internal sealed class GenerateSecurityKey : IGenerateSecurityPassSecurity
{
    private const int KEY_SIZE = 32;

    public string GenerateSecurityPass()
    {
        var key = RandomNumberGenerator.GetBytes(KEY_SIZE);

        var securityPass = Convert.ToBase64String(key)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');

        return securityPass;
    }
}