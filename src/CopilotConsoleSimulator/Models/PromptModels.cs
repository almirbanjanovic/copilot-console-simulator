namespace CopilotConsoleSimulator.Models;

/// <summary>
/// Represents a prompt request with metadata
/// </summary>
public class PromptRequest
{
    public string Input 
    { 
        get; 
        set 
        {
            field = string.IsNullOrWhiteSpace(value) 
                ? string.Empty 
                : value.Trim();
        }
    } = string.Empty;

    public DateTime RequestTime { get; init; } = DateTime.UtcNow;

    public string SessionId { get; init; } = string.Empty;

    public Dictionary<string, string> Metadata { get; set; } = new();
}

/// <summary>
/// Represents a response to a prompt with metadata
/// </summary>
public class PromptResponse
{
    public string Response 
    { 
        get; 
        set 
        {
            field = value ?? string.Empty;
        }
    } = string.Empty;

    public DateTime ResponseTime { get; init; } = DateTime.UtcNow;

    public int ProcessingTimeMs 
    { 
        get; 
        set 
        {
            field = value < 0 ? 0 : value;
        }
    }

    public string ResponseType 
    { 
        get; 
        set 
        {
            field = string.IsNullOrWhiteSpace(value) 
                ? "Default" 
                : value.Trim();
        }
    } = "Default";

    public bool IsSuccess { get; set; } = true;
}
