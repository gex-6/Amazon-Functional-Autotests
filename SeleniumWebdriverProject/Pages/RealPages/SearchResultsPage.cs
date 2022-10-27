namespace AmazonTests.Pages.RealPages
{
    internal class SearchResultsPage : WebPage
    {
        private IList<IWebElement> SearchResultItems => FindElements(By.XPath("//body/div[@id='a-page']/div[@id='search']"));

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<string> SearcResultsItemText()
        {
            return SearchResultItems
                .Select(item => item.Text.ToLower())
                .ToList();
        }

        public IList<string> SearchResultsItemsWithText(string searchPhrase)
        {
            return SearcResultsItemText()
                .Where(item => item.Contains(searchPhrase))
                .ToList();
        }
    }
}