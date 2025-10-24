using Microsoft.Extensions.Options;

namespace ResultsService.Infrastructure.Services;

public class AuthClientService
{
    private readonly HttpClient _httpClient;
    private readonly string _authServiceUrl;

    public AuthClientService(HttpClient httpClient, IOptions<AuthServiceOptions> options)
    {
        _httpClient = httpClient;
        _authServiceUrl = options.Value.BaseUrl;
    }

    public async Task<bool> ValidateTokenAsync(string token)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_authServiceUrl}/api/auth/validate", new { token });

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<ValidationResult>();
        return result?.Valid ?? false;
    }

    private record ValidationResult(bool Valid);
}

public class AuthServiceOptions
{
    public string BaseUrl { get; set; } = string.Empty;
}
