#!/bin/bash

# Test runner script for Copilot Console Simulator

echo "🧪 Running Unit Tests for Copilot Console Simulator"
echo "=================================================="

# Navigate to test directory
cd Tests

# Restore dependencies
echo "📦 Restoring test dependencies..."
dotnet restore

# Build test project
echo "🔨 Building test project..."
dotnet build --no-restore

# Run tests with verbose output
echo "🚀 Running tests..."
dotnet test --no-build --verbosity normal --logger "console;verbosity=detailed"

# Check exit code
if [ $? -eq 0 ]; then
    echo "✅ All tests passed!"
else
    echo "❌ Some tests failed!"
    exit 1
fi
