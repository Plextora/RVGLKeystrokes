using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RVGLKeystrokes.Utils
{
    public class ButtonUtil
    {
        public const string DefaultPressedValue = "#FFBEE6FD";
        public const string DefaultBackgroundBorderValue = "#FFDDDDDD";
        public static readonly string DefaultForegroundValue = "#FF000000";
        public static double DefaultBorderThickness = 2;
        public static bool UseBorder = false;
        private static readonly Brush EmptyBrush = HexToBrush("#00FFFFFF");

        public static Brush BackgroundBorderValue = HexToBrush(DefaultBackgroundBorderValue);
        public static Brush PressedValue = HexToBrush(DefaultPressedValue);
        public static Brush ForegroundValue = HexToBrush(DefaultForegroundValue);
        public static Thickness BorderThickness = new Thickness(DefaultBorderThickness);

        public static void ActivateButton(Button button)
        {
            if (UseBorder)
            {
                button.BorderBrush = PressedValue;
                button.BorderThickness = BorderThickness;
            }
            else
                button.Background = PressedValue;
        }

        public static void DeactivateButton(Button button)
        {
            if (UseBorder)
                button.BorderBrush = EmptyBrush;
            else
                button.Background = BackgroundBorderValue;
        }

        public static Brush HexToBrush(string hex) => new BrushConverter().ConvertFrom(hex) as Brush;
    }
}