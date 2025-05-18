# 🧪 Testing Project Prerequisites Setup Guide
This guide walks you through setting up a local development environment to run a testing project using:
- .NET 8
- xUnit
- Microsoft Playwright (with NUnit support)

## ✅ Prerequisites
1. .NET 8 SDK
   - Ensure you have .NET 8 SDK installed.
   - Verify installation:
      dotnet --version
2. Node.js (for Playwright)
   Playwright requires Node.js for installing its browser binaries.
   - Download from: https://nodejs.org/
   - Recommended version: 16.x or later
   - Verify:
   node --version
3. Install Required NuGet Packages
   Run this from the project root:
     dotnet restore
   or
    - dotnet add package Microsoft.Playwright --version 1.52.0
    - dotnet add package Microsoft.Playwright.NUnit --version 1.52.0
    - dotnet add package xunit --version 2.9.3
    - dotnet add package xunit.runner.visualstudio --version 3.1.0
4. Install Playwright Browsers
   Playwright needs to download and install its browser binaries:
     - playwright install
   or
     - dotnet tool install --global Microsoft.Playwright.CLI
     - playwright install
5. Optional: Test Runner Support in IDE
   If you're using Visual Studio:
   - Make sure Test Explorer is enabled.
   - Install the xUnit Test Adapter if not already included.
   For Rider, VS Code, or other IDEs:
   - Install the appropriate .NET and xUnit extensions/plugins.
## 🧪 Running Tests
Once all dependencies are set up:
  - dotnet test

# 📄 HomePage Class
The HomePage class represents the Home page of the Tokero website (https://tokero.dev/en) and encapsulates actions and element selectors used in automated UI testing with Microsoft Playwright.

## ✅ Purpose
This class is designed to:
- Navigate to the Tokero homepage
- Handle common UI elements such as cookie banners and modal overlays
- Interact with footer links (Terms, Privacy Policy, GDPR)
- Validate textual content on the page

# 🔍 GDPR Test Class
The GDPR test class is a cross-browser automated UI test that verifies the correct loading of the GDPR page on the Tokero website using Playwright and xUnit.

## ✅ Purpose
This test ensures that the GDPR page loads correctly and contains expected text when accessed via different browsers (Chromium and Firefox). It uses the HomePage page object to interact with the UI. 

## 🧪 Test Method
GdprPageLoadsCorrectly(string browserType)
Type: [Theory] test with [InlineData] for cross-browser validation.
Browsers Tested:
- chromium
- firefox
Steps Performed:
- Launches Playwright with the selected browser.
- Creates a new browser context and page.
- Navigates to the home page.
- Accepts cookie consent if shown.
- Closes modal overlay if present.
- Clicks on the GDPR footer link.
- Waits for the page content to load (DOMContentLoaded).
- Asserts that the page contains the string "GDPR".

# PrivacyAndPolicy Test Class
The PrivacyAndPolicy test class verifies that the Privacy Policy page on the Tokero website loads correctly and contains expected content. It uses Playwright with xUnit for cross-browser automated UI testing.

## ✅ Purpose
Ensure that the Privacy Policy page:
- Can be accessed via the homepage's footer.
- Loads successfully in both Chromium and Firefox.
- Contains the expected "Privacy" content.

🧪 Test Method
PrivacyPolicyPageLoadsCorrectly(string browserType)
Type: [Theory] with [InlineData] for multi-browser testing.

Browsers Tested:
- chromium
- firefox

## ✅ Steps:
Creates a Playwright instance and launches the specified browser.
- Creates a new browser context and page.
- Navigates to the Tokero homepage.
- Accepts the cookie consent (if displayed).
- Closes any modal overlays (if displayed).
- Clicks the Privacy link in the footer.
- Waits for the page to fully load (DOMContentLoaded).
- Verifies that the page contains the word "Privacy".

# TermsAndServices Test Class
The TermsAndServices class performs a cross-browser test using Playwright and xUnit to verify that the Terms and Conditions page on the Tokero website loads correctly and displays the expected content.

✅ Purpose
To confirm that:
- The Terms and Conditions page is accessible via the homepage footer.
- It loads correctly in multiple browsers.
- The content of the page includes the word "Terms".

🧪 Test Method
TermsAndConditionsPageLoadsCorrectly(string browserType)
Type: Parameterized [Theory] test with [InlineData].

Browsers Tested:
- chromium
- firefox

## 📝 Steps Performed:
Launches Playwright and initializes the selected browser.
- Creates a browser context and a new page.
- Uses the HomePage object to:
- Navigate to the Tokero homepage
- Accept cookies (if prompted)
- Close any modal overlay (if present)
- Click the Terms and Conditions footer link
- Waits for the page to fully load (DOMContentLoaded).
- Asserts the presence of the word "Terms" in the page content.
