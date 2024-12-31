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