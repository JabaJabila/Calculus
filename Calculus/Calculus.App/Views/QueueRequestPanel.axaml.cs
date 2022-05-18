using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Calculus.App.Views;

public partial class QueueRequestPanel : UserControl
{
    public QueueRequestPanel()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}