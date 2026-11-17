using System.Net.Http.Json;

namespace VVSecurity.Frontend.Services;

public sealed class SecurityPassClient(HttpClient httpClient)
{
    public async Task<string> GenerateAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetFromJsonAsync<GenerateSecurityPassResponse>(
            "GenerateSecurityPass/generateSecurityPass",
            cancellationToken);

        return response?.SecurityToken
            ?? throw new InvalidOperationException("The API returned an empty security token.");
    }

    private sealed class GenerateSecurityPassResponse
    {
        public string SecurityToken { get; set; } = string.Empty;
    }
}
