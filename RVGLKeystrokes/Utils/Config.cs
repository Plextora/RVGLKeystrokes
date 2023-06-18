using System.IO;
using System.Windows.Controls;

namespace RVGLKeystrokes.Utils
{
    public class Config
    {
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
                "# 4rd line is to tell Evade Keystrokes if you want to highlight the background or border when a key is pressed\n" +
                "# For example, useborder:false would tell Evade Keystrokes to highlight the background\n" +
                "# useborder:true would tell Evade Keystrokes to highlight the border\n\n" +
                $"{ButtonUtil.DefaultBackgroundBorderValue}\n" +
                $"{ButtonUtil.DefaultPressedValue}\n" +
                $"{ButtonUtil.DefaultForegroundValue}\n" +
                "useborder:false";

            File.WriteAllText("config.txt", text);
        }

        public static void LoadConfig()
        {
            ButtonUtil.BackgroundBorderValue = ButtonUtil.HexToBrush(GetLine(8));
            ButtonUtil.PressedValue = ButtonUtil.HexToBrush(GetLine(9));
            ButtonUtil.ForegroundValue = ButtonUtil.HexToBrush(GetLine(10));
            ButtonUtil.UseBorder = GetLine(11) == "useborder:true";
        }

        public static string GetLine(int line)
        {
            using StreamReader sr = new StreamReader("config.txt");
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return sr.ReadLine();
        }
    }
}
