using System.Collections.ObjectModel;
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
        Items = new ObservableCollection<CalculationResult>();
        Items.Add(new CalculationResult("12314124124", 12312));
        Items.Add(new CalculationResult("228", 12312));
        Items.Add(new CalculationResult("ошибка нахуй", 12312));
    }

    public ObservableCollection<CalculationResult> Items
    {
        get;
    }
    
}