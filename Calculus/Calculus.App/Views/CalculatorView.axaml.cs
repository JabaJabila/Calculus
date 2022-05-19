using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Calculus.App.Views;

public partial class CalculatorView : UserControl
{
    public CalculatorView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}