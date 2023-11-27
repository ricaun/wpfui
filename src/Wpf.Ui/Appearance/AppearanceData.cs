// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;

namespace Wpf.Ui.Appearance;

/// <summary>
/// Static container for appearance data.
/// </summary>
internal static class AppearanceData
{
    /// <summary>
    /// Collection of handles that have a background effect applied.
    /// </summary>
    public static List<IntPtr> ModifiedBackgroundHandles = new();

    /// <summary>
    /// Namespace for the XAML dictionaries.
    /// </summary>
    public static string LibraryNamespace { get; } = $"{typeof(AppearanceData).Assembly.GetName().Name.ToLower()};";

    /// <summary>
    /// Main dictionary for WPF UI controls.
    /// </summary>
    public const string LibraryMainDictionary = "Wpf.Ui";

    /// <summary>
    /// Default <see cref="System.Uri"/> for the application theme dictionaries.
    /// </summary>
    public static string LibraryThemeDictionariesUri { get; } = $"{LibraryComponentName}Styles/Theme/";

    /// <summary>
    /// Default <see cref="System.Uri"/> for the application theme dictionaries.
    /// </summary>
    public static string LibraryDictionariesUri { get; } = $"{LibraryComponentName}Styles/";

    /// <summary>
    /// Default component Name (pack://application:,,,/{AssemblyName};component/)
    /// </summary>
    public static string LibraryComponentName => GetLibraryComponentName();

    private static string GetLibraryComponentName()
    {
        var component = $"pack://application:,,,/{typeof(AppearanceData).Assembly.GetName().Name};component/";
        //Console.WriteLine(component);
        //Console.WriteLine(LibraryThemeDictionariesUri);
        //Console.WriteLine(LibraryDictionariesUri);
        //Console.WriteLine(LibraryNamespace);
        return component;
    }

    /// <summary>
    /// Current system theme.
    /// </summary>
    public static SystemThemeType SystemTheme = SystemThemeType.Unknown;

    /// <summary>
    /// Current application theme.
    /// </summary>
    public static ThemeType ApplicationTheme = ThemeType.Unknown;

    /// <summary>
    /// Adds given window to list of modified handles.
    /// </summary>
    public static void AddHandle(Window window)
    {
        if (window is null)
            return;
        AddHandle(new WindowInteropHelper(window).Handle);
    }

    /// <summary>
    /// Adds given handle to list of modified handles.
    /// </summary>
    public static void AddHandle(IntPtr hWnd)
    {
        if (!ModifiedBackgroundHandles.Contains(hWnd))
            ModifiedBackgroundHandles.Add(hWnd);
    }

    /// <summary>
    /// Removes given window from list of modified handles.
    /// </summary>
    public static void RemoveHandle(Window window)
    {
        if (window is null)
            return;
        RemoveHandle(new WindowInteropHelper(window).Handle);
    }

    /// <summary>
    /// Removes given handle from list of modified handles.
    /// </summary>
    public static void RemoveHandle(IntPtr hWnd)
    {
        if (!ModifiedBackgroundHandles.Contains(hWnd))
            ModifiedBackgroundHandles.Remove(hWnd);
    }

    /// <summary>
    /// Returns a value indicating whether the given window had a modified background.
    /// </summary>
    public static bool HasHandle(Window window)
    {
        if (window is null)
            return false;
        return HasHandle(new WindowInteropHelper(window).Handle);
    }

    /// <summary>
    /// Returns a value indicating whether the given handle had a modified background.
    /// </summary>
    public static bool HasHandle(IntPtr hWnd)
    {
        return ModifiedBackgroundHandles.Contains(hWnd);
    }
}
