using CopilotConsoleSimulator.Data;
using CopilotConsoleSimulator.Interfaces;
using CopilotConsoleSimulator.Services;

// Set up dependency injection manually using modern patterns
IConversationLogger logger = new JsonConversationLogger();
IResponseGenerator responseGenerator = new ResponseGeneratorService();
IPromptService promptService = new PromptService(logger, responseGenerator);

try
{
    // Start the interactive session
    await promptService.StartInteractiveSessionAsync();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Application error: {ex.Message}");
    Environment.Exit(1);
}
