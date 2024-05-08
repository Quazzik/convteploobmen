using ConvTeploobmen.Client.Models;
using System.Runtime.CompilerServices;
using static System.Math;

namespace ConvTeploobmen.MathLib
{
    public class TeploobmenCalc
    {
        private readonly InputData _inputData;

        public TeploobmenCalc(InputData inputData)
        {
            _inputData = inputData;
        }

        public OutputData Calc()
        {
            var re = CalcRe();
            //Потом из WPF будут приходить нормальные цифры
            var pr = _inputData.Prandtl;
            var aas = _inputData.AttackAngleValue;

            var res = new OutputData() { re=re, aas=aas, pr=pr, nu= CalcNu(re, aas, pr) };
            return res;
        }

        private double CalcNu(double re, double aas, double pr)
        {
            return re >= 1e+3
                ? 0.56 * aas * Pow(re, 0.5) * Pow(pr, 0.36)
                : _inputData.LocationQuery switch
                    {
                        LocationQuery.Шахматное => 0.4 * aas * Pow(re, 0.6) * Pow(pr, 0.36),
                        _ => 0.22 * aas * Pow(re, 0.65) * Pow(pr, 0.36)
                    };
        }

        private double CalcRe() => _inputData.KinematicViscosity > 0
                ? _inputData.FlowVelocity * _inputData.PipeDiameter / _inputData.KinematicViscosity
                : throw new DivideByZeroException();
    }
}