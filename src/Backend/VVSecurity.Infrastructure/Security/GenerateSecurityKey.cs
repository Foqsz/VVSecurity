using System.Security.Cryptography;
using System.Text;
using VVSecurity.Communication.Request;
using VVSecurity.Domain.Constants;
using VVSecurity.Domain.Repositories;

namespace VVSecurity.Infrastructure.Repository;

internal sealed class GenerateSecurityKey : IGenerateSecurityPassSecurity
{
    public string GenerateSecurityPass(GenerateSecurityPassRequest request)
    {
        var characters = new StringBuilder();

        if (request.IncludeUpperCase)
            characters.Append(PasswordCharacterSets.UpperCase);

        if (request.IncludeLowerCase)
            characters.Append(PasswordCharacterSets.LowerCase);

        if (request.IncludeNumbers)
            characters.Append(PasswordCharacterSets.Numbers);

        if (request.IncludeSymbols)
            characters.Append(PasswordCharacterSets.Symbols);

        var allowedCharacters = characters.ToString();
        var password = new char[request.Length];

        for (int i = 0; i < password.Length; i++)
        {
            var index = RandomNumberGenerator.GetInt32(allowedCharacters.Length);
            password[i] = allowedCharacters[index];
        }

        return new string(password);
    }
}