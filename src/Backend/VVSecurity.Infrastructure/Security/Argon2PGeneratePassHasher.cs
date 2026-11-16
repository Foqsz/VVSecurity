using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;
using VVSecurity.Domain.Repositories;

namespace VVSecurity.Infrastructure.Repository;

internal sealed class Argon2PGeneratePassHasher : IGenerateSecurityPassSecurity
{
    private const int DEGREE_OF_PARALLELISM = 1;
    private const int ITERATIONS = 2;
    private const int MEMORY_SIZE = 1024 * 20; // 20 MB
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;

    public string GenerateSecurityPass(Guid pass)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

        var hash = HashPass(pass.ToString(), salt);

        var combinedBytes = new byte[hash.Length + salt.Length];

        salt.CopyTo(combinedBytes);
        hash.CopyTo(combinedBytes, index: salt.Length);

        return Convert.ToBase64String(combinedBytes)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }

    private byte[] HashPass(string pass, byte[] salt)
    {
        var passBytes = Encoding.UTF8.GetBytes(pass);

        var hashAlgorithm = new Argon2id(passBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,
            Iterations = ITERATIONS,
            MemorySize = MEMORY_SIZE,
            Salt = salt
        };

        return hashAlgorithm.GetBytes(HASH_SIZE);
    }
}
