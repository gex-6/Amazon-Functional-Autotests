namespace AmazonTests.Pages.RealPages
{
    public class HomePage : WebPage
    {
        private IWebElement searchInput => FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void PerformSearch(string searchPhrase)
        {
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);
        }
    }
}