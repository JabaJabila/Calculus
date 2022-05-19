using System.Collections.ObjectModel;
using System.Linq;
using Calculus.App.Models;
using Calculus.Core.Calculations.Operations.StandardOperations;
using Calculus.Core.Calculations.Parsing;
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
        Items = new ObservableCollection<QueueItem>();
        Items.Add(new QueueItem(new CalculationRequest("1 + 1 = ", new DivideOperation(1, 1))));
        Items.Add(new QueueItem(new CalculationRequest("2 + 2 = ", new DivideOperation(1, 1))));
        Items.Add(new QueueItem(new CalculationRequest("3 + 3 = ", new DivideOperation(1, 1))));

        Items.First().SetAwaiting();
    }

    public ObservableCollection<QueueItem> Items { get; }
}