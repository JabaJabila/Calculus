using System;
using System.Collections.ObjectModel;
using Calculus.App.Models;
using Calculus.Core.Handling.Models;
using Calculus.Core.Handling.Queues;
using ReactiveUI;

namespace Calculus.App.ViewModels;

public class QueueResultPanelViewModel : ViewModelBase
{
    private string _heading = null!;
    
    public QueueResultPanelViewModel(QueueResults queueResults)
    {
        ArgumentNullException.ThrowIfNull(queueResults, nameof(queueResults));
        
        Items = new ObservableCollection<QueueItem>();
        queueResults.NotifyElementEnqueued += AddQueueItem;
        UpdateHeading();
    }

    public ObservableCollection<QueueItem> Items { get; }
    
    public string Heading
    {
        get => _heading;
        set => this.RaiseAndSetIfChanged(ref _heading, value);
    }

    private void AddQueueItem(CalculationResult calculationResult)
    {
        Items.Insert(0, new QueueItem(calculationResult));
        UpdateHeading();
    }
    
    private void UpdateHeading()
    {
        Heading = $"Results in queue: {Items.Count}";
    }
}