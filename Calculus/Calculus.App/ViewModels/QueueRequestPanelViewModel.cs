using System;
using System.Collections.ObjectModel;
using System.Linq;
using Calculus.App.Models;
using Calculus.Core.Handling.Models;
using Calculus.Core.Handling.Queues;
using ReactiveUI;

namespace Calculus.App.ViewModels;

public class QueueRequestPanelViewModel : ViewModelBase
{
    private string _heading = null!;
    
    public QueueRequestPanelViewModel(QueueRequests queueRequests, QueueResults queueResults)
    {
        ArgumentNullException.ThrowIfNull(queueResults, nameof(queueResults));
        ArgumentNullException.ThrowIfNull(queueRequests, nameof(queueRequests));
        
        queueRequests.StartHandling(queueResults);
        Items = new ObservableCollection<QueueItem>();
        queueRequests.NotifyElementEnqueued += AddQueueItem;
        queueRequests.NotifyElementDequeued += MakeItemAwaitCalculation;
        queueResults.NotifyElementEnqueued += DequeueCalculatedItem;
        UpdateHeading();
    }

    public ObservableCollection<QueueItem> Items { get; }

    public string Heading
    {
        get => _heading;
        set
        {
            this.RaiseAndSetIfChanged(ref _heading, value);
        }
    }

    private void AddQueueItem(CalculationRequest request)
    {
        Items.Add(new QueueItem(request));
        UpdateHeading();
    }

    private void MakeItemAwaitCalculation(CalculationRequest? request)
    {
        var item = Items.FirstOrDefault(i => !i.Awaiting);
        if (item is null || request is null || request.Expression != item.Text)
            return;
        
        item.SetAwaiting();
    }

    private void DequeueCalculatedItem(CalculationResult result)
    {
        var item = Items.FirstOrDefault(i => i.Awaiting && result.Expression == i.Text);
        if (item is null)
            return;
        
        Items.Remove(item);
        UpdateHeading();
    }

    private void UpdateHeading()
    {
        Heading = $"Requests in queue: {Items.Count}";
    }
}