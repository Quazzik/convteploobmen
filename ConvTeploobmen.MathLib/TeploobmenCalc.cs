using ConvTeploobmen.Client.Models;
using System.Runtime.CompilerServices;
using Windows.Devices.WiFiDirect;
using static System.Math;

namespace ConvTeploobmen.MathLib
{
    public class TeploobmenCalc
    {
        private readonly InputData _inputData;
        private readonly double arg1 = -3e-10;
        private readonly double arg2 = 6e-7;
        private readonly double arg3 = -2e-4;
        private readonly double arg4 = 0.7078;

        public TeploobmenCalc(InputData inputData)
        {
            _inputData = inputData;
            _inputData.PipeDiameter = _inputData.PipeDiameter;
        }

        public OutputData Calc()
        {
            var temp = _inputData.Temperature;
            var re = CalcRe();
            //Потом из WPF будут приходить нормальные цифры
            var pr = (arg1 * Math.Pow(temp, 3))+(arg2 * Math.Pow(temp, 2))+(arg3 * temp)+arg4;
            var aas = _inputData.AttackAngleValue;
            var nu = CalcNu(re, aas, pr);

            var res = new OutputData() { re = re, aas = aas, pr = pr, nu = nu, alpha = CalcAlpha(nu)};
            return res;
        }

        private double CalcNu(double re, double aas, double pr)
        {
            return re <= 1e+3
                ? (0.56 * aas * Pow(re, 0.5) * Pow(pr, 0.36))
                : _inputData.LocationQuery switch
                {
                    LocationQuery.Шахматное => (0.4 * aas * Pow(re, 0.6) * Pow(pr, 0.36)),
                    _ => (0.22 * aas * Pow(re, 0.65) * Pow(pr, 0.36))
                };
        }

        private double CalcRe() => _inputData.KinematicViscosity > 0
                ? (_inputData.FlowVelocity * _inputData.PipeDiameter * 1e-3 / _inputData.KinematicViscosity)
                : throw new DivideByZeroException();

        private double CalcAlpha(double nu) => (_inputData.ThermalConductivity * nu /((_inputData.PipeDiameter) * 1e-3));
    }
}