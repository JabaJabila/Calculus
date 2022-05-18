using ReactiveUI;

namespace Calculus.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _calculator;
        
        public MainWindowViewModel()
        {
            _calculator = new CalculatorViewModel();
        }
        
        public ViewModelBase Calculator
        {
            get => _calculator;
            private set => this.RaiseAndSetIfChanged(ref _calculator, value);
        }
    }
}