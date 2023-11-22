// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Windows;

namespace Wpf.Ui.SimpleConsoleDemo;
public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();

        Wpf.Ui.Appearance.Accent.ApplySystemAccent();
        Wpf.Ui.Appearance.Theme.Apply(this);
    }
}