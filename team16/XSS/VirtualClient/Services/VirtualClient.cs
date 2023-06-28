using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;
using PlaywrightClient.Models;

namespace PlaywrightClient.Services
{
    public class VirtualClient : IVirtualClient
    {
        private readonly IOptionsMonitor<VirtualClientOptions> _clientOptions;
        public VirtualClient(IOptionsMonitor<VirtualClientOptions> clientOptions)
        {
            _clientOptions = clientOptions;
        }
        public async Task RunClientAsync()
        {
            Console.WriteLine("Executing client...");
            try
            {
                using (var playwright = await Playwright.CreateAsync())
                await using (var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = true
                }))
                {
                    var opts = _clientOptions.CurrentValue;

                    var page = await browser.NewPageAsync();
                    await page.GotoAsync($"{opts.ConnectionString}/account/login");
                    await page.Locator("[id='Username']").FillAsync(opts.Username);
                    await page.Locator("[id='Password']").FillAsync(opts.Password);
                    await page.Locator("[id='sign-in']").ClickAsync();
                    await page.GotoAsync($"{opts.ConnectionString}/board/board/{opts.TargetBoardId}");
                    await page.ScreenshotAsync(new()
                    {
                        Path = "screenshot.png",
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
