namespace CopilotConsoleSimulator.Interfaces;

/// <summary>
/// Interface for prompt service that handles user input and simulates responses
/// </summary>
public interface IPromptService
{
    /// <summary>
    /// Accepts user input and returns a simulated response
    /// </summary>
    /// <param name="userInput">The input provided by the user</param>
    /// <returns>A simulated response to the user input</returns>
    Task<string> ProcessPromptAsync(string userInput);

    /// <summary>
    /// Starts an interactive session with the user
    /// </summary>
    /// <returns>A task representing the interactive session</returns>
    Task StartInteractiveSessionAsync();
}
