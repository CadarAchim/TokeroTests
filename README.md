🚀 Tokero Website Automation Test Documentation
📋 Project Overview
This documentation describes an automated testing framework developed for the Tokero website (https://tokero.dev/en) using Microsoft Playwright with C# and xUnit. The framework follows the Page Object Model design pattern to create maintainable and scalable automated tests.

🛠️ Technology Stack
Programming Language: C# (.NET 8.0)
Test Framework: xUnit (v2.9.3)
Browser Automation: Microsoft Playwright (v1.52.0)
Design Pattern: Page Object Model (POM)
Supported Browsers: Chromium, Firefox
📁 Project Structure
The project follows a clean, organized structure:

TokeroTests/
├── Pages/
│   └── HomePage.cs
├── Tests/
│   ├── GDPR.cs
│   ├── PrivacyAndPolicy.cs
│   └── TermsAndServices.cs
├── TokeroTests.csproj
🧩 Key Components
1. Page Objects
The Page Object Model pattern is implemented to encapsulate page-specific elements and actions:

HomePage.cs: Contains locators and methods for interacting with elements on the Tokero homepage
2. Test Classes
Test classes are organized by feature/functionality:

GDPR.cs: Tests for the GDPR page functionality
PrivacyAndPolicy.cs: Tests for the Privacy Policy page functionality
TermsAndServices.cs: Tests for the Terms and Conditions page functionality
🔍 Implementation Details
🖥️ Page Object Implementation
The page objects utilize Playwright's locators to identify elements on the page and provide methods to interact with them. For example, the HomePage class encapsulates:

Element Locators: Selectors for key page elements like cookie acceptance buttons, navigation links, and modal overlays
Navigation Methods: Methods to navigate to pages and perform common actions
Utility Methods: Helper functions to check page content and handle common scenarios
⚙️ Test Implementation
Tests are implemented using xUnit with the Theory attribute to enable parameterized testing across different browsers. Each test:

Initializes Playwright and launches the specified browser
Creates a new browser context and page
Performs test-specific actions using Page Object methods
Validates expected behaviors using assertions
Properly closes browser resources
🌐 Cross-browser Testing
The tests use xUnit's Theory attribute with InlineData to run the same test on multiple browsers:

csharp
[Theory]
[InlineData("chromium")]
[InlineData("firefox")]
public async Task TermsAndConditionsPageLoadsCorrectly(string browserType)
This enables efficient testing across different browser engines without duplicating test code.

📝 Test Cases
🔗 Footer Link Navigation Tests
✅ Terms and Conditions Page Test
Validates that the Terms and Conditions page loads correctly when clicking the footer link.

Steps:

Navigate to the Tokero homepage
Handle cookie consent prompt if displayed
Close any modal overlays if present
Click the Terms and Conditions footer link
Verify the page content contains "Terms"
✅ Privacy Policy Page Test
Validates that the Privacy Policy page loads correctly when clicking the footer link.

Steps:

Navigate to the Tokero homepage
Handle cookie consent prompt if displayed
Close any modal overlays if present
Click the Privacy Policy footer link
Verify the page content contains "Privacy"
✅ GDPR Page Test
Validates that the GDPR page loads correctly when clicking the footer link.

Steps:

Navigate to the Tokero homepage
Handle cookie consent prompt if displayed
Close any modal overlays if present
Click the GDPR footer link
Verify the page content contains "GDPR"
🔧 Common Test Utilities
🌟 Browser Initialization
Each test class contains a helper method to initialize the browser based on the specified browser type:

csharp
private async Task<IBrowser> LaunchBrowserAsync(IPlaywright playwright, string browserType)
{
    return browserType switch
    {
        "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
        _ => throw new System.ArgumentException($"Invalid browser type: {browserType}")
    };
}
🔍 Page Content Verification
The HomePage class includes a utility method to verify page content:

csharp
public async Task<bool> PageContainsTextAsync(string text)
{
    var content = await _page.ContentAsync();
    return content.Contains(text, System.StringComparison.OrdinalIgnoreCase);
}
🖱️ Common Page Interactions
The framework implements reusable methods for common interactions:

AcceptCookiesAsync(): Handles cookie consent dialogs
CloseModalAsync(): Closes modal overlays when present
NavigateAsync(): Navigates to the home page URL
▶️ Running the Tests
📋 Prerequisites
.NET 8.0 SDK installed
Playwright browsers installed using the Playwright CLI
🚀 Setup Instructions
Clone the repository:
git clone https://github.com/CadarAchim/TokeroTests.git
Install Playwright browsers:
pwsh bin/Debug/net8.0/playwright.ps1 install
or
playwright install
Build the project:
dotnet build
Run the tests:
dotnet test
🚀 Future Enhancements
Potential areas for extending the test framework:

Additional Page Objects: Create new page objects for other sections of the Tokero website
Data-Driven Testing: Implement more complex data scenarios using xUnit's data providers
Visual Testing: Add visual comparison testing capabilities
Reporting: Integrate with a reporting framework to generate detailed test reports
CI/CD Integration: Set up automated test execution in CI/CD pipelines
Test Configuration: Implement configuration files for test environment settings
Additional Browsers: Extend browser support to include WebKit
✨ Best Practices Implemented
Page Object Model: Separation of test logic from page interactions
Cross-Browser Testing: Tests run on multiple browser engines
Asynchronous Operations: Proper use of async/await for all browser interactions
Resource Management: Proper initialization and disposal of browser resources
Parameterized Tests: Use of xUnit Theory to reduce code duplication
Dynamic Waiting: Appropriate use of wait states for page loading
Defensive Coding: Handling of conditional UI elements like cookie notices and modals
🏁 Conclusion
This test automation framework provides a solid foundation for testing the Tokero website across multiple browsers. The implementation follows industry best practices for UI automation testing, creating maintainable and reliable tests that can be extended as the application evolves.

