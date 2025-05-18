using System.Threading.Tasks;
using Microsoft.Playwright;
using TokeroTests.Pages;
using Xunit;

namespace TokeroTests.Tests
{
    public class PrivacyAndPolicy
    {
        [Theory]
        [InlineData("chromium")]
        [InlineData("firefox")]
        public async Task PrivacyPolicyPageLoadsCorrectly(string browserType)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await LaunchBrowserAsync(playwright, browserType);

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            var homePage = new HomePage(page);

            await homePage.NavigateAsync();
            await homePage.AcceptCookiesAsync();
            await homePage.CloseModalAsync();
            await homePage.ClickPrivacyLinkAsync();

            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

            Assert.True(await homePage.PageContainsTextAsync("Privacy"), $"{browserType}: Privacy Policy page content was not found.");

            await browser.CloseAsync();
        }

        private async Task<IBrowser> LaunchBrowserAsync(IPlaywright playwright, string browserType)
        {
            return browserType switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
                "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }),
                _ => throw new System.ArgumentException($"Invalid browser type: {browserType}")
            };
        }
    }
}
