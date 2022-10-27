namespace AmazonTests
{
    public class AmazonTests
    {
        private static IWebDriver driver;

        private const string _searchPhrase = "iphone";
        private const string _buyItem = "https://amzn.to/3yWQPIb";
        private readonly By _itemsInCart = By.XPath("//span[@id='nav-cart-count']");

        [OneTimeSetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void CheckAmazonSearch()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            var homePage = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);

            homePage.PerformSearch(_searchPhrase);

            var actualSearchItems = searchResultsPage.SearcResultsItemText();
            var expectedSearchItems = searchResultsPage.SearchResultsItemsWithText(_searchPhrase);

            Assert.That(actualSearchItems, Is.EqualTo(expectedSearchItems));
        }

        [Test]
        public void CheckAmazonAddToCart()
        {
            driver.Navigate().GoToUrl(_buyItem);

            var itemPage = new ItemPage(driver);
            itemPage.AddItemToCart();

            Thread.Sleep(2000);

            var actualItemsInCart = driver.FindElement(_itemsInCart).Text;
            var actualAmount = Convert.ToInt32(actualItemsInCart);

            Assert.True(actualAmount > 0);            
        }

        [OneTimeTearDown]
        public static void TearDownDriver()
        {
            driver.Quit();
        }
    }
}