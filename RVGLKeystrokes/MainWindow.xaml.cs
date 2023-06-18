/*
 * Copyright 2023 Plextora
 * Licensed under the GPL-3.0 license (https://www.gnu.org/licenses/gpl-3.0.en.html#license-text)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Gma.System.MouseKeyHook;
using RVGLKeystrokes.Utils;
using Button = System.Windows.Controls.Button;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace RVGLKeystrokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IKeyboardMouseEvents _globalHook;

        public MainWindow()
        {
            InitializeComponent();
            Subscribe();
            Config.InitConfig();
            foreach (Button button in FindAllButtons(WindowGrid))
            {
                button.Background = ButtonUtil.BackgroundBorderValue;
                button.Foreground = ButtonUtil.ForegroundValue;
            }
        }

        public void Subscribe()
        {
            _globalHook = Hook.GlobalEvents();

            _globalHook.KeyDown += OnKeyDown;
            _globalHook.KeyUp += OnKeyUp;
        }

        private static IEnumerable<Button> FindAllButtons(DependencyObject depObj)
        {
            if (depObj == null) yield return Enumerable.Empty<Button>() as Button;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild is Button button) yield return button;
                foreach (Button childOfChild in FindAllButtons(ithChild)) yield return childOfChild;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // I have absolutely NO idea how or why "var value when value" works, but it does.

            Button pressed = e.KeyCode switch
            {
                var value when value == Config.AccelerateKeyCode => AccelerateButton,
                var value when value == Config.ReverseKeyCode => ReverseButton,
                var value when value == Config.LeftKeyCode => LeftButton,
                var value when value == Config.RightKeyCode => RightButton,
                var value when value == Config.FireKeyCode => FireButton,
                var value when value == Config.FlipKeyCode => FlipButton,
                var value when value == Config.RepositionKeyCode => RepositionButton,
                var value when value == Config.RearKeyCode => RearViewButton,
                _ => null
            };

            if (pressed != null)
                ButtonUtil.ActivateButton(pressed);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            Button pressed = e.KeyCode switch
            {
                var value when value == Config.AccelerateKeyCode => AccelerateButton,
                var value when value == Config.ReverseKeyCode => ReverseButton,
                var value when value == Config.LeftKeyCode => LeftButton,
                var value when value == Config.RightKeyCode => RightButton,
                var value when value == Config.FireKeyCode => FireButton,
                var value when value == Config.FlipKeyCode => FlipButton,
                var value when value == Config.RepositionKeyCode => RepositionButton,
                var value when value == Config.RearKeyCode => RearViewButton,
                _ => null
            };

            if (pressed != null)
                ButtonUtil.DeactivateButton(pressed);
        }

        private void WindowMove(object sender, MouseButtonEventArgs e) => DragMove();
    }
}