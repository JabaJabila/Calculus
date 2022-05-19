using System.Collections.Concurrent;
using Calculus.Core.Handling.Models;

namespace Calculus.Core.Handling.Queues;

public class QueueResults
{
    private readonly ConcurrentQueue<CalculationResult> _queue;
    private readonly object _locker = new object();

    public delegate void ElementEnqueueHandler(CalculationResult calculationResult);
    public event ElementEnqueueHandler? NotifyElementEnqueued;
    public delegate void ElementDequeueHandler(CalculationResult? calculationResult);
    public event ElementDequeueHandler? NotifyElementDequeued;

    public QueueResults()
    {
        _queue = new ConcurrentQueue<CalculationResult>();
    }

    public void Enqueue(CalculationResult result)
    {
        lock (_locker)
        {
            if (result is null) throw new ArgumentNullException(nameof(result));
            _queue.Enqueue(result);
            
            NotifyElementEnqueued?.Invoke(result);
        }
    }
    
    public bool TryDequeue(out CalculationResult? result)
    {
        lock (_locker)
        {
            if (!_queue.TryDequeue(out result)) return false;
            
            NotifyElementDequeued?.Invoke(result);
            return true;
        }
    }
}