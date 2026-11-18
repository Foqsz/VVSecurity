using VVSecurity.Communication.Request;

namespace VVSecurity.Domain.Repositories;

public interface IGenerateSecurityPassSecurity
{
    string GenerateSecurityPass(GenerateSecurityPassRequest generateSecurityPassRequest);
}
