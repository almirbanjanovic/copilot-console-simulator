using CopilotConsoleSimulator.Models;
using Xunit;

namespace CopilotConsoleSimulator.Tests.Models;

public class ModelTests
{
    [Fact]
    public void ConversationLogEntry_PropertiesCanBeSet()
    {
        // Arrange
        var sessionId = "test-session-123";
        var userInput = "Hello world";
        var response = "Hello! How can I help you?";
        var responseTime = 500;
        var timestamp = DateTime.UtcNow;

        // Act
        var entry = new ConversationLogEntry
        {
            SessionId = sessionId,
            UserInput = userInput,
            Response = response,
            ResponseTime = responseTime,
            Timestamp = timestamp
        };

        // Assert
        Assert.Equal(sessionId, entry.SessionId);
        Assert.Equal(userInput, entry.UserInput);
        Assert.Equal(response, entry.Response);
        Assert.Equal(responseTime, entry.ResponseTime);
        Assert.Equal(timestamp, entry.Timestamp);
    }

    [Fact]
    public void ConversationLogEntry_DefaultValues_AreEmpty()
    {
        // Act
        var entry = new ConversationLogEntry();

        // Assert
        Assert.Equal(string.Empty, entry.UserInput);
        Assert.Equal(string.Empty, entry.Response);
        Assert.Equal(string.Empty, entry.SessionId);
        Assert.Equal(0, entry.ResponseTime);
    }

    [Fact]
    public void PromptRequest_PropertiesCanBeSet()
    {
        // Arrange
        var input = "What is the weather?";
        var sessionId = "session-456";
        var requestTime = DateTime.UtcNow;

        // Act
        var prompt = new PromptRequest
        {
            Input = input,
            SessionId = sessionId,
            RequestTime = requestTime
        };

        // Assert
        Assert.Equal(input, prompt.Input);
        Assert.Equal(sessionId, prompt.SessionId);
        Assert.Equal(requestTime, prompt.RequestTime);
    }

    [Fact]
    public void PromptRequest_DefaultValues_AreEmpty()
    {
        // Act
        var prompt = new PromptRequest();

        // Assert
        Assert.Equal(string.Empty, prompt.Input);
        Assert.Equal(string.Empty, prompt.SessionId);
        Assert.NotNull(prompt.Metadata);
        Assert.Empty(prompt.Metadata);
    }

    [Fact]
    public void PromptResponse_PropertiesCanBeSet()
    {
        // Arrange
        var response = "I'm doing well, thank you!";
        var responseTime = DateTime.UtcNow;
        var processingTime = 750;
        var responseType = "Greeting";
        var isSuccess = true;

        // Act
        var promptResponse = new PromptResponse
        {
            Response = response,
            ResponseTime = responseTime,
            ProcessingTimeMs = processingTime,
            ResponseType = responseType,
            IsSuccess = isSuccess
        };

        // Assert
        Assert.Equal(response, promptResponse.Response);
        Assert.Equal(responseTime, promptResponse.ResponseTime);
        Assert.Equal(processingTime, promptResponse.ProcessingTimeMs);
        Assert.Equal(responseType, promptResponse.ResponseType);
        Assert.True(promptResponse.IsSuccess);
    }

    [Fact]
    public void PromptResponse_DefaultValues_AreSet()
    {
        // Act
        var response = new PromptResponse();

        // Assert
        Assert.Equal(string.Empty, response.Response);
        Assert.Equal("Default", response.ResponseType);
        Assert.True(response.IsSuccess);
        Assert.Equal(0, response.ProcessingTimeMs);
    }
}
