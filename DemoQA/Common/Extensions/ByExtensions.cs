using OpenQA.Selenium;

namespace DemoQA.Common.Extensions
{
    public static class ByExtensions
    {
        public static string GetLocator(this By by)
        {
            var locator = by.ToString();

            return locator.Substring(locator.IndexOf(" ", StringComparison.Ordinal));
        }
    }
}
