using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace Munters
{
    public class Program
    {
        /// <summary>
        /// This ENUM defined the UI Acstions such as Navigation, sending key to elements, clicking on elements ..etc
        /// </summary>
        public enum UIActions { Navigate, SendKeyToElement, ClickOnElement, SwitchFrame, GetValue, SetValue, UpdateValue , CloseBrowser };
        static SeleniumUnitAssignment MainObject = new SeleniumUnitAssignment();
        
        static void Main(string[] args)
        {
            //Navigate to https://www.trioair.net
            Actions(null, UIActions.Navigate, string.Format("Login to URL:{0}", Repository.HOME_PAGE_URL), 0, string.Empty, Repository.HOME_PAGE_URL);

            //Enter User Name
            Actions(MainObject.UserNameElement, UIActions.SendKeyToElement, string.Format("Enter User Name:{0}", Repository.USER_NAME), 0, Repository.USER_NAME);

            //Enter Password
            Actions(MainObject.PassElement, UIActions.SendKeyToElement, string.Format("Enter Password:{0}", Repository.PASSWORD), 0, Repository.PASSWORD);

            //Sign IN
            Actions(MainObject.SignInBtn, UIActions.ClickOnElement, "SignIN", 5,string.Empty, string.Empty, true);
            
            //Open Menue
            Actions(MainObject.IconMenu, UIActions.ClickOnElement, "Open Menu", 20);

            //Open Tree View
            Actions(MainObject.TreeView, UIActions.ClickOnElement, "Open Tree View", 5);

            //Click On Side Bar
            Actions(MainObject.SideBar, UIActions.ClickOnElement, "Click on Side Bar", 10);

            //Switch to the new frame
            Actions(null, UIActions.SwitchFrame, "Switch Frames", 0);

            //Open Contoller Menu
            Actions(MainObject.ControllerMenu, UIActions.ClickOnElement, "Click on Controller menu", 15);

            //Open Temerature Curve
            Actions(MainObject.TemperatureCurve, UIActions.ClickOnElement, "Click on Temperature Curve", 10);
            
            //Click on Edit Option 
            Actions(MainObject.EditMode, UIActions.ClickOnElement, "Click on Edit Mode", 10);

            //Update Days
            Actions(MainObject.DayElement, UIActions.UpdateValue, "Update Day values ", 0);
            
            //Update Target
            Actions(MainObject.TargetElement, UIActions.UpdateValue, "Update Target values", 0);

            //Update Low Temp Values.
            Actions(MainObject.LowTAlarm, UIActions.UpdateValue, "Update Low T Alarm values", 0);

            //Update High Tremp Alarm Value
            Actions(MainObject.HighTAlarm, UIActions.UpdateValue, "Update High T Alarm values", 0);

            //Save changes
            Actions(MainObject.SaveElement, UIActions.ClickOnElement, "Click Save button", 5);

            //Close browser
            Actions(null, UIActions.CloseBrowser, "Close Browser", 0);
        }

        public static void Actions(IWebElement element,
                                     UIActions action,
                                     string description,
                                     int waitSeconds,
                                     string keyForSending = "",
                                     string urlForLogin = "",
                                     bool isScrollDown = false)
        {
            MainObject.SleepThread(waitSeconds);
            Logger.WriteToDebug(description);
            switch (action)
            {
                case UIActions.ClickOnElement:
                    {                                            
                        MainObject.clickOnElement(element, isScrollDown);
                        break;
                    }
                case UIActions.SwitchFrame:
                    {  
                        MainObject.SwitchToFrame();
                        break;
                    }
                case UIActions.Navigate:
                    {                        
                        MainObject.NavigateTo(urlForLogin);
                        break;
                    }
                case UIActions.CloseBrowser:
                    {                        
                        MainObject.closeBrowser();
                        break;

                    }
                case UIActions.GetValue:
                    {
                        MainObject.GetValue(element);
                        break;
                    }
                case UIActions.UpdateValue:
                    {                        
                        MainObject.clickOnElement(element, isScrollDown);
                        MainObject.GetValue(MainObject.RangeInfo);
                        MainObject.SetValue(element);
                        break;
                    }
                case UIActions.SetValue:
                    {                        
                        MainObject.SetValue(element);
                        break;
                    }
                case UIActions.SendKeyToElement:
                    {                        
                        MainObject.SendKeyToElements(element, keyForSending);
                        break;
                    }
                default:
                    {
                        Logger.WriteToDebug(string.Format("Unknown action {0}!!", action));
                        break;
                    }

            }

        }


    }
}
