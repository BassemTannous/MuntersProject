using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munters
{
    class NUnitTest
    {
        public SeleniumUnitAssignment MainObject = new SeleniumUnitAssignment();

        [SetUp]
        public void Start_NavigateToURL()
        {
            MainObject.SleepThread(0);
            Logger.WriteToDebug(string.Format("Login to URL:{0}", Repository.HOME_PAGE_URL));
            MainObject.NavigateTo(Repository.HOME_PAGE_URL);
        }
        [Test]
        public void Test_EnterUserPass()
        {
            MainObject.SleepThread(0);
            Logger.WriteToDebug(string.Format("Enter User Name:{0}", Repository.USER_NAME));
            MainObject.UserNameElement.SendKeys(Repository.USER_NAME);
            MainObject.UserNameElement.Submit();

            Logger.WriteToDebug(string.Format("Enter Password:{0}", Repository.PASSWORD));
            MainObject.PassElement.SendKeys(Repository.PASSWORD);
            MainObject.PassElement.Submit();
        }
        [Test]
        public void Test_SignIn()
        {
            MainObject.SleepThread(1);
            Logger.WriteToDebug("SignIN");
            MainObject.clickOnElement(MainObject.SignInBtn, true);
        }
        [Test]
        public void Test_OpenMenu()
        {
            MainObject.SleepThread(20);
            Logger.WriteToDebug("Open Menu");
            MainObject.clickOnElement(MainObject.IconMenu);
        }
        [Test]
        public void Test_OpenTreeView()
        {
            MainObject.SleepThread(5);
            Logger.WriteToDebug("Open Tree View");
            MainObject.clickOnElement(MainObject.TreeView);
        }
        [Test]
        public void Test_OpenSideBar()
        {
            MainObject.SleepThread(5);
            Logger.WriteToDebug("Click on Side Bar");
            MainObject.clickOnElement(MainObject.SideBar);
        }
        [Test]
        public void Test_SwitchFrame()
        {
            MainObject.SleepThread(0);
            Logger.WriteToDebug("Switch Frames");
            MainObject.SwitchToFrame();
        }
        [Test]
        public void Test_OpenControllerMenu()
        {
            MainObject.SleepThread(15);
            Logger.WriteToDebug("Click On Controller Menu");
            MainObject.clickOnElement(MainObject.ControllerMenu);
        }
        [Test]
        public void Test_OpenTemperatureCurve()
        {
            MainObject.SleepThread(10);
            Logger.WriteToDebug("Click on Temperature Curve");
            MainObject.clickOnElement(MainObject.TemperatureCurve);
        }
        [Test]
        public void Test_OpenEditMode()
        {
            MainObject.SleepThread(5);
            Logger.WriteToDebug("Click On Edit Mode");
            MainObject.clickOnElement(MainObject.EditMode);
        }

        [Test]
        public void Test_UpdateDayElement()
        {
            Logger.WriteToDebug("Update Day Value");
            MainObject.clickOnElement(MainObject.DayElement, false);
            MainObject.GetValue(MainObject.RangeInfo);
            MainObject.SetValue(MainObject.DayElement);
        }
        [Test]
        public void Test_UpdateTargetElement()
        {
            Logger.WriteToDebug("Update Target Value");
            MainObject.clickOnElement(MainObject.TargetElement, false);
            MainObject.GetValue(MainObject.RangeInfo);
            MainObject.SetValue(MainObject.TargetElement);
        }
        [Test]
        public void Test_UpdateLowTempAlarm()
        {
            Logger.WriteToDebug("Update Low Temp Alarm Value");
            MainObject.clickOnElement(MainObject.LowTAlarm, false);
            MainObject.GetValue(MainObject.RangeInfo);
            MainObject.SetValue(MainObject.LowTAlarm);
        }
        public void Test_UpdateHighTempAlarm()
        {
            Logger.WriteToDebug("Update High Temp Alarm Value");
            MainObject.clickOnElement(MainObject.HighTAlarm, false);
            MainObject.GetValue(MainObject.RangeInfo);
            MainObject.SetValue(MainObject.HighTAlarm);
        }
        [Test]
        public void Test_SaveChanges()
        {
            MainObject.SleepThread(5);
            Logger.WriteToDebug("Save Changes");
            MainObject.clickOnElement(MainObject.SaveElement);
        }
        [TearDown]
        public void CloseBrowser()
        {
            Logger.WriteToDebug("Close Browser");
            MainObject.closeBrowser();
        }
    }
}
