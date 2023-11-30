// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf.Ui.Demo.Simple.Models;

namespace Wpf.Ui.Demo.Simple.Views.Pages;

/// <summary>
/// Interaction logic for DataView.xaml
/// </summary>
public partial class DataPage
{
    public ObservableCollection<DataColor> ColorsCollection = new();

    public DataPage()
    {
        InitializeData();
        InitializeComponent();

        ColorsItemsControl.ItemsSource = ColorsCollection;
    }

    private void InitializeData()
    {
        var random = new Random();

        for (int i = 0; i < 8192; i++)
            ColorsCollection.Add(
                new DataColor
                {
                    Color = new SolidColorBrush(
                        Color.FromArgb(
                            (byte)200,
                            (byte)random.Next(0, 250),
                            (byte)random.Next(0, 250),
                            (byte)random.Next(0, 250)
                        )
                    )
                }
            );
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var button = sender as Button;
        Debug.WriteLine($"Click {button}");
        if (button.Background is SolidColorBrush solidColor)
        {
            Debug.WriteLine(solidColor.Color);
            Wpf.Ui.Appearance.ApplicationAccentColorManager.Apply(solidColor.Color);
        }
    }
}
