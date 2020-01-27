using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Models;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Portfolio.Models.Data;

namespace Portfolio.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           
            using (var context = new StockContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StockContext>>()))
            {



                if (context.Stock.Any())
                {
                    return;   // DB has been seeded
                }



                ChromeOptions options = new ChromeOptions();
                options.AddArgument("no-sandbox");


                IWebDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(1200));

                driver.Navigate().GoToUrl("https://finance.yahoo.com/");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1200);

                WebDriverWait waitLogin = new WebDriverWait(driver, TimeSpan.FromMinutes(30));
                waitLogin.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("uh-signedin")));

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(10);


                IWebElement loginButton = driver.FindElement(By.Id("uh-signedin"));
                loginButton.Click();

                WebDriverWait waitEnterUsername = new WebDriverWait(driver, TimeSpan.FromMinutes(50));
                waitEnterUsername.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-username")));

                IWebElement userName = driver.FindElement(By.Id("login-username"));

                userName.SendKeys("xaviercarty@yahoo.com");
                userName.SendKeys(Keys.Enter);

                WebDriverWait waitEnterPassword = new WebDriverWait(driver, TimeSpan.FromMinutes(50));
                waitEnterPassword.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-passwd")));
                IWebElement password = driver.FindElement(By.Id("login-passwd"));

                password.SendKeys("Soccer_1995");
                password.SendKeys(Keys.Enter);

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(10);

                driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

                driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(10);

                WebDriverWait waitDataTable = new WebDriverWait(driver, TimeSpan.FromMinutes(50));
                waitDataTable.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//tr")));

                IWebElement stockTable = driver.FindElement(By.XPath("//tbody"));
                List<IWebElement> stocks = driver.FindElements(By.XPath("//tr")).ToList();

                List<IWebElement> rows = stockTable.FindElements(By.XPath("//tr")).ToList();
                int rowsCount = rows.Count;










                for (int row = 1; row < rowsCount; row++)
                {
                    List<IWebElement> cells = rows.ElementAt(row).FindElements(By.TagName("td")).ToList();
                    int cellsCount = cells.Count;




                    string SymbolData = cells.ElementAt(0).Text;
                    //Console.WriteLine("Symbol: " + SymbolData);
                    string LastPriceData = cells.ElementAt(1).Text;
                    //Console.WriteLine("Last Price: " + LastPriceData);
                    string ChangeData = cells.ElementAt(2).Text;
                    //Console.WriteLine("Change: " + ChangeData);
                    string ChangeRateData = cells.ElementAt(3).Text;
                    //Console.WriteLine("Change Rate: " + ChangeRateData);
                    string CurrencyData = cells.ElementAt(4).Text;
                    //Console.WriteLine("Currency: " + CurrencyData);
                    string MarketTimeData = cells.ElementAt(5).Text;
                    //Console.WriteLine("Market Time: " + MarketTimeData);
                    string VolumeData = cells.ElementAt(6).Text;
                    //Console.WriteLine("Volume: " + VolumeData);
                    string ShareData = cells.ElementAt(7).Text;
                    //Console.WriteLine("Shares: " + ShareData);
                    string AverageVolumeData = cells.ElementAt(8).Text;
                    //Console.WriteLine("Avg Vol Data: " + AverageVolumeData);
                    string MarketCapData = cells.ElementAt(12).Text;
                    //Console.WriteLine("Market Cap: " + MarketCapData);
                    // Look for any movies.
                    if (context.Stock.Any())
                      {
                         return;   // DB has been seeded
                     }

                    context.Stock.AddRange(
                        new Stocks
                        {
                            Symbol = SymbolData,
                            LastPrice = LastPriceData,
                            Change = ChangeData,
                            ChangeRate = ChangeRateData,
                            Currency = CurrencyData,
                            MarketTime = MarketTimeData,
                            Volume = VolumeData,
                            ShareData = ShareData,
                            AverageVolume = AverageVolumeData,
                            MarketCapData = MarketCapData

                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
    
