<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Tokero Playwright Tests Documentation</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 40px;
            background-color: #f4f4f4;
            color: #333;
        }
        h1, h2, h3 {
            color: #2c3e50;
        }
        a {
            color: #2980b9;
        }
        pre {
            background: #eee;
            padding: 10px;
            border-left: 5px solid #ccc;
            overflow-x: auto;
        }
        code {
            font-family: Consolas, monospace;
        }
        .file-section {
            margin-bottom: 50px;
        }
        .code-title {
            background: #2c3e50;
            color: #fff;
            padding: 10px;
            font-weight: bold;
        }
    </style>
</head>
<body>

    <h1>Tokero UI Tests using Microsoft.Playwright</h1>
    <p>Author: Cadar Achim</p>
    <p>GitHub Repository: 
        <a href="https://github.com/CadarAchim/TokeroTests" target="_blank">
            https://github.com/CadarAchim/TokeroTests
        </a>
    </p>

    <div class="file-section">
        <h2>HomePage.cs</h2>
        <p>Contains page object model (POM) for the homepage of <code>https://tokero.dev/en</code>. Includes locators and methods to interact with UI elements like cookie banners, modal overlays, and footer links.</p>
        <div class="code-title">Main Features</div>
        <ul>
            <li>Navigate to the homepage</li>
            <li>Accept cookie consent popup</li>
            <li>Close modal overlays</li>
            <li>Click footer links (Terms, Privacy, GDPR)</li>
            <li>Verify if a page contains specific text</li>
        </ul>
    </div>

    <div class="file-section">
        <h2>GDPR.cs</h2>
        <p>Tests that the GDPR page loads correctly and contains the text "GDPR".</p>
        <div class="code-title">Browsers Tested</div>
        <ul>
            <li>Chromium</li>
            <li>Firefox</li>
        </ul>
    </div>

    <div class="file-section">
        <h2>PrivacyAndPolicy.cs</h2>
        <p>Tests the Privacy Policy page loads correctly and contains the word "Privacy".</p>
        <div class="code-title">Browsers Tested</div>
        <ul>
            <li>Chromium</li>
            <li>Firefox</li>
        </ul>
    </div>

    <div class="file-section">
        <h2>TermsAndServices.cs</h2>
        <p>Tests the Terms and Conditions page loads correctly and includes the word "Terms".</p>
        <div class="code-title">Browsers Tested</div>
        <ul>
            <li>Chromium</li>
            <li>Firefox</li>
        </ul>
    </div>

    <div class="file-section">
        <h2>How It Works</h2>
        <ol>
            <li>Playwright launches the specified browser in non-headless mode.</li>
            <li>The homepage is opened and cookie or modal dialogs are dismissed if present.</li>
            <li>Click events trigger navigation to the appropriate policy page.</li>
            <li>The test asserts the presence of expected keywords on each page.</li>
        </ol>
    </div>

</body>
</html>
