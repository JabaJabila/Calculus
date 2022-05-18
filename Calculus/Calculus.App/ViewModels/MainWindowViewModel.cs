using ReactiveUI;

namespace Calculus.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CalculatorViewModel _calculator;
        private OperationsConfigurationViewModel _configuration;
        
        public MainWindowViewModel()
        {
            _calculator = new CalculatorViewModel();
            _configuration = new OperationsConfigurationViewModel();
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
    }
}