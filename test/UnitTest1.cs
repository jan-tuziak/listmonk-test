using System.Text.RegularExpressions;

namespace ListmonkTest
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        public const string URL = "http://localhost:9000";
        // [SetUp]
        // public void Setup()
        // {
            
        // }

        [Test]
        public async Task ListmonkHasLogo()
        {
            await Page.GotoAsync(URL);
            var logo = Page.Locator("css=div.logo > a > img");
            await Expect(logo).ToBeVisibleAsync();
        }

        [Test]
        public async Task HasTitle()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }

        [Test]
        public async Task GetStartedLink()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Click the get started link.
            await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

            // Expects page to have a heading with the name of Installation.
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
        } 
    }
}