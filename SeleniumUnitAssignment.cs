using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading.Tasks;

namespace Munters
{
    class SeleniumUnitAssignment
    {
        String URL = Repository.HOME_PAGE_URL;

        private IWebDriver driver;
        private WebDriverWait wait;
        RangeVal rangeVal = new RangeVal();

        public struct RangeVal
        {
            public int MaxValInt { get; set; }
            public int MinValInt { get; set; }

            public double MaxValDouble { get; set; }
            public double MinValDouble { get; set; }

            public override string ToString() => $"({MaxValInt}, {MinValInt})";
        }

        public SeleniumUnitAssignment()
        {
            this.driver = StartBrowser();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20000));
            PageFactory.InitElements(driver, this);
        }

        public IWebDriver StartBrowser()
        {
            driver = new ChromeDriver(Repository.CHROME_PATH);
            driver.Manage().Window.Maximize();
            return driver;
        }
        // Navigate to any designated page
        
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
           
            WaitForPageToLoad();
            //SleepThread(20);
        }
        /// <summary>
        /// Switch to frame
        /// </summary>
        /// <param name="farmeName"></param>
        
        public void SwitchToFrame(int farmeIndex=0)
        {
            driver.SwitchTo().Frame(farmeIndex);
        }
        /// <summary>
        /// Get Value
        /// </summary>
        /// <param name="rangeValue"></param>
        /// <returns></returns>
       
        public RangeVal GetValue(IWebElement rangeValue)
        {
            if (rangeValue.Text.Contains("."))
            {
                rangeVal.MinValDouble = double.Parse(rangeValue.Text.Substring(0, rangeValue.Text.IndexOf("–")));
                rangeVal.MaxValDouble = double.Parse((rangeValue.Text.Substring(rangeValue.Text.IndexOf("–") + 1, rangeValue.Text.Length - rangeValue.Text.IndexOf("–") - 1)).Trim());

            }
            else
            {
                rangeVal.MinValInt = int.Parse(rangeValue.Text.Substring(0, rangeValue.Text.IndexOf("–")));
                rangeVal.MaxValInt = int.Parse((rangeValue.Text.Substring(rangeValue.Text.IndexOf("–") + 1, rangeValue.Text.Length - rangeValue.Text.IndexOf("–") - 1)).Trim());
            }
             return rangeVal;
        }
       
        public void SetValue(IWebElement Value)
        {
            try
            {
                Random rand = new Random();
                if (rangeVal.MaxValInt > 0)
                {
                    int intVal = rand.Next(rangeVal.MinValInt, rangeVal.MaxValInt);
                    Value.SendKeys(intVal.ToString());
                    rangeVal.MaxValInt = 0;
                }
                else
                {
                    double dblVal = rand.NextDouble() * rangeVal.MaxValDouble;
                    Value.SendKeys(dblVal.ToString());
                    rangeVal.MaxValDouble = 0;
                }
            }
            catch(Exception e)
            {
                Logger.Log(e.Message);
            }
        }
        
        public void SendKeyToElements(IWebElement destElement, string keyStr)
        {
            try
            {
                destElement.SendKeys(keyStr);
                destElement.Submit();
            }
            catch (Exception e)
            {
                Logger.WriteToDebug(e.Message, "Exception");
            }
        }
        
        public void clickOnElement(IWebElement element, bool isScrollDown = false)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // Scrolling down the page till the element is found		
            if (isScrollDown)
                js.ExecuteScript("arguments[0].scrollIntoView();", element);

            if (element.Displayed)
                element.Click();
        }
        
        public void closeBrowser()
        {
            driver.Close();
        }
        public void ActionProcessing(IWebElement element, bool isScrollDown = false)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // Scrolling down the page till the element is found		
            if (isScrollDown)
                js.ExecuteScript("arguments[0].scrollIntoView();", element);

            if (element.Displayed)
                element.Click();
        }

        public void WaitForPageToLoad(int timeoutSec = 15)
        {
            // Wait for the page to load
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
                wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "completed");
            }
            catch(WebDriverTimeoutException e)
            {
                Logger.WriteToDebug(e.Message);
            }
        }
        async void async_delay(int delay)
        {
            await Task.Delay(delay);
        }
        public void SleepThread(int sleep)
        {
            System.Threading.Thread.Sleep(sleep * 1000);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div[2]/div/div[2]/div/div[2]/form/div[3]/div[1]/input")]
        [CacheLookup]
        public  IWebElement UserNameElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='password']")]
        [CacheLookup]
        public  IWebElement PassElement;

        [FindsBy(How = How.XPath, Using = "//*[@id='next']")]
        [CacheLookup]
        public IWebElement SignInBtn;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-shell/div/div[1]/app-header/div/div/span")]
        [CacheLookup]
        public IWebElement IconMenu;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-shell/div/div[3]/ejs-sidebar/app-sites-tree-view/div/ejs-treeview")]
        [CacheLookup]
        public IWebElement TreeView;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-shell/div/div[3]/ejs-sidebar")]
        [CacheLookup]
        public IWebElement SideBar;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[1]/app-header/div/div/div[1]/button/div")]
        [CacheLookup]
        public IWebElement ControllerMenu;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/app-sidebar/div/p-sidebar/div/div/div[2]/div[1]/div")]
        [CacheLookup]
        public IWebElement TemperatureCurve;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[1]/app-telemetry-header/app-toolbar/div/div[2]/div/div/span")]
        [CacheLookup]
        public IWebElement EditMode;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[2]/app-telemetry-grid-page/div/div[1]/app-new-grid/div/div/div[1]/div/div/ejs-grid/div[5]/div/table/tbody/tr/td[2]/div/div/app-munters-numeric-textbox/div/kendo-numerictextbox/span/input")]
        [CacheLookup]
        public IWebElement DayElement;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[2]/app-telemetry-grid-page/div/div[2]/div/app-keypad-panel/app-keypad/div/div/div/span[2]")]
        [CacheLookup]
        public IWebElement RangeInfo;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[2]/app-telemetry-grid-page/div/div[1]/app-new-grid/div/div/div[1]/div/div/ejs-grid/div[5]/div/table/tbody/tr/td[3]/div/div/app-munters-numeric-textbox/div/kendo-numerictextbox/span/input")]
        [CacheLookup]
        public IWebElement TargetElement;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[2]/app-telemetry-grid-page/div/div[1]/app-new-grid/div/div/div[1]/div/div/ejs-grid/div[5]/div/table/tbody/tr/td[4]/div/div/app-munters-numeric-textbox/div/kendo-numerictextbox/span/input")]
        [CacheLookup]
        public IWebElement LowTAlarm;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[2]/app-telemetry-grid-page/div/div[1]/app-new-grid/div/div/div[1]/div/div/ejs-grid/div[5]/div/table/tbody/tr/td[5]/div/div/app-munters-numeric-textbox/div/kendo-numerictextbox/span")]
        [CacheLookup]
        public IWebElement HighTAlarm;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/app-host-mode-shell/div/div/div[2]/div/ng-component/form/div[1]/app-telemetry-header/app-toolbar/div/div[2]/div[2]/div")]
        [CacheLookup]
        public IWebElement SaveElement;
    }
}

