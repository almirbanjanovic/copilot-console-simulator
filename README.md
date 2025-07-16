# Copilot Console Simulator

A .NET 9.0 console application that simulates interactions with an AI assistant like GitHub Copilot. This project demonstrates dependency injection, interfaces, asynchronous programming, and unit testing patterns.

## Features

- Interactive console interface for chatting with a simulated AI assistant
- JSON-based conversation logging to file
- Contextual response generation based on user input keywords
- Session management with unique session IDs
- Unit tests with comprehensive coverage
- Clean architecture with proper separation of concerns

## Project Structure

```
├── .gitignore                       # Git ignore rules
├── CopilotConsoleSimulator.sln      # Visual Studio solution file
├── LICENSE                          # License file
├── README.md                        # This file
├── run-tests.bat                    # Windows test runner script
├── run-tests.sh                     # Unix test runner script
├── src/
│   └── CopilotConsoleSimulator/
│       ├── Data/                    # Data access layer
│       │   └── JsonConversationLogger.cs
│       ├── Interfaces/              # Interface definitions
│       │   ├── IConversationLogger.cs
│       │   ├── IPromptService.cs
│       │   └── IResponseGenerator.cs
│       ├── Models/                  # Data models
│       │   ├── ConversationLogEntry.cs
│       │   └── PromptModels.cs
│       ├── Services/                # Business logic
│       │   ├── PromptService.cs
│       │   └── ResponseGeneratorService.cs
│       ├── copilot-console-simulator.csproj  # Project file
│       └── Program.cs               # Application entry point
└── tests/
    └── CopilotConsoleSimulator.Tests/
        ├── Models/
        │   └── ModelTests.cs
        ├── Services/
        │   └── PromptServiceTests.cs
        └── CopilotConsoleSimulator.Tests.csproj  # Test project file
```

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or Visual Studio Code (optional)

### Building the Solution

```bash
# Clone the repository
git clone https://github.com/almirbanjanovic/copilot-console-simulator.git
cd copilot-console-simulator

# Restore packages and build
dotnet build

# Run tests
dotnet test

# Run the application
cd src/CopilotConsoleSimulator
dotnet run
```

### Using the Application

1. **Start the application**: Run `dotnet run` from the project directory
2. **Chat with the simulator**: Type your questions or messages
3. **Special commands**:
   - `history` - View conversation history for the current session
   - `clear` - Clear conversation history
   - `exit` - Exit the application

### Example Interaction

```
Welcome to the Copilot Console Simulator!
Session ID: abc123de
Type your questions or commands. Type 'exit' to quit.
Special commands: 'history' to view conversation history, 'clear' to clear history
----------------------------------------------------------------------

You: Hello, how are you?
Copilot: Great question! I think the key thing to consider is: When it comes to coding, I always recommend following best practices and writing clean, maintainable code.

You: Can you help me with a programming problem?
Copilot: I'm here to help! That's an interesting question! Let me think about that for a moment. Feel free to ask me anything you'd like assistance with.

You: history
--- Conversation History (Session: abc123de) ---
[14:30:15] You: Hello, how are you?
[14:30:16] Copilot: Great question! I think the key thing to consider is: When it comes to coding, I always recommend following best practices and writing clean, maintainable code.

[14:30:45] You: Can you help me with a programming problem?
[14:30:46] Copilot: I'm here to help! That's an interesting question! Let me think about that for a moment. Feel free to ask me anything you'd like assistance with.
--- End of History ---

You: exit
Thank you for using the Copilot Console Simulator!
```

## Architecture

### Dependency Injection

The application uses manual dependency injection in `Program.cs`:

```csharp
IConversationLogger logger = new JsonConversationLogger();
IResponseGenerator responseGenerator = new ResponseGeneratorService();
IPromptService promptService = new PromptService(logger, responseGenerator);
```

### Key Components

- **IPromptService**: Handles user input and orchestrates response generation
- **IResponseGenerator**: Generates contextual responses based on user input
- **IConversationLogger**: Persists conversation history to JSON file
- **Models**: Define data structures for requests, responses, and log entries

### Response Generation

The simulator generates contextual responses based on keywords in user input:

- **Programming keywords** (`code`, `programming`) → Programming advice
- **Help keywords** (`help`, `assist`) → Helpful responses
- **Questions** (contains `?`) → Question acknowledgment
- **Problems** (`error`, `problem`, `issue`) → Troubleshooting guidance
- **Default** → General simulated response

## Testing

The project includes comprehensive unit tests using xUnit:

```bash
# Run all tests
dotnet test

# Run tests with coverage (if coverlet is installed)
dotnet test --collect:"XPlat Code Coverage"
```

### Alternative: Using the test scripts

You can also use the provided test runner scripts:

**Windows:**
```cmd
run-tests.bat
```

**Unix/Linux/macOS:**
```bash
chmod +x run-tests.sh
./run-tests.sh
```

### Test Coverage

- **Model Tests**: Verify data model behavior and property setting
- **Service Tests**: Test prompt processing, response generation, and error handling
- **Mock Implementations**: Isolated testing with test doubles

## Configuration

### Logging

Conversation logs are saved to `conversation_log.json` in the application directory. The file format is:

```json
[
  {
    "timestamp": "2025-07-16T14:30:15.123Z",
    "userInput": "Hello, how are you?",
    "response": "Great question! I think...",
    "responseTime": 750,
    "sessionId": "abc123de"
  }
]
```

### Customization

- **Response Templates**: Add custom response templates through `IResponseGenerator.AddResponseTemplate()`
- **Logger Implementation**: Implement `IConversationLogger` for different storage backends
- **Response Logic**: Modify `ResponseGeneratorService` for different response patterns

## Contributing

1. Fork the repository
2. Create a feature branch
3. Add tests for new functionality
4. Ensure all tests pass
5. Submit a pull request

## License

This project is provided as-is for educational and demonstration purposes.
