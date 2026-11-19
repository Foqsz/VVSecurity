using VVSecurity.Application.Validator;
using VVSecurity.Communication.Request;
using VVSecurity.Communication.Responses;
using VVSecurity.Domain.Repositories;
using VVSecurity.Exceptions;

namespace VVSecurity.Application.UseCases;

public class GenerateSecurityPassUseCase : IGenerateSecurityPassUseCase
{
    private readonly IGenerateSecurityPassSecurity _generateSecurityPassSecurity;

    public GenerateSecurityPassUseCase(IGenerateSecurityPassSecurity generateSecurityPassSecurity)
    {
        _generateSecurityPassSecurity = generateSecurityPassSecurity;
    }

    public Task<ResponseSecurityPassJson> Execute(GenerateSecurityPassRequest generateSecurityPassRequest)
    {
        Validate(generateSecurityPassRequest);

        var securityPass = _generateSecurityPassSecurity.GenerateSecurityPass(generateSecurityPassRequest);

        var response = new ResponseSecurityPassJson
        {
            SecurityToken = securityPass
        };

        return Task.FromResult(response);
    }

    private static void Validate(GenerateSecurityPassRequest generateSecurityPassRequest)
    {
        var result = new GenerateSecurityPassRequestValidator().Validate(generateSecurityPassRequest);

        if(result.IsValid is false)
        {
            throw new ErrorOnValidationException(result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
