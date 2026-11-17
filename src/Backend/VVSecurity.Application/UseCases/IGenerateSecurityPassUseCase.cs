using VVSecurity.Communication.Responses;

namespace VVSecurity.Application.UseCases;

public interface IGenerateSecurityPassUseCase
{
    Task<ResponseSecurityPassJson> Execute();
}
