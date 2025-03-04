﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Contracts;

namespace Wpf.Ui.Gallery.ViewModels.Pages.DialogsAndFlyouts;

public partial class DialogViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;
    public DialogViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    [RelayCommand]
    private void OnShowDialog(object sender)
    {
        var rootDialog = _dialogService.GetDialogControl();

        rootDialog.DialogHeight = 240;
        rootDialog.Title = "This is global Dialog control managed by IDialogService";
        rootDialog.Content = new TextBlock
        {
            Margin = new Thickness(0, 8, 0, 0),
            TextWrapping = TextWrapping.WrapWithOverflow,
            Text = "This dialog is placed under the TitleBar but above the NavigationView. This allows us to enable the window to be navigated, but cover the application's navigation. You can add Dialog anywhere you want and arrange it as you like."
        };
        rootDialog.ButtonLeftClick += (_, _) => rootDialog.Hide();
        rootDialog.ButtonRightClick += (_, _) => rootDialog.Hide();
        rootDialog.Show();
    }
}
