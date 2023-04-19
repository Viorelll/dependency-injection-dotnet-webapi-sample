using dependency_injection_dotnet_webapi_sample.Services;

public class TransientService : ITransientService
{
    private string currentState = string.Empty;
    public string PrintMessage(string state)
    {
        if (string.IsNullOrWhiteSpace(currentState))
        {
            this.currentState = state;
        }

        return $"[Transient] Current state = '{currentState}', HashCode = {this.GetHashCode()}";
    }
}