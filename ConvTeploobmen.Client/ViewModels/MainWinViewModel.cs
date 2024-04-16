using ConvTeploobmen.Client.ViewModels;
using ConvTeploobmen.Client.Models;
using ConvTeploobmen.MathLib;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using Microsoft.EntityFrameworkCore;

namespace ConvTeploobmen.Client.ViewModels
{
    public class MainWinViewModel : ReactiveObject
    {
        private DbContext DbContext;
        private const int MAX_GAS_ELEMENTS_COUNT = 9;
        private const int MAX_ATTACK_ANGLE = 90;
        private InputData _inputData = new();
        private OutputData _outputData = new();

        public MainWinViewModel()
        {

            AddGasElementCommand = ReactiveCommand.Create(AddGasElement, 
                this.WhenAnyValue(vm => vm.GasElements.Count)
                .Select(count => count <= MAX_GAS_ELEMENTS_COUNT));
            List<string> gases = [ // dBContext.Gases.ToList();
                "CO2",
                "CH4",
                "O2",
                "N2",
                "CO",
                "H2O",
                "C2H6"
            ];
            Gases = new(gases);
        }

        private ObservableCollection<string> _gases = [];

        public ObservableCollection<string> Gases
        {
            get => _gases;
            set => this.RaiseAndSetIfChanged(ref _gases, value);
        }

        public double Nu
        {
            get => _outputData.nu;
            set
            {
                if (value == _outputData.nu)
                    return;

                _outputData.nu = value;
                this.RaisePropertyChanged(nameof(Nu));
            }
        }

        public double Pr
        {
            get => _outputData.pr;
            set
            {
                if (value == _outputData.pr)
                    return;

                _outputData.pr = value;
                this.RaisePropertyChanged(nameof(Pr));
            }
        }

        public double Aas
        {
            get => _outputData.aas;
            set
            {
                if (value == _outputData.aas)
                    return;

                _outputData.aas = value;
                this.RaisePropertyChanged(nameof(Aas));
            }
        }

        public double Re
        {
            get => _outputData.re;
            set
            {
                if (value == _outputData.re)
                    return;

                _outputData.re = value;
                this.RaisePropertyChanged(nameof(Re));
            }
        }

        public double FlowVelocity
        {
            get => _inputData.FlowVelocity;
            set
            {
                if (value == _inputData.FlowVelocity)
                    return;

                _inputData.FlowVelocity = value;
                this.RaisePropertyChanged(nameof(FlowVelocity));
            }
        }
        
        public double PipeDiameter
        {
            get => _inputData.PipeDiameter;
            set
            {
                if (value == _inputData.PipeDiameter)
                    return;

                _inputData.PipeDiameter = value;
                this.RaisePropertyChanged(nameof(PipeDiameter));
            }
        }
        
        public double KinematicViscosity
        {
            get => _inputData.KinematicViscosity;
            set
            {
                if (value == _inputData.KinematicViscosity)
                    return;

                _inputData.KinematicViscosity = value;
                this.RaisePropertyChanged(nameof(KinematicViscosity));
            }
        }
        
        public double AttackAngle
        {
            get => _inputData.AttackAngle;
            set
            {
                if (value == _inputData.AttackAngle)
                    return;

                _inputData.AttackAngle = value % MAX_ATTACK_ANGLE;
                this.RaisePropertyChanged(nameof(AttackAngle));
            }
        }

        public double Temperature
        {
            get => _inputData.Temperature;
            set
            {
                if (value == _inputData.Temperature)
                    return;

                _inputData.Temperature = value;
                this.RaisePropertyChanged(nameof(Temperature));
            }
        }

        public LocationQuery LocationQuery
        {
            get => _inputData.LocationQuery;
            set
            {
                if (value == _inputData.LocationQuery)
                    return;

                _inputData.LocationQuery = value;
                this.RaisePropertyChanged(nameof(LocationQuery));
            }
        }

        private ObservableCollection<GasElementViewModel> _gasElements = [];
        public ObservableCollection<GasElementViewModel> GasElements
        {
            get => _gasElements;
            set => this.RaiseAndSetIfChanged(ref _gasElements, value);
        }

        public ReactiveCommand<Unit, Unit> AddGasElementCommand { get; set; }

        private void AddGasElement()
        {
            var newGasEl = new GasElementViewModel(this, Gases);
            GasElements.Add(newGasEl);
        }

        private double _totalPercent;

        public double TotalPercent
        {
            get => _totalPercent;
            set => this.RaiseAndSetIfChanged(ref _totalPercent, value);
        }

        public ReactiveCommand<Unit,Unit> CalculateCommand { get; set; }

        private void Calculate()
        {
            
        }
    }
}