namespace AmazonTests.Pages.RealPages
{
    internal class ItemPage : WebPage
    {
        private IWebElement buyingOptions => FindElement(By.XPath("//a[contains(text(),'See All Buying Options')]"));
        private IWebElement addToCartButton => FindElement(By.XPath("//input[@name='submit.addToCart']"));
        private IWebElement closePopUp => FindElement(By.XPath("//i[@aria-label='aod-close']"));

        public ItemPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddItemToCart()
        {
            buyingOptions.Click();
            addToCartButton.Click();
            closePopUp.Click();
        }
    }
}
