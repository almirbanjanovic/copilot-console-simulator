using CopilotConsoleSimulator.Interfaces;
using CopilotConsoleSimulator.Models;

namespace CopilotConsoleSimulator.Services;

/// <summary>
/// Service that handles user prompts, generates simulated responses, and logs interactions
/// </summary>
public class PromptService : IPromptService
{
    private readonly IConversationLogger _logger;
    private readonly IResponseGenerator _responseGenerator;
    private readonly string _sessionId;

    public PromptService(IConversationLogger logger, IResponseGenerator responseGenerator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _responseGenerator = responseGenerator ?? throw new ArgumentNullException(nameof(responseGenerator));
        _sessionId = Guid.NewGuid().ToString("N")[..8]; // Short session ID
    }

    /// <summary>
    /// Processes a user prompt and returns a simulated response
    /// </summary>
    /// <param name="userInput">The input provided by the user</param>
    /// <returns>A simulated response to the user input</returns>
    public async Task<string> ProcessPromptAsync(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            return "I didn't receive any input. Could you please ask me something?";
        }

        // Create prompt request
        var request = new PromptRequest
        {
            Input = userInput,
            RequestTime = DateTime.UtcNow,
            SessionId = _sessionId
        };

        // Simulate processing time
        await Task.Delay(500);

        // Generate response
        var promptResponse = _responseGenerator.GenerateResponse(request);

        // Simulate the actual processing delay (ensure it's not negative)
        var delayMs = Math.Max(0, promptResponse.ProcessingTimeMs - 500);
        await Task.Delay(delayMs);

        // Log the interaction
        var logEntry = new ConversationLogEntry
        {
            Timestamp = request.RequestTime,
            UserInput = userInput,
            Response = promptResponse.Response,
            ResponseTime = promptResponse.ProcessingTimeMs,
            SessionId = _sessionId
        };

        await _logger.LogAsync(logEntry);

        return promptResponse.Response;
    }

    /// <summary>
    /// Starts an interactive session with the user
    /// </summary>
    /// <returns>A task representing the interactive session</returns>
    public async Task StartInteractiveSessionAsync()
    {
        Console.WriteLine("Welcome to the Copilot Console Simulator!");
        Console.WriteLine($"Session ID: {_sessionId}");
        Console.WriteLine("Type your questions or commands. Type 'exit' to quit.");
        Console.WriteLine("Special commands: 'history' to view conversation history, 'clear' to clear history");
        Console.WriteLine(new string('-', 70));

        while (true)
        {
            Console.Write("\nYou: ");
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                continue;
            }

            var trimmedInput = userInput.Trim().ToLower();

            if (trimmedInput == "exit")
            {
                Console.WriteLine("Thank you for using the Copilot Console Simulator!");
                break;
            }

            if (trimmedInput == "history")
            {
                await DisplayHistoryAsync();
                continue;
            }

            if (trimmedInput == "clear")
            {
                await _logger.ClearHistoryAsync();
                Console.WriteLine("Conversation history cleared.");
                continue;
            }

            Console.Write("Copilot: ");
            var response = await ProcessPromptAsync(userInput);
            Console.WriteLine(response);
        }
    }

    /// <summary>
    /// Displays conversation history for the current session
    /// </summary>
    private async Task DisplayHistoryAsync()
    {
        var history = await _logger.GetHistoryAsync(_sessionId);
        
        if (!history.Any())
        {
            Console.WriteLine("No conversation history found for this session.");
            return;
        }

        Console.WriteLine($"\n--- Conversation History (Session: {_sessionId}) ---");
        foreach (var entry in history)
        {
            Console.WriteLine($"[{entry.Timestamp:HH:mm:ss}] You: {entry.UserInput}");
            Console.WriteLine($"[{entry.Timestamp.AddMilliseconds(entry.ResponseTime):HH:mm:ss}] Copilot: {entry.Response}");
            Console.WriteLine();
        }
        Console.WriteLine("--- End of History ---");
    }
}
