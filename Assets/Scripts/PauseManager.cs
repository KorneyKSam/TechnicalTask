using System.Collections.Generic;

public class PauseManager : IPausedHandler
{
    private readonly List<IPausedHandler> _handlers = new List<IPausedHandler>();

    public bool IsPaused { get; private set; }
    public void Register(IPausedHandler handler)
    {
        _handlers.Add(handler);
    }

    public void UnRegister(IPausedHandler handler)
    {
        _handlers.Remove(handler);
    }

    public void SetPaused(bool isPaused)
    {
        IsPaused = isPaused;
        foreach (var handler in _handlers)
        {
            handler.SetPaused(isPaused);
        }
    }
}
