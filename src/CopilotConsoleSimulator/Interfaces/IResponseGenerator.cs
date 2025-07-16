using CopilotConsoleSimulator.Models;

namespace CopilotConsoleSimulator.Interfaces;

/// <summary>
/// Interface for generating simulated responses
/// </summary>
public interface IResponseGenerator
{
    /// <summary>
    /// Generates a simulated response based on user input
    /// </summary>
    /// <param name="request">The prompt request</param>
    /// <returns>A simulated response</returns>
    PromptResponse GenerateResponse(PromptRequest request);

    /// <summary>
    /// Adds a custom response template
    /// </summary>
    /// <param name="template">The response template to add</param>
    void AddResponseTemplate(string template);

    /// <summary>
    /// Gets available response templates
    /// </summary>
    /// <returns>List of response templates</returns>
    List<string> GetResponseTemplates();
}
