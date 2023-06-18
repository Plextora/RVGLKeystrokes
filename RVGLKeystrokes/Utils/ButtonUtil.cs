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
        public static bool UseBorder = false;
        private readonly Brush _emptyBrush = HexToBrush("#00FFFFFF");

        public static Brush BackgroundBorderValue = HexToBrush(DefaultBackgroundBorderValue);
        public static Brush PressedValue = HexToBrush(DefaultPressedValue);
        public static Brush ForegroundValue = HexToBrush(DefaultForegroundValue);

        public static void ActivateButton(Button button) => button.Background = PressedValue;

        public static void DeactivateButton(Button button) =>
            button.Background = BackgroundBorderValue;

        public static Brush HexToBrush(string hex) => new BrushConverter().ConvertFrom(hex) as Brush;
    }
}