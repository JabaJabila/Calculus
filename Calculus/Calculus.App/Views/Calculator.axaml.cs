﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Calculus.App.ViewModels;

namespace Calculus.App.Views;

public partial class Calculator : UserControl
{
    public Calculator()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}