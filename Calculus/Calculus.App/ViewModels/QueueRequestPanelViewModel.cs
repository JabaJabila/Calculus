using System.Collections.ObjectModel;
using Calculus.Core.Calculations.Operations.StandardOperations;
using Calculus.Core.Calculations.Parsing;
using Calculus.Core.Handling.Handlers;
using Calculus.Core.Handling.Models;
using Calculus.Core.Handling.Queues;

namespace Calculus.App.ViewModels;

public class QueueRequestPanelViewModel : ViewModelBase
{
    private readonly QueueRequests _queueRequests;
    
    public QueueRequestPanelViewModel()
    {
        _queueRequests = new QueueRequests(new CommonArithmeticParser());
        _queueRequests.StartHandling(new QueueResults());
        Items = new ObservableCollection<CalculationRequest>();
        Items.Add(new CalculationRequest("1151515.141 + 123123 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("1151515.141 + 123123 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("1151515.141 + 123123 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115253252352351515.141 + 12335235114414141412 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("1151515.141 + 123123 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("1151515.141 + 123123 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("116 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
        Items.Add(new CalculationRequest("115 + 12 =", new DivideOperation(1, 1)));
    }

    public ObservableCollection<CalculationRequest> Items
    {
        get;
    }
}