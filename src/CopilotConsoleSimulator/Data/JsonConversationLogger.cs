using System.Text.Json;
using CopilotConsoleSimulator.Interfaces;
using CopilotConsoleSimulator.Models;

namespace CopilotConsoleSimulator.Data;

/// <summary>
/// JSON file-based implementation of conversation logging
/// </summary>
public class JsonConversationLogger : IConversationLogger
{
    private readonly string _logFilePath;
    private readonly JsonSerializerOptions _jsonOptions;

    public JsonConversationLogger(string logFilePath = "conversation_log.json")
    {
        _logFilePath = logFilePath;
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    /// <summary>
    /// Logs a conversation entry to the JSON file
    /// </summary>
    public async Task LogAsync(ConversationLogEntry logEntry)
    {
        try
        {
            var logEntries = await GetAllEntriesAsync();
            logEntries.Add(logEntry);

            var json = JsonSerializer.Serialize(logEntries, _jsonOptions);
            await File.WriteAllTextAsync(_logFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Failed to log interaction: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves conversation history from the JSON file
    /// </summary>
    public async Task<List<ConversationLogEntry>> GetHistoryAsync(string? sessionId = null)
    {
        var allEntries = await GetAllEntriesAsync();
        
        if (string.IsNullOrEmpty(sessionId))
            return allEntries;
            
        return allEntries.Where(e => e.SessionId == sessionId).ToList();
    }

    /// <summary>
    /// Clears all conversation history
    /// </summary>
    public async Task ClearHistoryAsync()
    {
        await File.WriteAllTextAsync(_logFilePath, "[]");
    }

    /// <summary>
    /// Helper method to read all entries from the JSON file
    /// </summary>
    private async Task<List<ConversationLogEntry>> GetAllEntriesAsync()
    {
        if (!File.Exists(_logFilePath))
            return new List<ConversationLogEntry>();

        var json = await File.ReadAllTextAsync(_logFilePath);
        if (string.IsNullOrWhiteSpace(json))
            return new List<ConversationLogEntry>();

        return JsonSerializer.Deserialize<List<ConversationLogEntry>>(json, _jsonOptions) 
               ?? new List<ConversationLogEntry>();
    }
}
