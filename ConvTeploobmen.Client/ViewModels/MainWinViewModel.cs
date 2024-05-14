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
using System.Reflection.Metadata;
using ConvTeploobmen.App.DataBase;
using MaterialDesignThemes.Wpf.Converters;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.CompilerServices;

namespace ConvTeploobmen.Client.ViewModels
{
    public class MainWinViewModel : ReactiveObject
    {
        private ConvTeploobDbContext _context;
        private const int MAX_GAS_ELEMENTS_COUNT = 9;
        private const int MAX_ATTACK_ANGLE = 90;
        private InputData _inputData = new();
        private OutputData _outputData = new();
        private ImageSource _selectedImage;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWinViewModel()
        {
            SelectedImage = GetImageSourceForLocation(LocationQuery.Шахматное);
            List<string> Gases = [
                "CO2",
                "H2O",
                "O2",
                "N2"
            ];
            _context = new ConvTeploobDbContext();
            _calculateCommand = ReactiveCommand.Create(Calculate, this.WhenAnyValue(
                vm => vm.TotalPercent,
                vm => vm.FlowVelocity,
                vm => vm.PipeDiameter,
                vm => vm.AttackAngle,
                vm => vm.Temperature)
                .Select(x => x.Item1 == 100 && x.Item2 > 0 && x.Item3 > 0 && x.Item4 > 0 && x.Item5 > 0));
            foreach (var g in Gases)
            {
                var newGasEl = new GasElementViewModel(this, g);
                GasElements.Add(newGasEl);
            }

            this.WhenAnyValue(vm => vm.LocationQuery).Subscribe(lc => { SelectedImage = GetImageSourceForLocation(lc); });
        }

        public ImageSource SelectedImage
        {
            get => _selectedImage;
            set
            {
                if (_selectedImage != value)
                {
                    _selectedImage = value;
                    this.RaisePropertyChanged(nameof(SelectedImage));
                }
            }
        }

        private ImageSource GetImageSourceForLocation(LocationQuery location)
        {
            string imagePath = "";
            switch (location)
            {
                case LocationQuery.Коридорное:
                    imagePath = "D:\\convteploobmen\\convteploobmen\\ConvTeploobmen.Client\\Public\\koridor.png";
                    break;
                case LocationQuery.Шахматное:
                    imagePath = "D:\\convteploobmen\\convteploobmen\\ConvTeploobmen.Client\\Public\\shaxmat.png";
                    break;
            }
            return new BitmapImage(new Uri(imagePath, System.UriKind.RelativeOrAbsolute));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedImage));
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

#pragma warning disable CS8602
        private void Calculate()
        {
            //Найти значение угла атаки
            _inputData.AttackAngleValue = Getaav(_inputData.AttackAngle);

            //Найти кинематическую вязкость для смеси газов
            List<double> viscosities = [15e-6, 14.9e-6, 15.8e-6, 15.7e-6];

            List<double> viscosityImportances = [];

            for (int i = 0; i < GasElements.Count; i++)
            {
                viscosityImportances.Add(GasElements[i].GasQuantity * viscosities[i] / 100);
            }

            _inputData.KinematicViscosity = viscosityImportances.Sum();

            //Найти число прандтля для текущей температуры
            _inputData.Prandtl = GetPr(_inputData.Temperature);

            var answers = new TeploobmenCalc(_inputData).Calc();

            Re = answers.re;
            Aas = answers.aas;
            Pr = answers.pr;
            Nu = answers.nu;
        }

        //Находим нужные значения посредством аппроксимации
        private double GetPr(double temperature)
        {
            if (temperature < -50)
            {
                MessageBox.Show("Указанная температура не охватывается базой данных");
                return 0;
            }

            var res = _context.Prandtls.FirstOrDefault(p=>p.Temperature == temperature);
            if (res!= null) return res.Value;

            var temperatures = _context.Prandtls.ToList();
            if (temperature > -50)
            {
                Prandtl mark2 = temperatures.Last(x => x.Temperature < Temperature);
                Prandtl mark1 = temperatures.First(x => x.Temperature > Temperature);
                return FindPr(mark1, mark2, temperature);
            }
            return temperatures[0].Value / 10 * temperature;
        }

        private double FindPr(Prandtl mark1, Prandtl mark2, double degree)
        {
            var deltaDegrees = degree - mark2.Temperature;
            var value = mark1.Value - mark2.Value;
            var res = value / (mark1.Temperature - mark2.Temperature) * deltaDegrees + mark2.Value;
            return res;
        }

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
    }
}