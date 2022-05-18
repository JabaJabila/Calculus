using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Calculus.App.Views;

public partial class HintQuestionTip : UserControl
{
    public HintQuestionTip()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}