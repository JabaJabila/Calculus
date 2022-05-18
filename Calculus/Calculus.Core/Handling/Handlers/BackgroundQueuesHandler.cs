using Calculus.Core.Handling.Models;
using Calculus.Core.Handling.Queues;

namespace Calculus.Core.Handling.Handlers;

public class BackgroundQueuesHandler : ICalculationQueueHandler
{
    private readonly QueueRequests _queueRequests;
    private readonly QueueResults _queueResults;

    public BackgroundQueuesHandler(QueueRequests queueRequests, QueueResults queueResults)
    {
        _queueRequests = queueRequests ?? throw new ArgumentNullException(nameof(queueRequests));
        _queueResults = queueResults ?? throw new ArgumentNullException(nameof(queueResults));
    }

    public void HandleRequests()
    {
        while (!_queueRequests.IsEmpty)
        {
            if (!_queueRequests.TryDequeue(out var request))
                continue;

            try
            {
                var result = request!.Operation.Calculate();
                _queueResults.Enqueue(new CalculationResult(request.Expression, result));
            }
            catch (Exception e)
            {
                _queueResults.Enqueue(new CalculationResult(request!.Expression, e));   
            }
        }
    }
}