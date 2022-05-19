using System.Collections.Concurrent;
using Calculus.Core.Handling.Models;

namespace Calculus.Core.Handling.Queues;

public class QueueResults
{
    private readonly ConcurrentQueue<CalculationResult> _queue;

    public QueueResults()
    {
        _queue = new ConcurrentQueue<CalculationResult>();
    }

    public bool IsEmpty => _queue.IsEmpty;

    public IReadOnlyCollection<CalculationResult> Results => _queue;

    public void Enqueue(CalculationResult result)
    {
        if (result is null) throw new ArgumentNullException(nameof(result));
        _queue.Enqueue(result);
    }
    
    public bool TryDequeue(out CalculationResult? result)
    {
        return _queue.TryDequeue(out result);
    }
}