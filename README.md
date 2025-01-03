**Project Overview**
#  Automated Clock App Alarm Management(C# Implementation)

This project automates a setting up new Alram in the clock and Deleting The newly Added alarm and verifying the newly added alarm got deleted.

## Steps Automated

1.Open the Clock app
2.Navigate to Alarm
3.Create a New Alarm with details as in Screenshot  (Refer Task 2 - Screenshot)
4.nable the Alarm
5.Verify the Alarm is saved with expected details
6.Delete the Alarm
7.Validate the Alarm has been removed

### Tools and Frameworks

1. Visual Studio (2022).
2. .NET Framework or .NET Core/8.0.


### Libraries
- FlaUI.Core.WindowsAPI
- System.Diagnostics
- FlaUI.Core.Input;


### Setting up the Project

1. Open Visual Studio.
2. Create a new Windows Forms App project.
3. Name the project `Alarm`.
4. Add the following code to your `Program.cs` file.



﻿using FlaUI.Core.Input;
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
                var repeatalarm = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("RepeatCheckBox")).AsCheckBox();
                repeatalarm.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                
                var monday = MainWindow.FindFirstDescendant(cf => cf.ByName("Monday")).AsToggleButton();
                monday.Click();
                var Tuesday = MainWindow.FindFirstDescendant(cf => cf.ByName("Tuesday")).AsToggleButton();
                Tuesday.Click();
                var Wednesday = MainWindow.FindFirstDescendant(cf => cf.ByName("Wednesday")).AsToggleButton();
                Wednesday.Click();
                var Thursday = MainWindow.FindFirstDescendant(cf => cf.ByName("Thursday")).AsToggleButton();
                Thursday.Click();
                var Friday = MainWindow.FindFirstDescendant(cf => cf.ByName("Friday")).AsToggleButton();
                Friday.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                var alarmsoundoption = MainWindow.FindFirstDescendant(cf =>cf.ByAutomationId("ChimeComboBox")).AsComboBox();
                alarmsoundoption.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                var Jingle = MainWindow.FindFirstDescendant(cf => cf.ByName("Jingle")).AsListBoxItem();
                Jingle.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                var snooze = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("SnoozeComboBox")).AsComboBox();
                snooze.Click();
                var SnoozeDisable = MainWindow.FindFirstDescendant(cf => cf.ByName("Disabled")).AsListBoxItem();
                SnoozeDisable.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                var savebutton = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("PrimaryButton")).AsButton();
                savebutton.Click();
                Thread.Sleep(3000);
                var editalarm = MainWindow.FindFirstDescendant(cf => cf.ByName("Edit alarms")).AsButton();
                editalarm.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(250));

                var alarmname1 = MainWindow.FindFirstDescendant(cf => cf.ByName("Trumpf Metamation Login Time")).Name;
                if (alarmname1 == "Trumpf Metamation Login Time")
                {
                    var alarmdelete = MainWindow.FindFirstDescendant(cf => cf.ByName("Edit alarm, Trumpf Metamation Login Time, 9:30AM, Weekdays, ")).AsToggleButton();
                    alarmdelete.Click();
                    var alarmdeletebutton = MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("DeleteButton")).AsButton();
                    alarmdeletebutton.Click();
                }





                var alarmElements = MainWindow.FindAllDescendants(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.ListItem));


                var alarmElement = MainWindow.FindFirstDescendant(cf => cf.ByName("Trumpf Metamation Login Time"));

                if (alarmElement == null)
                {
                    Console.WriteLine("The alarm was successfully deleted.");
                }

                var DoneButton = MainWindow.FindFirstDescendant(cf => cf.ByName("Done")).AsButton();
                DoneButton.Click();
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                var closeclock = MainWindow.FindFirstDescendant(cf => cf.ByName("Close Clock")).AsButton();
                closeclock.Click();

            }

        }
    }
}

### Running the Project

1. Build and run the project in Visual Studio.
2. Observe the Clock Application for the status of each step.
