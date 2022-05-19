using Calculus.Core.Calculations.Operations.StandardOperations;
using ReactiveUI;

namespace Calculus.App.ViewModels;

public class OperationsConfigurationViewModel : ViewModelBase
{
    private const int DefaultDelay = 5;
    private const int SecToMsConst = 1000;
    private const int MaximusSecDelay = 60;

    private int _plusDelay;
    private int _minusDelay;
    private int _multiplyDelay;
    private int _divideDelay;
    
    public OperationsConfigurationViewModel()
    {
        PlusDelaySec = MinusDelaySec = MultiplyDelaySec = DivideDelaySec = DefaultDelay;
    }
    
    public int PlusDelaySec
    {
        get => _plusDelay;
        set
        {
            PlusOperation.DelayMs = value is >= 0 and <= MaximusSecDelay ?
                _plusDelay * SecToMsConst : DefaultDelay * SecToMsConst;
            
            this.RaiseAndSetIfChanged(ref _plusDelay, value);
        }
    }

    public int MinusDelaySec
    {
        get => _minusDelay;
        set
        {
            MinusOperation.DelayMs = value is >= 0 and <= MaximusSecDelay ?
                _minusDelay * SecToMsConst : DefaultDelay * SecToMsConst;
            
            this.RaiseAndSetIfChanged(ref _minusDelay, value);
        }
        
    }

    public int MultiplyDelaySec
    {
        get => _multiplyDelay;
        set
        {
            MultiplyOperation.DelayMs = value is >= 0 and <= MaximusSecDelay ?
                _multiplyDelay * SecToMsConst : DefaultDelay * SecToMsConst;
            
            this.RaiseAndSetIfChanged(ref _multiplyDelay, value);
        }
    }

    public int DivideDelaySec
    {
        get => _divideDelay;
        set
        {
            DivideOperation.DelayMs = value is >= 0 and <= MaximusSecDelay ?
                _divideDelay * SecToMsConst : DefaultDelay * SecToMsConst;
            
            this.RaiseAndSetIfChanged(ref _divideDelay, value);
        }
    }
}