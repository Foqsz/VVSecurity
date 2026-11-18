using VVSecurity.Communication.Request;
using VVSecurity.Communication.Responses;

namespace VVSecurity.Application.UseCases;

public interface IGenerateSecurityPassUseCase
{
    Task<ResponseSecurityPassJson> Execute(GenerateSecurityPassRequest generateSecurityPassRequest);
}
