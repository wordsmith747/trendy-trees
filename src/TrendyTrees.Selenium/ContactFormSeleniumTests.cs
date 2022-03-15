using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using Xunit.Abstractions;

namespace TrendyTrees.Selenium
{
    public class ContactFormSeleniumTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _siteUrl;

        public ContactFormSeleniumTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            new DriverManager().SetUpDriver(new ChromeConfig());

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .Build();

            _siteUrl = configuration["SiteUrl"];
        }

        [Fact]
        public void ContactForm_Submission_ThankYou()
        {
            const string expectedThankYouText = "Thank you";

            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl(Path.Join(_siteUrl, "AboutUs/Form_Success"));

            var thankYouPanel = driver.FindElement(By.Id("thankYouMessage"));

            _testOutputHelper.WriteLine($"Expected => {expectedThankYouText}");
            _testOutputHelper.WriteLine($"Actual => {thankYouPanel.Text}");

            Assert.Contains(expectedThankYouText, thankYouPanel.Text);

            driver.Quit();
        }

        [Fact]
        public void ContactForm_RequiredField_Name()
        {
            const string expectedValidationText = "This field is mandatory";

            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl(Path.Join(_siteUrl, "AboutUs"));

            var nameTextBox = driver.FindElement(By.Id("Name"));

            nameTextBox.SendKeys(Keys.Enter); // pressing the Enter key when the field has focus

            var validationSpan = driver.FindElement(By.Id("name-validation-msg"));

            _testOutputHelper.WriteLine($"Expected => {expectedValidationText}");
            _testOutputHelper.WriteLine($"Actual => {validationSpan.Text}");

            Assert.Equal(expectedValidationText, validationSpan.Text);

            driver.Quit();
        }

        [Fact]
        public void ContactForm_Clear_Previous_Unsubmitted_Details()
        {
            var driver = new ChromeDriver();

            // navigate to the home page so there is a known place to navigate "back" to
            driver.Navigate().GoToUrl(_siteUrl);

            driver.Navigate().GoToUrl(Path.Join(_siteUrl, "AboutUs"));

            var nameTextBox = driver.FindElement(By.Id("Name"));

            nameTextBox.SendKeys("Frederick" + Keys.Tab);

            // navigate back after entering text into a form field
            driver.Navigate().Back();

            driver.Navigate().GoToUrl(Path.Join(_siteUrl, "AboutUs"));

            nameTextBox = driver.FindElement(By.Id("Name"));

            // ensure text previously entered has been cleared
            Assert.Equal("", nameTextBox.Text);

            driver.Quit();
        }

        [Fact]
        public async Task Details_MainImage_Correct_Url()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl(Path.Join(_siteUrl, "Products/Details/1"));

            var mainProductImage = driver.FindElement(By.Id("mainProductImage"));

            var imageUrl = mainProductImage.GetAttribute("src");

            _testOutputHelper.WriteLine($"{nameof(imageUrl)} => {imageUrl}");

            using var client = new HttpClient();
            var response = await client.GetAsync(imageUrl);

            const string expectedHeaderName = "Content-Type";
            const string expectedHeaderValue = "image/jpeg";

            if (response.Content.Headers.TryGetValues(expectedHeaderName, out var contentTypeHeaderValues))
            {
                _testOutputHelper.WriteLine($"{expectedHeaderName} => {contentTypeHeaderValues.Single()}");
                Assert.Equal(expectedHeaderValue, contentTypeHeaderValues.Single());
            }
            else
            {
                throw new InvalidOperationException($"A '{expectedHeaderName}' header with the value '{expectedHeaderValue}' was not found.");
            }

            if (response.Content.Headers.TryGetValues("Content-Length", out var contentLengthHeaderValues))
            {
                _testOutputHelper.WriteLine($"Content-Length => {contentLengthHeaderValues.Single()}");
            };

            driver.Quit();
        }
    }
}