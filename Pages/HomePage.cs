using Microsoft.Playwright;
using System.Threading.Tasks;

namespace TokeroTests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        // Cookie popup
        public ILocator CookieAcceptButton => _page.Locator("text=Accept All");

        // Modal overlay close button
        public ILocator ModalOverlayCloseButton => _page.Locator("div.modal_modalOverlay__pCvXk button");

        // Footer links
        public ILocator TermsLink => _page.Locator("footer >> text=Terms and Conditions");
        public ILocator PrivacyPolicyLink => _page.Locator("footer >> text=Privacy");
        public ILocator GDPRLink => _page.Locator("footer >> text=GDPR");

        // Navigate to home
        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://tokero.dev/en");
        }

        // Accept cookies if popup is shown
        public async Task AcceptCookiesAsync()
        {
            if (await CookieAcceptButton.IsVisibleAsync())
                await CookieAcceptButton.ClickAsync();
        }

        // Close overlay modal if shown
        public async Task CloseModalAsync()
        {
            if (await ModalOverlayCloseButton.IsVisibleAsync())
                await ModalOverlayCloseButton.ClickAsync();
        }

        // Click Terms and Conditions link
        public async Task ClickTermsLinkAsync()
        {
            await _page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
            await TermsLink.ClickAsync();
        }
        
        public async Task ClickPrivacyLinkAsync()
        {
            await _page.ClickAsync("footer >> text=Privacy"); // Adjust the selector as needed
        }

        public async Task ClickGDPRLinkAsync()
        {
            await _page.ClickAsync("footer >> text=GDPR"); // Adjust the selector as needed
        }

        // Utility to check if page contains text
        public async Task<bool> PageContainsTextAsync(string text)
        {
            var content = await _page.ContentAsync();
            return content.Contains(text, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
