<!DOCTYPE html> <html lang="en"> <head> <meta charset="UTF-8"> <meta name="viewport" content="width=device-width, initial-scale=1.0"> <title>Tokero Website Automation Test Documentation</title> <style> body { font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif; line-height: 1.6; color: #333; max-width: 1000px; margin: 0 auto; padding: 20px; } h1 { color: #0366d6; border-bottom: 1px solid #eaecef; padding-bottom: 0.3em; } h2 { color: #0366d6; border-bottom: 1px solid #eaecef; padding-bottom: 0.3em; margin-top: 24px; } h3 { margin-top: 20px; color: #24292e; } h4 { margin-top: 18px; color: #24292e; } code { font-family: 'SFMono-Regular', Consolas, 'Liberation Mono', Menlo, Courier, monospace; background-color: #f6f8fa; padding: 2px 4px; border-radius: 3px; font-size: 85%; } pre { background-color: #f6f8fa; border-radius: 3px; padding: 16px; overflow: auto; line-height: 1.45; } pre code { background-color: transparent; padding: 0; } ul, ol { padding-left: 2em; } .emoji { font-size: 1.2em; margin-right: 8px; } .steps { list-style-type: decimal; padding-left: 20px; } .method { font-weight: bold; color: #0366d6; } .note { background-color: #f8f9fa; border-left: 4px solid #0366d6; padding: 12px; margin: 16px 0; } .container { margin-bottom: 30px; } /* For code block styling */ .code-block { background-color: #f6f8fa; padding: 16px; border-radius: 6px; overflow-x: auto; } </style> </head> <body> <h1><span class="emoji">🚀</span> Tokero Website Automation Test Documentation</h1>
<div class="container">
    <h2><span class="emoji">📋</span> Project Overview</h2>
    <p>
        This documentation describes an automated testing framework developed for the Tokero website 
        (<a href="https://tokero.dev/en" target="_blank">https://tokero.dev/en</a>) using Microsoft Playwright 
        with C# and xUnit. The framework follows the Page Object Model design pattern to create maintainable 
        and scalable automated tests.
    </p>
</div>

<div class="container">
    <h2><span class="emoji">🛠️</span> Technology Stack</h2>
    <ul>
        <li><strong>Programming Language</strong>: C# (.NET 8.0)</li>
        <li><strong>Test Framework</strong>: xUnit (v2.9.3)</li>
        <li><strong>Browser Automation</strong>: Microsoft Playwright (v1.52.0)</li>
        <li><strong>Design Pattern</strong>: Page Object Model (POM)</li>
        <li><strong>Supported Browsers</strong>: Chromium, Firefox</li>
    </ul>
</div>

<div class="container">
    <h2><span class="emoji">📁</span> Project Structure</h2>
    <p>The project follows a clean, organized structure:</p>
    <pre><code>TokeroTests/
├── Pages/ │ └── HomePage.cs ├── Tests/ │ ├── GDPR.cs │ ├── PrivacyAndPolicy.cs │ └── TermsAndServices.cs ├── TokeroTests.csproj</code></pre>

    <h3><span class="emoji">🧩</span> Key Components</h3>

    <h4>1. Page Objects</h4>
    <p>
        The Page Object Model pattern is implemented to encapsulate page-specific elements and actions:
    </p>
    <ul>
        <li><strong>HomePage.cs</strong>: Contains locators and methods for interacting with elements on the Tokero homepage</li>
    </ul>

    <h4>2. Test Classes</h4>
    <p>Test classes are organized by feature/functionality:</p>
    <ul>
        <li><strong>GDPR.cs</strong>: Tests for the GDPR page functionality</li>
        <li><strong>PrivacyAndPolicy.cs</strong>: Tests for the Privacy Policy page functionality</li>
        <li><strong>TermsAndServices.cs</strong>: Tests for the Terms and Conditions page functionality</li>
    </ul>
</div>

<div class="container">
    <h2><span class="emoji">🔍</span> Implementation Details</h2>

    <h3><span class="emoji">🖥️</span> Page Object Implementation</h3>
    <p>
        The page objects utilize Playwright's locators to identify elements on the page and provide methods 
        to interact with them. For example, the <code>HomePage</code> class encapsulates:
    </p>
    <ul>
        <li><strong>Element Locators</strong>: Selectors for key page elements like cookie acceptance buttons, navigation links, and modal overlays</li>
        <li><strong>Navigation Methods</strong>: Methods to navigate to pages and perform common actions</li>
        <li><strong>Utility Methods</strong>: Helper functions to check page content and handle common scenarios</li>
    </ul>

    <h3><span class="emoji">⚙️</span> Test Implementation</h3>
    <p>
        Tests are implemented using xUnit with the Theory attribute to enable parameterized testing across 
        different browsers. Each test:
    </p>
    <ol class="steps">
        <li>Initializes Playwright and launches the specified browser</li>
        <li>Creates a new browser context and page</li>
        <li>Performs test-specific actions using Page Object methods</li>
        <li>Validates expected behaviors using assertions</li>
        <li>Properly closes browser resources</li>
    </ol>

    <h3><span class="emoji">🌐</span> Cross-browser Testing</h3>
    <p>
        The tests use xUnit's Theory attribute with InlineData to run the same test on multiple browsers:
    </p>
    <div class="code-block">
        <pre><code>[Theory]
[InlineData("chromium")] [InlineData("firefox")] public async Task TermsAndConditionsPageLoadsCorrectly(string browserType)</code></pre> </div> <p>This enables efficient testing across different browser engines without duplicating test code.</p> </div>

<div class="container">
    <h2><span class="emoji">📝</span> Test Cases</h2>

    <h3><span class="emoji">🔗</span> Footer Link Navigation Tests</h3>

    <h4><span class="emoji">✅</span> Terms and Conditions Page Test</h4>
    <p>Validates that the Terms and Conditions page loads correctly when clicking the footer link.</p>
    <p><strong>Steps:</strong></p>
    <ol class="steps">
        <li>Navigate to the Tokero homepage</li>
        <li>Handle cookie consent prompt if displayed</li>
        <li>Close any modal overlays if present</li>
        <li>Click the Terms and Conditions footer link</li>
        <li>Verify the page content contains "Terms"</li>
    </ol>

    <h4><span class="emoji">✅</span> Privacy Policy Page Test</h4>
    <p>Validates that the Privacy Policy page loads correctly when clicking the footer link.</p>
    <p><strong>Steps:</strong></p>
    <ol class="steps">
        <li>Navigate to the Tokero homepage</li>
        <li>Handle cookie consent prompt if displayed</li>
        <li>Close any modal overlays if present</li>
        <li>Click the Privacy Policy footer link</li>
        <li>Verify the page content contains "Privacy"</li>
    </ol>

    <h4><span class="emoji">✅</span> GDPR Page Test</h4>
    <p>Validates that the GDPR page loads correctly when clicking the footer link.</p>
    <p><strong>Steps:</strong></p>
    <ol class="steps">
        <li>Navigate to the Tokero homepage</li>
        <li>Handle cookie consent prompt if displayed</li>
        <li>Close any modal overlays if present</li>
        <li>Click the GDPR footer link</li>
        <li>Verify the page content contains "GDPR"</li>
    </ol>
</div>

<div class="container">
    <h2><span class="emoji">🔧</span> Common Test Utilities</h2>

    <h3><span class="emoji">🌟</span> Browser Initialization</h3>
    <p>Each test class contains a helper method to initialize the browser based on the specified browser type:</p>
    <div class="code-block">
        <pre><code>private async Task&lt;IBrowser&gt; LaunchBrowserAsync(IPlaywright playwright, string browserType)
{ return browserType switch { "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }), "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }), _ => throw new System.ArgumentException($"Invalid browser type: {browserType}") }; }</code></pre> </div>

    <h3><span class="emoji">🔍</span> Page Content Verification</h3>
    <p>The HomePage class includes a utility method to verify page content:</p>
    <div class="code-block">
        <pre><code>public async Task&lt;bool&gt; PageContainsTextAsync(string text)
{ var content = await _page.ContentAsync(); return content.Contains(text, System.StringComparison.OrdinalIgnoreCase); }</code></pre> </div>

    <h3><span class="emoji">🖱️</span> Common Page Interactions</h3>
    <p>The framework implements reusable methods for common interactions:</p>
    <ul>
        <li><span class="method">AcceptCookiesAsync()</span>: Handles cookie consent dialogs</li>
        <li><span class="method">CloseModalAsync()</span>: Closes modal overlays when present</li>
        <li><span class="method">NavigateAsync()</span>: Navigates to the home page URL</li>
    </ul>
</div>

<div class="container">
    <h2><span class="emoji">▶️</span> Running the Tests</h2>

    <h3><span class="emoji">📋</span> Prerequisites</h3>
    <ol>
        <li>.NET 8.0 SDK installed</li>
        <li>Playwright browsers installed using the Playwright CLI</li>
    </ol>

    <h3><span class="emoji">🚀</span> Setup Instructions</h3>
    <ol>
        <li>
            Clone the repository:
            <div class="code-block">
                <pre><code>git clone https://github.com/CadarAchim/TokeroTests.git</code></pre>
            </div>
        </li>
        <li>
            Install Playwright browsers:
            <div class="code-block">
                <pre><code>pwsh bin/Debug/net8.0/playwright.ps1 install</code></pre>
            </div>
            or
            <div class="code-block">
                <pre><code>playwright install</code></pre>
            </div>
        </li>
        <li>
            Build the project:
            <div class="code-block">
                <pre><code>dotnet build</code></pre>
            </div>
        </li>
        <li>
            Run the tests:
            <div class="code-block">
                <pre><code>dotnet test</code></pre>
            </div>
        </li>
    </ol>
</div>

<div class="container">
    <h2><span class="emoji">🚀</span> Future Enhancements</h2>
    <p>Potential areas for extending the test framework:</p>
    <ol>
        <li><strong>Additional Page Objects</strong>: Create new page objects for other sections of the Tokero website</li>
        <li><strong>Data-Driven Testing</strong>: Implement more complex data scenarios using xUnit's data providers</li>
        <li><strong>Visual Testing</strong>: Add visual comparison testing capabilities</li>
        <li><strong>Reporting</strong>: Integrate with a reporting framework to generate detailed test reports</li>
        <li><strong>CI/CD Integration</strong>: Set up automated test execution in CI/CD pipelines</li>
        <li><strong>Test Configuration</strong>: Implement configuration files for test environment settings</li>
        <li><strong>Additional Browsers</strong>: Extend browser support to include WebKit</li>
    </ol>
</div>

<div class="container">
    <h2><span class="emoji">✨</span> Best Practices Implemented</h2>
    <ol>
        <li><strong>Page Object Model</strong>: Separation of test logic from page interactions</li>
        <li><strong>Cross-Browser Testing</strong>: Tests run on multiple browser engines</li>
        <li><strong>Asynchronous Operations</strong>: Proper use of async/await for all browser interactions</li>
        <li><strong>Resource Management</strong>: Proper initialization and disposal of browser resources</li>
        <li><strong>Parameterized Tests</strong>: Use of xUnit Theory to reduce code duplication</li>
        <li><strong>Dynamic Waiting</strong>: Appropriate use of wait states for page loading</li>
        <li><strong>Defensive Coding</strong>: Handling of conditional UI elements like cookie notices and modals</li>
    </ol>
</div>

<div class="container">
    <h2><span class="emoji">🏁</span> Conclusion</h2>
    <p>
        This test automation framework provides a solid foundation for testing the Tokero website across 
        multiple browsers. The implementation follows industry best practices for UI automation testing, 
        creating maintainable and reliable tests that can be extended as the application evolves.
    </p>
</div>
</body> </html>
