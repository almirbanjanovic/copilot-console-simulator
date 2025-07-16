@echo off
REM Test runner script for Copilot Console Simulator (Windows)

echo 🧪 Running Unit Tests for Copilot Console Simulator
echo ==================================================

REM Navigate to test directory
cd tests\CopilotConsoleSimulator.Tests

REM Restore dependencies
echo 📦 Restoring test dependencies...
dotnet restore

REM Build test project
echo 🔨 Building test project...
dotnet build --no-restore

REM Run tests with verbose output
echo 🚀 Running tests...
dotnet test --no-build --verbosity normal --logger "console;verbosity=detailed"

REM Check exit code
if %ERRORLEVEL% EQU 0 (
    echo ✅ All tests passed!
) else (
    echo ❌ Some tests failed!
    exit /b 1
)
