using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Calculus.Core.Handling.Models;
using JetBrains.Annotations;

namespace Calculus.App.Models;

public class QueueItem : INotifyPropertyChanged
{
    private const string DefaultColor = "GhostWhite";
    private const string AwaitingColor = "Goldenrod";
    private const string ErrorColor = "IndianRed";
    private const string SuccessColor = "LimeGreen";
    
    public QueueItem(CalculationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));
        Text = request.Expression;
        ColorState = DefaultColor;
        Awaiting = false;
    }
    
    public QueueItem(CalculationResult result)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));
        Awaiting = false;

        if (result.IsSuccessful)
        {
            Text = result.Expression + result.Result.ToString(CultureInfo.InvariantCulture);
            ColorState = SuccessColor;
            return;
        }

        Text = result.Expression + result.CaughtException!.Message;
        ColorState = ErrorColor;
    }

    public void SetAwaiting()
    {
        ColorState = AwaitingColor;
        Awaiting = true;
        OnPropertyChanged(nameof(ColorState));
    }

    public bool Awaiting { get; private set; }
    public string Text { get; private set; }
    public string ColorState { get; private set; }
    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}