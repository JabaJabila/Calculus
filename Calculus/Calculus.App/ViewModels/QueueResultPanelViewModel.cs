using System;
using System.Collections.ObjectModel;
using Calculus.App.Models;
using Calculus.Core.Calculations.Operations.StandardOperations;
using Calculus.Core.Handling.Models;
using Calculus.Core.Handling.Queues;

namespace Calculus.App.ViewModels;

public class QueueResultPanelViewModel : ViewModelBase
{
    private readonly QueueResults _queueResults;
    
    public QueueResultPanelViewModel()
    {
        _queueResults = new QueueResults();
        Items = new ObservableCollection<QueueItem>();
        Items.Add(new QueueItem(new CalculationResult("228", 12312)));
        Items.Add(new QueueItem(new CalculationResult("228", new Exception("error"))));
    }

    public ObservableCollection<QueueItem> Items { get; }
    
}