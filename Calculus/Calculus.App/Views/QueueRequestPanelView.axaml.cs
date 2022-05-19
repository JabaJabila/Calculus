using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Calculus.App.Views;

public partial class QueueRequestPanelView : UserControl
{
    public QueueRequestPanelView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}