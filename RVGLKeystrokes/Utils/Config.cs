using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace RVGLKeystrokes.Utils
{
    public class Config
    {
        public static Keys AccelerateKeyCode = Keys.Up;
        public static Keys ReverseKeyCode = Keys.Down;
        public static Keys LeftKeyCode = Keys.Left;
        public static Keys RightKeyCode = Keys.Right;
        public static Keys FireKeyCode = Keys.LControlKey;
        public static Keys FlipKeyCode = Keys.End;
        public static Keys RepositionKeyCode = Keys.Home;
        public static Keys RearKeyCode = Keys.Delete;

        public static void InitConfig()
        {
            if (!File.Exists("config.txt"))
                CreateConfig();
            else
                LoadConfig();
        }

        public static void CreateConfig()
        {
            File.Create("config.txt").Close();

            string text =
                "# 1st line is for button background\n" +
                "# 2nd line is for button background/border when pressed\n" +
                "# 3rd line is for button foreground\n" +
                "# 4rd line is to tell RVGL Keystrokes if you want to highlight the background or border when a key is pressed\n" +
                "# For example, useborder:false would tell RVGLKeystrokes to highlight the background\n" +
                "# useborder:true would tell RVGL Keystrokes to highlight the border\n" +
                "# 5th line is for how thick the border is (if useborder is enabled)\n" +
                "# Starting at line 6, the remaining lines have the name of the keystroke on the left of the colon, and\n" +
                "# the keycode the keystroke is binded to on the right.\n" +
                "# For example, the line \"acceleratekey:38\" tells RVGL Keystrokes that the accelerate keystroke\n" +
                "# (the keystroke with the up arrow) will trigger when a key with the keycode of \"38\" is pressed.\n" +
                "# You can view the keycode of every key supported by Windows at this URL: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=netframework-4.8#fields\n" +
                $"{ButtonUtil.DefaultBackgroundBorderValue}\n" +
                $"{ButtonUtil.DefaultPressedValue}\n" +
                $"{ButtonUtil.DefaultForegroundValue}\n" +
                "useborder:false\n" +
                "borderthickness:2\n" +
                "acceleratekey:38\n" +
                "reversekey:40\n" +
                "leftkey:37\n" +
                "rightkey:39\n" +
                "firekey:162\n" +
                "flipkey:35\n" +
                "repositionkey:36\n" +
                "rearkey:46";

            File.WriteAllText("config.txt", text);
        }

        public static void LoadConfig()
        {
            ButtonUtil.BackgroundBorderValue = ButtonUtil.HexToBrush(GetLine(13));
            ButtonUtil.PressedValue = ButtonUtil.HexToBrush(GetLine(14));
            ButtonUtil.ForegroundValue = ButtonUtil.HexToBrush(GetLine(15));
            ButtonUtil.UseBorder = GetLine(16) == "useborder:true";
            ButtonUtil.BorderThickness = new Thickness(Convert.ToDouble(Regex.Match(GetLine(17), @"\d+").Value));
            AccelerateKeyCode = GetKeyCode(GetLine(18));
            ReverseKeyCode = GetKeyCode(GetLine(19));
            LeftKeyCode = GetKeyCode(GetLine(20));
            RightKeyCode = GetKeyCode(GetLine(21));
            FireKeyCode = GetKeyCode(GetLine(22));
            FlipKeyCode = GetKeyCode(GetLine(23));
            RepositionKeyCode = GetKeyCode(GetLine(24));
            RearKeyCode = GetKeyCode(GetLine(25));
        }

        public static string GetLine(int line)
        {
            using StreamReader sr = new StreamReader("config.txt");
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return sr.ReadLine();
        }

        private static Keys GetKeyCode(string keyCode) => (Keys)int.Parse(Regex.Match(keyCode, @"\d+").Value);
    }
}
