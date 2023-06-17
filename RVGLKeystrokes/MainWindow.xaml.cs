/*
 * Copyright 2023 Plextora
 * Licensed under the GPL-3.0 license (https://www.gnu.org/licenses/gpl-3.0.en.html#license-text)
 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Gma.System.MouseKeyHook;
using RVGLKeystrokes.Utils;
using Button = System.Windows.Controls.Button;

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
        }

        public void Subscribe()
        {
            _globalHook = Hook.GlobalEvents();

            _globalHook.KeyDown += OnKeyDown;
            _globalHook.KeyUp += OnKeyUp;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Button pressed = e.KeyCode switch
            {
                Keys.Up => AccelerateButton,
                Keys.Down => ReverseButton,
                Keys.Left => LeftButton,
                Keys.Right => RightButton,
                Keys.LControlKey => FireButton,
                Keys.End => FlipButton,
                Keys.Home => RepositionButton,
                Keys.Delete => RearViewButton,
                _ => null
            };

            if (pressed != null)
                ButtonUtil.ActivateButton(pressed);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            Button pressed = e.KeyCode switch
            {
                Keys.Up => AccelerateButton,
                Keys.Down => ReverseButton,
                Keys.Left => LeftButton,
                Keys.Right => RightButton,
                Keys.LControlKey => FireButton,
                Keys.End => FlipButton,
                Keys.Home => RepositionButton,
                Keys.Delete => RearViewButton,
                _ => null
            };

            if (pressed != null)
                ButtonUtil.DeactivateButton(pressed);
        }
    }
}