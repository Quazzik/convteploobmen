using ReactiveUI;

namespace ConvTeploobmen.Client.ViewModels
{
    public class GasElementViewModel : ReactiveObject
    {
        private readonly MainWinViewModel _parent;
        private double _gasQuantity;
        public string gasName { get; set; }

        public GasElementViewModel(MainWinViewModel parent, string gas)
        {
            _parent = parent;
            gasName = gas;
        }

        public double GasQuantity
        {
            get => _gasQuantity;
            set {
                if (_parent.TotalPercent + (value - _gasQuantity) > 100)
                    return;

                _parent.TotalPercent += value - _gasQuantity;
                this.RaiseAndSetIfChanged(ref _gasQuantity, value);
            }
        }
    }
}