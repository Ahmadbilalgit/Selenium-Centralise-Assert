
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

public static class Entrypoint
{

    public static void  PageContainsText( IWebDriver driver, string textToFind) // This is the example of first  centralised assert method.
    {
        
        try
        {
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains(textToFind));
            Console.Write("\n"+textToFind +" is present");
        }
        catch (Exception)
        {
            Console.Write("\n"+textToFind + " is not present");
        }
    }

    public static void PageText(IWebDriver driver, string textToFind) // This is the example of second centralised assert method.
    {
       bool Resulttext = driver.FindElement(By.TagName("body")).Text.Contains(textToFind);

        if (Resulttext == true)
        {
            Console.Write(  "\n" +  textToFind  + " Found");
        }

        else
        {
            Console.Write( "\n"+ textToFind + " Not Found ");
        }

    }
    public static void Main()
    {
        IWebDriver driver = new ChromeDriver("./");
        driver.Navigate().GoToUrl("https://www.phptravels.net/login");
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);


        IWebElement Userid = driver.FindElement(By.Name("username"));
        Userid.SendKeys("user@phptravels.com");
        //Thread.Sleep(2000);



        IWebElement Cookie = driver.FindElement(By.CssSelector("#cookyGotItBtnBox > div > button"));
        Cookie.Click();
        // Thread.Sleep(2000);


        IWebElement Password = driver.FindElement(By.Name("password"));
        Password.SendKeys("demouser");
        // Thread.Sleep(2000);


        IWebElement Button = driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));
        Thread.Sleep(5000);
        Button.Click();
        Thread.Sleep(4000);

        
        PageContainsText(driver, "Hi, Demo User"); // First method call
        PageText (driver, "Rendevous Hotels"); // Second method call

        driver.Quit();
    }



}

//https://sqa.stackexchange.com/questions/122/selenium2-assert-questions/717
//https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert.areequal?view=mstest-net-1.2.0