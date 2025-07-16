using CopilotConsoleSimulator.Data;
using CopilotConsoleSimulator.Interfaces;
using CopilotConsoleSimulator.Services;

// Set up dependency injection manually
IConversationLogger logger = new JsonConversationLogger();
IResponseGenerator responseGenerator = new ResponseGeneratorService();
IPromptService promptService = new PromptService(logger, responseGenerator);

// Start the interactive session
await promptService.StartInteractiveSessionAsync();
