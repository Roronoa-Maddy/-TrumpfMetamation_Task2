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



namespace Alarm2
{
    internal static class Program
    {
        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //[DllImport("user32.dll", SetLastError = true)]
        //static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start ms-clock:",
                WindowStyle = ProcessWindowStyle.Hidden
            });
            //Navigating To alarm Tab
            System.Threading.Thread.Sleep(5000);
            Keyboard.Type(VirtualKeyShort.DOWN);
            Keyboard.Type(VirtualKeyShort.RETURN);
            Thread.Sleep(1000);
            //Creating New Alarm
            Keyboard.Press(VirtualKeyShort.CONTROL);
            Keyboard.Type(VirtualKeyShort.KEY_N);
            Keyboard.Release(VirtualKeyShort.CONTROL);
            Thread.Sleep(1000);
            //Hours Changing
            Keyboard.Type(VirtualKeyShort.UP);
            Keyboard.Type(VirtualKeyShort.UP);
            Thread.Sleep(1000);
            //Giving Alarm Message
            Keyboard.Type(VirtualKeyShort.TAB);
            Keyboard.Type(VirtualKeyShort.TAB);
            Keyboard.Type(VirtualKeyShort.TAB);
            Keyboard.Type(VirtualKeyShort.BACK);
            SendKeys.SendWait("Welcome To Trumpf Metamation");
            Thread.Sleep(1000);
            Keyboard.Type(VirtualKeyShort.TAB);
            Keyboard.Type(VirtualKeyShort.SPACE);
            Keyboard.Type(VirtualKeyShort.TAB);
            Keyboard.Type(VirtualKeyShort.RETURN);
            for (int i = 0; i < 5; i++)
            {
                Keyboard.Type(VirtualKeyShort.RIGHT);
                Keyboard.Type(VirtualKeyShort.RETURN);

            }
            Thread.Sleep(1000);
            //Setting Up alarm Tone
            Keyboard.Type(VirtualKeyShort.TAB);
            //Keyboard.Type(VirtualKeyShort.RETURN);
            for (int j = 0; j < 4; j++)
            {
                Keyboard.Type(VirtualKeyShort.DOWN);

            }
            //Disabling Snooze
            Thread.Sleep(1000);
            Keyboard.Type(VirtualKeyShort.TAB);
            Thread.Sleep(1000);
            Keyboard.Type(VirtualKeyShort.UP);
            Keyboard.Type(VirtualKeyShort.UP);
            Keyboard.Type(VirtualKeyShort.TAB);
            Keyboard.Type(VirtualKeyShort.RETURN);
            Thread.Sleep(5000);
            //Deleting Newly Added Alarm
            Keyboard.Type(VirtualKeyShort.DELETE);
            //var automation = new UIA3Automation();
            //var app = FlaUI.Core.Application.Attach("Time");
            //var mainWindow = app.GetMainWindow(automation);

            //var alarmsList = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("AlarmsListId"))?.AsListBox();
            //var button = mainWindow.FindFirstDescendant(cf => cf.ByName("Add new alarm")).AsButton();

        }
    }
}

### Running the Project

1. Build and run the project in Visual Studio.
2. Observe the Clock Application for the status of each step.
