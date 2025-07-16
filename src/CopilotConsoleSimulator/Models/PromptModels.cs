namespace CopilotConsoleSimulator.Models;

/// <summary>
/// Represents a prompt request with metadata
/// </summary>
public class PromptRequest
{
    public string Input { get; set; } = string.Empty;
    public DateTime RequestTime { get; set; } = DateTime.UtcNow;
    public string SessionId { get; set; } = string.Empty;
    public Dictionary<string, string> Metadata { get; set; } = new();
}

/// <summary>
/// Represents a response to a prompt with metadata
/// </summary>
public class PromptResponse
{
    public string Response { get; set; } = string.Empty;
    public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
    public int ProcessingTimeMs { get; set; }
    public string ResponseType { get; set; } = "Default";
    public bool IsSuccess { get; set; } = true;
}
