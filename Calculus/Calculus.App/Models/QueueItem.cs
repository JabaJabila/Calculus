using System;
using Calculus.Core.Handling.Models;

namespace Calculus.App.Models;

public class QueueItem
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
    }
    
    public QueueItem(CalculationResult result)
    {
        ArgumentNullException.ThrowIfNull(result, nameof(result));

        if (result.IsSuccessful)
        {
            Text = result.Expression + result.Result;
            ColorState = SuccessColor;
            return;
        }

        Text = result.Expression + result.CaughtException!.Message;
        ColorState = ErrorColor;
    }

    public void SetAwaiting()
    {
        ColorState = AwaitingColor;
    }

    public string Text { get; private set; }
    public string ColorState { get; private set; }
}