using Calculus.Core.Calculations.Parsing;
using Calculus.Core.Handling.Queues;

namespace Calculus.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var parser = new CommonArithmeticParser();
            var queueResults = new QueueResults();
            var queueRequests = new QueueRequests(parser);

            Calculator = new CalculatorViewModel(parser);
            Configuration = new OperationsConfigurationViewModel();
            QueueRequests = new QueueRequestPanelViewModel(queueRequests, queueResults);
            QueueResults = new QueueResultPanelViewModel(queueResults);
        }
        
        public CalculatorViewModel Calculator { get; }

        public OperationsConfigurationViewModel Configuration { get; }

        public QueueRequestPanelViewModel QueueRequests { get; }

        public QueueResultPanelViewModel QueueResults { get; }
    }
}