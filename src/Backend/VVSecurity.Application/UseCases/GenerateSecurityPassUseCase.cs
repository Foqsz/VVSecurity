using VVSecurity.Communication.Responses;
using VVSecurity.Domain.Repositories;

namespace VVSecurity.Application.UseCases;

public class GenerateSecurityPassUseCase : IGenerateSecurityPassUseCase
{
    private readonly IGenerateSecurityPassSecurity _generateSecurityPassSecurity;

    public GenerateSecurityPassUseCase(IGenerateSecurityPassSecurity generateSecurityPassSecurity)
    {
        _generateSecurityPassSecurity = generateSecurityPassSecurity;
    }

    public Task<ResponseSecurityPassJson> Execute()
    {
        var securityPass = Guid.CreateVersion7();

        var generateHasher = _generateSecurityPassSecurity.GenerateSecurityPass(securityPass);

        var response = new ResponseSecurityPassJson
        {
            SecurityToken = generateHasher
        };

        return Task.FromResult(response);
    }
}
