using dependency_injection_dotnet_webapi_sample.Services;

public class ScopedService : IScopedService
{
    private string currentState = string.Empty;
    public string PrintMessage(string state)
    {
        if (string.IsNullOrWhiteSpace(currentState))
        {
            this.currentState = state;
        }

        return $"[Scoped] Current state = '{currentState}', HashCode = {this.GetHashCode()}";
    }
}