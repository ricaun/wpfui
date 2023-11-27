// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Windows;
using System.Windows.Media;

namespace Wpf.Ui.SimpleConsoleDemo;
public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        //Wpf.Ui.Appearance.Theme.Apply(
        //    Wpf.Ui.Appearance.ThemeType.Dark
        //);
        //Wpf.Ui.Appearance.Accent.Apply(Colors.LightBlue);

        Wpf.Ui.Appearance.Theme.Apply(this);
        Appearance.Theme.Changed += (s, e) =>
        {
            Wpf.Ui.Appearance.Theme.Apply(this);
        };

        this.KeyDown += (s, e) =>
        {
            if (e.Key == System.Windows.Input.Key.T)
            {
                var theme = Wpf.Ui.Appearance.Theme.GetAppTheme() == Appearance.ThemeType.Light ? Appearance.ThemeType.Dark : Appearance.ThemeType.Light;
                Wpf.Ui.Appearance.Theme.Apply(theme);
            }
        };
    }
}