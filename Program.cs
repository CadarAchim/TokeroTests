using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // Set to true to run headless
        });

        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        // Step 1: Go to the staging site
        await page.GotoAsync("https://tokero.dev/en");

        // Step 2: Handle cookie consent popup if present
        var cookieAcceptButton = page.Locator("text=Accept All");
        if (await cookieAcceptButton.IsVisibleAsync())
        {
            await cookieAcceptButton.ClickAsync();
            Console.WriteLine("✅ Cookie popup dismissed.");
        }

        // Step 3: Handle modal overlay if present
        var modalOverlayCloseButton = page.Locator("div.modal_modalOverlay__pCvXk button");
        if (await modalOverlayCloseButton.IsVisibleAsync())
        {
            await modalOverlayCloseButton.ClickAsync();
            Console.WriteLine("✅ Modal overlay closed.");
        }

        // Step 4: Scroll to footer
        await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");

        // Step 5: Click "Terms and Conditions"
        var termsLink = page.Locator("footer >> text=Terms and Conditions");
        await termsLink.ClickAsync();

        // Step 6: Wait for navigation to complete
        await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        // Step 7: Validate presence of expected content
        var content = await page.ContentAsync();
        if (content.Contains("Terms", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("✅ Terms and Conditions page loaded and contains expected content.");
        }
        else
        {
            Console.WriteLine("❌ Content not found.");
        }

        // Optional pause for visual confirmation
        await Task.Delay(5000);

        await browser.CloseAsync();
    }
}
