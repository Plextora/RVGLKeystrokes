using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RVGLKeystrokes.Utils
{
    public class ButtonUtil
    {
        private static Brush _backgroundBorderValue;
        private static Brush _pressedValue;
        private static Brush _foregroundValue;
        private static string _buttonBorderValue;
        private static string _pressedButtonValue;
        private static string _buttonForeground;

        private const string DefaultPressedValue = "#FFBEE6FD";
        private const string DefaultBackgroundBorderValue = "#FFDDDDDD";
        private readonly string _defaultForegroundValue = "#FF000000";
        private readonly Brush _emptyBrush = HexToBrush("#00FFFFFF");

        public static IEnumerable<Button> FindAllButtons(DependencyObject depObj) => null; // for now

        public static void ActivateButton(Button button) => button.Background = HexToBrush(DefaultPressedValue);

        public static void DeactivateButton(Button button) =>
            button.Background = HexToBrush(DefaultBackgroundBorderValue);

        private static Brush HexToBrush(string hex) => new BrushConverter().ConvertFrom(hex) as Brush;
    }
}