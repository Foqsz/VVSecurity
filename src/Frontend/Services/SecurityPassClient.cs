using VVSecurity.Communication.Request;

namespace VVSecurity.Frontend.Services;

public sealed class SecurityPassClient(HttpClient httpClient)
{
    public async Task<string> GenerateAsync(
        GenerateSecurityPassRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.PostAsJsonAsync(
            "GenerateSecurityPass/generateSecurityPass",
            request,
            cancellationToken);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<GenerateSecurityPassResponse>(
            cancellationToken);

        return result?.SecurityToken
            ?? throw new InvalidOperationException("The API returned an empty security token.");
    }

    private sealed class GenerateSecurityPassResponse
    {
        public string SecurityToken { get; set; } = string.Empty;
    }
}
