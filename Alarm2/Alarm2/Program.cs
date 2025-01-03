using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;
using System.Windows.Automation;
using OpenQA.Selenium.Winium;
using OpenQA.Selenium;
using FlaUI.Core.Tools;
using FlaUI.Core.AutomationElements;
using AutomationElement = FlaUI.Core.AutomationElements.AutomationElement;
using FlaUI.Core;
using Application = FlaUI.Core.Application;
using FlaUI.Core.Conditions;
using System.Windows;
using System.Threading;



namespace Alarm2
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {


            var clockApp = FlaUI.Core.Application.Launch("C:\\Program Files\\WindowsApps\\Microsoft.WindowsAlarms_11.2411.2.0_x64__8wekyb3d8bbwe\\Time");

            using (var automation = new UIA3Automation())
            {

                var rootElement = automation.GetDesktop();
                var condition = automation.ConditionFactory.ByControlType(FlaUI.Core.Definitions.ControlType.Window).And(automation.ConditionFactory.ByName("Clock"));
                var MainWindow = Retry.WhileNull(() => rootElement.FindFirst((FlaUI.Core.Definitions.TreeScope)TreeScope.Children, condition), timeout: TimeSpan.FromSeconds(10)).Result;
                Thread.Sleep(TimeSpan.FromSeconds(3));
                var alaramtab = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("AlarmButton")).AsListBox();
                alaramtab.DoubleClick();
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var addAlarmButton = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("AddAlarmButton")).AsButton();
                addAlarmButton.Click();
                //Hours and Minutes Setting
                var hoursPicker = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("HourPicker")).AsSpinner();
                hoursPicker.Value = 9;

                var minutesPicker = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("MinutePicker")).AsSpinner();
                minutesPicker.Value = 30;
                Thread.Sleep(TimeSpan.FromSeconds(1));
                var alarmname = MainWindow.FindFirstDescendant(cf => cf.ByName("Alarm name"));
                alarmname.AsTextBox().Enter("Trumpf Metamation Login Time");


            }

        }
    }
}