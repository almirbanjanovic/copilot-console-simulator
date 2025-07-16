namespace CopilotConsoleSimulator.Models;

/// <summary>
/// Represents a single conversation log entry
/// </summary>
public class ConversationLogEntry
{
    public DateTime Timestamp { get; set; }

    public string UserInput { get; set; } = string.Empty;

    public string Response { get; set; } = string.Empty;

    public int ResponseTime 
    { 
        get; 
        set 
        {
            field = value < 0 ? 0 : value;
        }
    }

    public string SessionId { get; set; } = string.Empty;
}
