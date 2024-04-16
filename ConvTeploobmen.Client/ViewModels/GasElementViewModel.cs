using ConvTeploobmen.Client.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using ABI.System.Collections.Generic;
using ConvTeploobmen.Client.Models;

namespace ConvTeploobmen.Client.ViewModels
{
    public class GasElementViewModel : ReactiveObject
    {
        private readonly MainWinViewModel _parent;
        private GasRecordViewModel _gasName;
        private double _gasQuantity;

        public GasElementViewModel(MainWinViewModel parent, ObservableCollection<string> gases)
        {
            _parent = parent;
            Gases = gases;
            RemoveGasElementCommand = ReactiveCommand.Create(RemoveGasElement);
        }

        public GasRecordViewModel GasName
        {
            get => _gasName;
            set
            {
                this.RaiseAndSetIfChanged(ref _gasName, value);
            }
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

        public ReactiveCommand<Unit, Unit> RemoveGasElementCommand { get; set; }
        public ObservableCollection<string> Gases { get; set; }

        private void RemoveGasElement()
        {
            _parent.TotalPercent -= GasQuantity;
            _parent.GasElements.Remove(this);
        }
    }
}