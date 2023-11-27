// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows;

namespace Wpf.Ui;

public class UiApplication
{
    private readonly Application _application;
    public bool IsApplication => _application is not null;
    public UiApplication(Application application)
    {
        _application = application;
    }

    private ResourceDictionary _resources;
    public ResourceDictionary Resources
    {
        get
        {
            if (_resources is null)
            {
                _resources = new ResourceDictionary();
                try
                {
                    var themesDictionary = new Wpf.Ui.Markup.ThemesDictionary();
                    var controlsDictionary = new Wpf.Ui.Markup.ControlsDictionary();
                    _resources.MergedDictionaries.Add(themesDictionary);
                    _resources.MergedDictionaries.Add(controlsDictionary);
                    Wpf.Ui.Appearance.Accent.ApplySystemAccent();
                }
                catch { }
            }
            return _application?.Resources ?? _resources;
        }
        set
        {
            if (_application is not null)
                _application.Resources = value;
            _resources = value;
        }
    }

    private Window _mainWindow;
    public Window MainWindow
    {
        get
        {
            return _application?.MainWindow ?? _mainWindow;
        }
        set
        {
            if (_application is not null)
                _application.MainWindow = value;
            _mainWindow = value;
        }
    }

    public void Shutdown()
    {
        _application?.Shutdown();
    }

    public static UiApplication Current => GetUiApplication();

    private static UiApplication _uiApplication;
    private static UiApplication GetUiApplication()
    {
        if (_uiApplication is null)
            _uiApplication = new UiApplication(Application.Current);
        return _uiApplication;
    }
}
