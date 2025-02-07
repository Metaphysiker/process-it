
public class BackendHttpClient
{
    public HttpClient httpClient;
    public BackendHttpClient(EnvironmentVariables _environmentVariables)
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(_environmentVariables.API_BASE_URL);
    }
}
