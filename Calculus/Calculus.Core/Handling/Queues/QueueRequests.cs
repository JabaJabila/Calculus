using System.Collections.Concurrent;
using Calculus.Core.Calculations.Parsing;
using Calculus.Core.Handling.Handlers;
using Calculus.Core.Handling.Models;

namespace Calculus.Core.Handling.Queues;

public class QueueRequests
{
    private readonly ConcurrentQueue<CalculationRequest?> _queue;
    private readonly IArithmeticParser _parser;
    private readonly object _locker = new object();

    public delegate void ElementEnqueueHandler(CalculationRequest calculationRequest);
    public event ElementEnqueueHandler? NotifyElementEnqueued;
    public delegate void ElementDequeueHandler(CalculationRequest? calculationRequest);
    public event ElementDequeueHandler? NotifyElementDequeued;

    public bool IsEmpty => _queue.IsEmpty;

    public QueueRequests(IArithmeticParser parser)
    {
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        _queue = new ConcurrentQueue<CalculationRequest?>();
    }

    public void StartHandling(QueueResults queueResults)
    {
        ArgumentNullException.ThrowIfNull(queueResults, nameof(queueResults));
        var handler = new BackgroundQueuesHandler(this, queueResults);
        var backgroundHandler = new Thread(handler.HandleRequests)
        {
            IsBackground = true
        };
        
        backgroundHandler.Start();   
    }

    public void Enqueue(string expression)
    {
        lock (_locker)
        {
            if (expression is null) throw new ArgumentNullException(nameof(expression));
            
            var item = new CalculationRequest(expression, _parser.ParseFromString(expression));
            _queue.Enqueue(item);
            NotifyElementEnqueued?.Invoke(item);
        }
    }

    public bool TryDequeue(out CalculationRequest? request)
    {
        lock (_locker)
        {
            if (!_queue.TryDequeue(out request)) return false;
            
            NotifyElementDequeued?.Invoke(request);
            return true;
        }
    }
}