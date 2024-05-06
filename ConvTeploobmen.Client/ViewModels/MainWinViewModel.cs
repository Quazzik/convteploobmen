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
using ConvTeploobmen.Client.DataBase;
using SQLitePCL;
using System.Windows;
using Windows.Security.Authentication.Web.Core;

namespace ConvTeploobmen.Client.ViewModels
{
    public class MainWinViewModel : ReactiveObject
    {
        private ConvTeploobDbContext _context;
        private const int MAX_GAS_ELEMENTS_COUNT = 9;
        private const int MAX_ATTACK_ANGLE = 90;
        private InputData _inputData = new();
        private OutputData _outputData = new();

        public MainWinViewModel()
        {
            List<string> Gases = [
                "CO2",
                "H2O",
                "O2",
                "N2"
            ];
            foreach (var g in Gases)
            {
                _context = new ConvTeploobDbContext();
                _calculateCommand = ReactiveCommand.Create(Calculate);

                var newGasEl = new GasElementViewModel(this, g);
                GasElements.Add(newGasEl);
            }
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

        private double _totalPercent;

        public double TotalPercent
        {
            get => _totalPercent;
            set => this.RaiseAndSetIfChanged(ref _totalPercent, value);
        }

        private ReactiveCommand<Unit, Unit> _calculateCommand;
        public ReactiveCommand<Unit, Unit> CalculateCommand => _calculateCommand;

        private void Calculate()
        {
#pragma warning disable CS8602

            _inputData.AttackAngleValue = Getaav(_inputData.AttackAngle);


        }
        private double Findaav(double mark, double angle)
        {
            var deltatemp = angle % 10;
            var valuemore = _context.AttackAngles.FirstOrDefault(a => a.Degree == mark).Value;
            var valueless = _context.AttackAngles.FirstOrDefault(a => a.Degree == mark - 10).Value;
            var value = valuemore - valueless;
            var res = value / 10 * deltatemp + valueless;
            return res;
        }

        private double Getaav(double angle)
        {
            if (angle > 90) angle = angle % 90;
            if (angle <= 0) { MessageBox.Show("Значение угла атаки указано неверно"); return 0; }
            else
            {
                if (angle % 10 == 0)
                {
                    return _context
                        .AttackAngles
                        .FirstOrDefault(a => a.Degree == angle)
                        .Value;
                }
                else
                {
                    int mark;
                    var angles = _context.AttackAngles.ToArray();
                    if (angle > 10)
                    {

                        for (int i = 0; i != angles.Length; i++)
                        {
                            if (angle < angles[i].Degree)
                            {
                                mark = (i + 1) * 10;
                                return Findaav(mark, angle);
                            }
                        }
                    }
                    else
                    {
                        return angles[0].Value / 10 * angle;
                    }
                }
            }return 0;
        }
#pragma warning restore CS8602
    }
}