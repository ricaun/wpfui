// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Linq;
using System.Windows;

namespace Wpf.Ui;

public class UiApplication
{
    private readonly Application _application;
    public bool IsApplication => _application is not null;
    public UiApplication(Application application)
    {
        if (application is not null)
        {
            var hasLibraryResources = application.Resources.MergedDictionaries
                .Where(e => e.Source is not null)
                .Any(e => e.Source.ToString().ToLower().Contains(Appearance.AppearanceData.LibraryNamespace));

            if (hasLibraryResources)
            {
                _application = application;
            }
        }

        System.Diagnostics.Debug.WriteLine(
                $"INFO | {typeof(UiApplication)} application is {_application}",
                "Wpf.Ui"
        );
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
