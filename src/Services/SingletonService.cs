using dependency_injection_dotnet_webapi_sample.Services;

public class SingletonService : ISingletonService
{
     private string currentState = string.Empty;
    public string PrintMessage(string state)
    {
        if (string.IsNullOrWhiteSpace(currentState))
        {
            this.currentState = state;
        }

        return $"[Singleton] Current state = '{currentState}', HashCode = {this.GetHashCode()}";
    }
}