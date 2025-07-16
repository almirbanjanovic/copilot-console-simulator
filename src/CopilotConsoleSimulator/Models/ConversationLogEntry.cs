namespace CopilotConsoleSimulator.Models;

/// <summary>
/// Represents a single conversation log entry
/// </summary>
public class ConversationLogEntry
{
    public DateTime Timestamp { get; init; }

    public string UserInput { get; init; } = string.Empty;

    public string Response { get; init; } = string.Empty;

    public int ResponseTime 
    { 
        get; 
        init 
        {
            field = value < 0 ? 0 : value;
        }
    }

    public string SessionId { get; init; } = string.Empty;
}
