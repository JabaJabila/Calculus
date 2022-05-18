using Calculus.Core.Handling.Queues;
using ReactiveUI;

namespace Calculus.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CalculatorViewModel _calculator;
        private OperationsConfigurationViewModel _configuration;
        private QueueRequestPanelViewModel _queueRequest;
        private QueueResultPanelViewModel _queueResult;
        public MainWindowViewModel()
        {
            _calculator = new CalculatorViewModel();
            _configuration = new OperationsConfigurationViewModel();
            _queueRequest = new QueueRequestPanelViewModel();
            _queueResult = new QueueResultPanelViewModel();
        }
        
        public CalculatorViewModel Calculator
        {
            get => _calculator;
            private set => this.RaiseAndSetIfChanged(ref _calculator, value);
        }
        
        public OperationsConfigurationViewModel Configuration
        {
            get => _configuration;
            private set => this.RaiseAndSetIfChanged(ref _configuration, value);
        }

        public QueueRequestPanelViewModel QueueRequests
        {
            get => _queueRequest;
            private set => this.RaiseAndSetIfChanged(ref _queueRequest, value);
        }

        public QueueResultPanelViewModel QueueResults
        {
            get => _queueResult;
            private set => this.RaiseAndSetIfChanged(ref _queueResult, value);
        }
    }
}