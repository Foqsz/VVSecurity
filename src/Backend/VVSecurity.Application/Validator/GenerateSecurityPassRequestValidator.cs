using FluentValidation;
using VVSecurity.Communication.Request;
using VVSecurity.Exceptions;

namespace VVSecurity.Application.Validator;

public class GenerateSecurityPassRequestValidator : AbstractValidator<GenerateSecurityPassRequest>
{
    public GenerateSecurityPassRequestValidator()
    {
        RuleFor(x => x.Length)
            .InclusiveBetween(8, 128)
            .WithMessage(ResourceMessagesExceptions.INVALID_PASSWORD_LENGTH);

        RuleFor(x => x)
            .Must(x =>
            x.IncludeLowerCase || x.IncludeUpperCase || x.IncludeNumbers || x.IncludeSymbols)
            .WithMessage(ResourceMessagesExceptions.AT_LEAST_ONE_CHARACTER_TYPE_REQUIRED);
    }
}
