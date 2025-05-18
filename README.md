# 🧪 Testing Project Prerequisites Setup Guide
This guide walks you through setting up a local development environment to run a testing project using:
- .NET 8
- xUnit
- Microsoft Playwright (with NUnit support)

## ✅ Prerequisites
1. .NET 8 SDK
   - Ensure you have .NET 8 SDK installed.
    - Verify installation:
    --bash
      dotnet --version
2. Node.js (for Playwright)
   Playwright requires Node.js for installing its browser binaries.
   - Download from: https://nodejs.org/
   - Recommended version: 16.x or later
   - Verify:
   --bash node --version
3. Install Required NuGet Packages
   Run this from the project root:
   --bash
     dotnet restore
   or
    dotnet add package Microsoft.Playwright --version 1.52.0
    dotnet add package Microsoft.Playwright.NUnit --version 1.52.0
    dotnet add package xunit --version 2.9.3
    dotnet add package xunit.runner.visualstudio --version 3.1.0
4. Install Playwright Browsers
   Playwright needs to download and install its browser binaries:
   --bash
     playwright install
   or
   --bash
     dotnet tool install --global Microsoft.Playwright.CLI
     playwright install
5. Optional: Test Runner Support in IDE
   If you're using Visual Studio:
   - Make sure Test Explorer is enabled.
   - Install the xUnit Test Adapter if not already included.
   For Rider, VS Code, or other IDEs:
   - Install the appropriate .NET and xUnit extensions/plugins.
## 🧪 Running Tests
Once all dependencies are set up:
--bash
  dotnet test


     
     
  
