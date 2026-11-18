namespace VVSecurity.Communication.Request;

public class GenerateSecurityPassRequest
{
    public int Length { get; set; } = 20;
    public bool IncludeUpperCase { get; set; } = true;
    public bool IncludeLowerCase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSymbols { get; set; } = true;
}
