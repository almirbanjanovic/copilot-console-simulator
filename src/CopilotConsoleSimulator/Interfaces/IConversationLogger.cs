using CopilotConsoleSimulator.Models;

namespace CopilotConsoleSimulator.Interfaces;

/// <summary>
/// Interface for logging conversation data
/// </summary>
public interface IConversationLogger
{
    /// <summary>
    /// Logs a conversation entry to storage
    /// </summary>
    /// <param name="logEntry">The conversation entry to log</param>
    Task LogAsync(ConversationLogEntry logEntry);

    /// <summary>
    /// Retrieves conversation history
    /// </summary>
    /// <param name="sessionId">Optional session ID to filter by</param>
    /// <returns>List of conversation entries</returns>
    Task<List<ConversationLogEntry>> GetHistoryAsync(string? sessionId = null);

    /// <summary>
    /// Clears conversation history
    /// </summary>
    Task ClearHistoryAsync();
}
