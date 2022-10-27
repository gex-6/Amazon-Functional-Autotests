namespace AmazonTests.Pages
{
    public class WebPage
    {
        private readonly IWebDriver driver;

        protected WebPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected IWebElement FindElement(By Selector)
        {
            return driver.FindElement(Selector);
        }

        protected IList<IWebElement> FindElements(By Selector)
        {
            return driver.FindElements(Selector);
        }
    }
}
