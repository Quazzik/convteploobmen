using ConvTeploobmen.Client.Models;
using ConvTeploobmen.MathLib;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using ConvTeploobmen.Client.DataBase;
using System.Windows;
using ConvTeploobmen.App.DataBase;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Legends;

namespace ConvTeploobmen.Client.ViewModels
{
    public class MainWinViewModel : ReactiveObject
    {
        private ConvTeploobDbContext _context;
        private const int MAX_ATTACK_ANGLE = 90;
        private double _totalPercent;
        private InputData _inputData = new();
        private OutputData _outputData = new();
        private PlotModel _graphModel;
        private List<(int angle, double result)> graphData1 = new List<(int angle, double result)>();
        private List<(int angle, double result)> graphData2 = new List<(int angle, double result)>();
        private ObservableCollection<GasElementViewModel> _gasElements = [];

        public MainWinViewModel()
        {
            GraphModel = new PlotModel{ Background = OxyColor.FromRgb(66, 66, 66) };
            List<string> Gases = [
                "CO2",
                "H2O",
                "O2",
                "N2"
            ];
            _context = new ConvTeploobDbContext();

            _graphCommand = ReactiveCommand.Create(CreateGraph, this.WhenAnyValue(
                vm => vm.Alpha)
                .Select(x => x != 0));

            _calculateCommand = ReactiveCommand.Create(Calculate, this.WhenAnyValue(
                vm => vm.TotalPercent,
                vm => vm.FlowVelocity,
                vm => vm.PipeDiameter,
                vm => vm.AttackAngle,
                vm => vm.Temperature)
                .Select(x => x.Item1 == 100 && x.Item2 > 0 && x.Item3 > 0 && x.Item4 > 0 && x.Item5 > 99));

            foreach (var g in Gases)
            {
                var newGasEl = new GasElementViewModel(this, g);
                GasElements.Add(newGasEl);
            }
        }

        #region ReactiveCommands
        private ReactiveCommand<Unit, Unit> _graphCommand;
        public ReactiveCommand<Unit, Unit> GraphCommand => _graphCommand;


        private ReactiveCommand<Unit, Unit> _calculateCommand;
        public ReactiveCommand<Unit, Unit> CalculateCommand => _calculateCommand;
        #endregion

        #region Properties
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

        public double Alpha
        {
            get => _outputData.alpha;
            set
            {
                if (value == _outputData.alpha)
                    return;

                _outputData.alpha = value;
                this.RaisePropertyChanged(nameof(Alpha));
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

                _inputData.AttackAngle = value % (MAX_ATTACK_ANGLE + 1);
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
                this.RaisePropertyChanged();
                if (value == _inputData.LocationQuery)
                    return;

                _inputData.LocationQuery = value;
                this.RaisePropertyChanged(nameof(LocationQuery));
            }
        }

        public PlotModel GraphModel
        {
            get => _graphModel;
            set
            {
                if (_graphModel != value)
                {
                    _graphModel = value;
                    this.RaisePropertyChanged(nameof(GraphModel));
                }
            }
        }

        public ObservableCollection<GasElementViewModel> GasElements
        {
            get => _gasElements;
            set => this.RaiseAndSetIfChanged(ref _gasElements, value);
        }

        public double TotalPercent
        {
            get => _totalPercent;
            set => this.RaiseAndSetIfChanged(ref _totalPercent, value);
        }
        #endregion

        #region Graph
        private void CreateGraph()
        {
            var plotModel = new PlotModel();

            var xAxis = new LinearAxis {
                Position = AxisPosition.Left,
                Minimum = graphData1[0].result-2,
                Maximum=graphData1.Last().result+2,
                Title="Конвективный коэффициент",
                TitleColor=OxyColors.White,
                TicklineColor=OxyColors.White,
                AxislineColor = OxyColors.White,
                TextColor = OxyColors.White
            };

            var yAxis = new LinearAxis {
                Position = AxisPosition.Bottom,
                Minimum = graphData1[0].angle-2,
                Maximum=graphData1.Last().angle+2,
                Title="Угол атаки",
                TitleColor=OxyColors.White,
                TicklineColor=OxyColors.White,
                AxislineColor=OxyColors.White,
                TextColor=OxyColors.White
            };


            var lineSeries2 = new LineSeries
            {
                Title="Коридорное расположение",
                MarkerType = MarkerType.Square,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColor.FromRgb(205, 220, 57),
                LineStyle = LineStyle.LongDashDot,
                Color = OxyColor.FromRgb(205, 220, 57),
            };

            var lineSeries1 = new LineSeries
            {
                Title = "Шахматное расположение",
                MarkerType = MarkerType.Triangle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Black,
                MarkerFill = OxyColor.FromRgb(205, 220, 57),
                LineStyle = LineStyle.LongDashDotDot,
                Color = OxyColor.FromRgb(205, 220, 57),
            };

            foreach (var dataPoint in graphData2)
            {
                lineSeries2.Points.Add(new DataPoint(dataPoint.angle, dataPoint.result));
            }

            foreach (var dataPoint in graphData1)
            {
                lineSeries1.Points.Add(new DataPoint(dataPoint.angle, dataPoint.result));
            }

            plotModel.Title = "Зависимость конвективного коэффициента от угла атаки";
            plotModel.TitleColor = OxyColors.White;
            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);
            plotModel.Series.Add(lineSeries2);
            plotModel.Series.Add(lineSeries1);
            plotModel.Background = OxyColor.FromRgb(66,66,66);
            plotModel.Legends.Add(new Legend()
            {
                LegendTextColor= OxyColors.White,
                LegendPosition=LegendPosition.TopLeft,
                LegendMargin=10,
            });
            GraphModel = plotModel;
        }
        #endregion

        #region CalculateCommand
#pragma warning disable CS8602
        private void Calculate()
        {
            //Найти значение угла атаки
            _inputData.AttackAngleValue = Getaav(_inputData.AttackAngle);

            //Найти кинематическую вязкость для смеси газов
            var viscositiesData = _context.ViscositiesKoeffs.ToList();

            //класс-коннектор через который я обращаюсь с двумя типами данных к одному методу
            var connector = new List<ConnectingType>();
            foreach (var viscos in viscositiesData)
            {
                connector.Add(new ConnectingType { Name = viscos.GasName, Val1 = viscos.koeff1, Val2 = viscos.koeff2, Val3 = viscos.koeff3 });
            }
            _inputData.KinematicViscosity = CalcApproximBetter(connector);

            //Найти теплопроводность для данной смеси газов
            var ThermalConductivities = _context.ThermalConductancesKoeffs.ToList();
            for (int i = 0; i < ThermalConductivities.Count; i++)
            {
                connector[i].Name = ThermalConductivities[i].GasName;
                connector[i].Val1 = ThermalConductivities[i].koeff1;
                connector[i].Val2 = ThermalConductivities[i].koeff2;
                connector[i].Val3 = ThermalConductivities[i].koeff3;
            }
            _inputData.ThermalConductivity = CalcApproximBetter(connector);

            var answers = new TeploobmenCalc(_inputData).Calc();

            Re = Math.Round(answers.re,3);
            Aas = Math.Round(answers.aas,3);
            Pr = Math.Round(answers.pr,3);
            Nu = Math.Round(answers.nu,3);
            Alpha = Math.Round(answers.alpha,3);

            graphData1.Clear();
            graphData2.Clear();

            var graphCalculateData = _inputData;
            for (int angle = 10; angle <=90; angle += 10)
            {
                graphCalculateData.AttackAngleValue = Getaav(angle);
                graphCalculateData.LocationQuery = LocationQuery.Шахматное;
                double res = new TeploobmenCalc(graphCalculateData).Calc().alpha;
                graphData1.Add((angle, res));

                graphCalculateData.LocationQuery = LocationQuery.Коридорное;
                res = new TeploobmenCalc(graphCalculateData).Calc().alpha;
                graphData2.Add((angle, res));
            }
        }
        #endregion

        #region CalcSupportMethods
        private double CalcApproximBetter(List<ConnectingType> data)
        {
            var res = new List<double>([0,0,0,0]);
            foreach (var d in data)
            {
                var value = CalcArgs(0, d.Val1, d.Val2, d.Val3, Temperature);
                switch (d.Name)
                {
                    case "CO2":
                        res[0] = value; break;
                    case "H2O":
                        res[1] = value; break;
                    case "N2":
                        res[2] = value; break;
                    case "O2":
                        res[3] = value; break;
                }
            }
            return CalcImportances(res);
        }

        private double CalcImportances(List<double> values)
        {
            for(int i = 0; i<values.Count; i++)
            {
                values[i] = values[i] * GasElements[i].GasQuantity/100;
            }
            return values.Sum();
        }

        private double CalcArgs(double arg1, double arg2, double arg3, double arg4, double temp) => (arg1 * Math.Pow(temp, 3)) + (arg2 * Math.Pow(temp, 2)) + (arg3 * temp) + arg4;

        //Находим нужные значения посредством аппроксимации

        private double Findaav(AttackAngle mark1, AttackAngle mark2, double angle)
        {
            var deltaangles = angle - mark2.Degree;
            var value = mark1.Value - mark2.Value;
            var res = value / 10 * deltaangles + mark2.Value;
            return res;
        }

        private double Getaav(double angle)
        {
            if (angle > 90) angle = angle % 90;
            if (angle <= 0) { MessageBox.Show("Значение угла атаки указано неверно"); return 0; }
            else
            {
                var res = _context.AttackAngles.FirstOrDefault(p => p.Degree== angle);
                if (res != null) return res.Value;

                var angles = _context.AttackAngles.ToList();
                if (angle > 10) 
                    {
                            AttackAngle mark2= angles.Last(x => x.Degree < angle);
                            AttackAngle mark1= angles.First(x => x.Degree > angle);
                            return Findaav(mark1,mark2, angle);
                    }
                return angles[0].Value / 10 * angle;
            }
        }
#pragma warning restore CS8602
        #endregion
    }
}