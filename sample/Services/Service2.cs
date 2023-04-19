using dependency_injection_dotnet_webapi_sample.Services;

public class Service2 : IService2
{
    private readonly ISingletonService _singletonService;
    private readonly IScopedService _scopedService;
    private readonly ITransientService _transientService;

    public Service2(
        ISingletonService singletonService,
        IScopedService scopedService,
        ITransientService transientService)
    {
        _singletonService = singletonService;
        _scopedService = scopedService;
        _transientService = transientService;
    }
    public string PrintAllMessageFromService2(string state)
    {
        var singletonMessage = _singletonService.PrintMessage(state);
        var scopedMessage = _scopedService.PrintMessage(state);
        var transientMessage = _transientService.PrintMessage(state);

        return string.Concat(singletonMessage, "\n", scopedMessage, "\n", transientMessage);
    }
}