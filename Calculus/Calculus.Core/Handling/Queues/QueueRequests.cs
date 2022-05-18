using System.Collections.Concurrent;
using Calculus.Core.Calculations.Parsing;
using Calculus.Core.Handling.Handlers;
using Calculus.Core.Handling.Models;

namespace Calculus.Core.Handling.Queues;

public class QueueRequests
{
    private readonly ConcurrentQueue<CalculationRequest?> _queue;
    private readonly IArithmeticParser _parser;

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

    public bool IsEmpty => _queue.IsEmpty;
    public IReadOnlyCollection<CalculationRequest?> Requests => _queue;

    public void Enqueue(string expression)
    {
        if (expression is null) throw new ArgumentNullException(nameof(expression));
        _queue.Enqueue(new CalculationRequest(expression, _parser.ParseFromString(expression)));
    }

    public bool TryDequeue(out CalculationRequest? request)
    {
        return _queue.TryDequeue(out request);
    }
}