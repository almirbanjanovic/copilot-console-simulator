using CopilotConsoleSimulator.Interfaces;
using CopilotConsoleSimulator.Models;

namespace CopilotConsoleSimulator.Services;

/// <summary>
/// Service that generates simulated responses based on user input
/// </summary>
public class ResponseGeneratorService : IResponseGenerator
{
    private readonly Random _random;
    private readonly List<string> _responseTemplates;

    public ResponseGeneratorService()
    {
        _random = new Random();
        _responseTemplates = new List<string>
        {
            "That's an interesting question! Let me think about that for a moment.",
            "I understand what you're asking. Here's my perspective on that:",
            "Great question! This is a topic I can definitely help with.",
            "I see what you're getting at. Let me break this down for you:",
            "That's a thoughtful inquiry. Based on my knowledge, I'd say:",
            "Excellent point! Here's how I would approach this:",
            "I appreciate you asking about this. My understanding is:",
            "That's a complex topic. Let me try to explain it simply:",
            "Good question! I think the key thing to consider is:",
            "I'm glad you brought this up. Here's what I think:"
        };
    }

    /// <summary>
    /// Generates a simulated response based on user input
    /// </summary>
    public PromptResponse GenerateResponse(PromptRequest request)
    {
        var startTime = DateTime.UtcNow;
        var processingTime = _random.Next(500, 2000);
        
        var baseResponse = _responseTemplates[_random.Next(_responseTemplates.Count)];
        var responseType = "Default";
        var finalResponse = GenerateContextualResponse(request.Input, baseResponse, out responseType);

        return new PromptResponse
        {
            Response = finalResponse,
            ResponseTime = startTime.AddMilliseconds(processingTime),
            ProcessingTimeMs = processingTime,
            ResponseType = responseType,
            IsSuccess = true
        };
    }

    /// <summary>
    /// Adds a custom response template
    /// </summary>
    public void AddResponseTemplate(string template)
    {
        if (!string.IsNullOrWhiteSpace(template))
        {
            _responseTemplates.Add(template);
        }
    }

    /// <summary>
    /// Gets available response templates
    /// </summary>
    public List<string> GetResponseTemplates()
    {
        return new List<string>(_responseTemplates);
    }

    /// <summary>
    /// Generates context-aware responses based on input keywords
    /// </summary>
    private string GenerateContextualResponse(string userInput, string baseResponse, out string responseType)
    {
        var lowerInput = userInput.ToLower();

        if (lowerInput.Contains("code") || lowerInput.Contains("programming"))
        {
            responseType = "Programming";
            return baseResponse + " When it comes to coding, I always recommend following best practices and writing clean, maintainable code.";
        }

        if (lowerInput.Contains("help") || lowerInput.Contains("assist"))
        {
            responseType = "Help";
            return "I'm here to help! " + baseResponse + " Feel free to ask me anything you'd like assistance with.";
        }

        if (lowerInput.Contains("?"))
        {
            responseType = "Question";
            return baseResponse + " I hope this answers your question, but please let me know if you need more clarification.";
        }

        if (lowerInput.Contains("error") || lowerInput.Contains("problem") || lowerInput.Contains("issue"))
        {
            responseType = "Troubleshooting";
            return baseResponse + " Let's work through this step by step to identify and resolve the issue.";
        }

        responseType = "General";
        return baseResponse + " I'm simulating a response based on your input: \"" + userInput + "\".";
    }
}
