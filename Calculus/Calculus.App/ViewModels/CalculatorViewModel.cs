using System;
using System.Text;
using Calculus.Core.Handling.Queues;
using Calculus.Core.Tools;
using MessageBox.Avalonia.Enums;
using ReactiveUI;

namespace Calculus.App.ViewModels;

public class CalculatorViewModel : ViewModelBase
{
    private const string DefaultExpression = "0";
    private readonly QueueRequests _queueRequests;
    private string _expression;
    private string _leftPart;
    private string _rightPart;
    private bool _rightMinus;
    private bool _leftMinus;
    private char _operation;

    public CalculatorViewModel(QueueRequests queueRequests)
    {
        _queueRequests = queueRequests ?? throw new ArgumentNullException(nameof(queueRequests));
        _expression = DefaultExpression;
        _leftPart = DefaultExpression;
        _rightPart = string.Empty;
        _leftMinus = _rightMinus = false;
        _operation = ' ';
    }

    public string Expression
    {
        get => _expression;
        set => this.RaiseAndSetIfChanged(ref _expression, value);
    }

    public void NumInput(char num)
    {
        if (_operation != ' ')
        {
            _rightPart += num;
            BuildExpression();
            return;
        }

        if (_leftPart == DefaultExpression)
            _leftPart = string.Empty;

        _leftPart += num;
        BuildExpression();
    }
    
    public void OperationInput(char operaiton)
    {
        if (_operation == ' ') _operation = operaiton;
        BuildExpression();
    }
    
    public void ChangeMinusPlus()
    {
        if (_operation != ' ')
        {
            _rightMinus = !_rightMinus;
            BuildExpression();
            return;
        }

        _leftMinus = !_leftMinus;
        BuildExpression();
    }

    public void DotInput()
    {
        if (_operation != ' ')
        {
            if (_rightPart.Contains('.')) return;
            _rightPart += string.IsNullOrWhiteSpace(_rightPart) ? "0." : ".";
            BuildExpression();
            return;
        }

        if (_leftPart.Contains('.')) return;
        _leftPart += string.IsNullOrWhiteSpace(_leftPart) ? "0." : ".";
        BuildExpression();
    }

    public void DeleteOneSymbol()
    {
        if (_operation == ' ')
        {
            _leftPart = _leftPart.Length > 1 ? _leftPart[..^1] : DefaultExpression;
            BuildExpression();
            return;
        }

        if (_rightPart.Length > 0)
        {
            _rightPart = _rightPart[..^1];
            BuildExpression();
            return;
        }

        _operation = ' ';
        BuildExpression();
    }

    public void ClearAll()
    {
        Expression = DefaultExpression;
        _leftPart = DefaultExpression;
        _rightPart = string.Empty;
        _leftMinus = _rightMinus = false;
        _operation = ' ';
    }

    public void Execute()
    {
        var requested = Expression.Contains('=') ? Expression : $"{Expression} = ";

        try
        {
            _queueRequests.Enqueue(requested);

            ClearAll();
        }
        catch (ExpressionSyntaxException e)
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", $"Syntax error: {e.Message}", ButtonEnum.Ok, Icon.Error);
            messageBoxStandardWindow.Show();
        }
        catch (Exception)
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Unknown error!", ButtonEnum.Ok, Icon.Error);
            messageBoxStandardWindow.Show();
        }
    }

    private void BuildExpression()
    {
        var left = _leftMinus ? $"-({_leftPart})" : _leftPart;
        var right = _rightMinus ? $"-({_rightPart})" : _rightPart;

        var result = new StringBuilder();
        if (string.IsNullOrWhiteSpace(_leftPart)) return;
        result.Append(left);

        if (_operation == ' ')
        {
            Expression = result.ToString();
            return;
        }
        result.Append($" {_operation}");

        if (string.IsNullOrWhiteSpace(_rightPart))
        {
            Expression = result.ToString();
            return;
        }
        result.Append($" {right}");

        Expression = result.ToString();
    }
}