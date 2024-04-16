using System.Runtime.CompilerServices;
using static System.Math;

namespace ConvTeploobmen.MathLib
{
    public class MathLib
    {
        private readonly InputData _inputData;

        #region tempSegment

        private readonly Dictionary<double, double> _prs = new()
        {
            {0, 0.707},
            {20,0.703}
        };

        private readonly Dictionary<double, double> _aas = new()
        {
            {10, 0.42},
            {90,1}
        };

        #endregion
        public MathLib(InputData inputData)
        {
            _inputData = inputData;
        }

        public double Calc()
        {
            var re = CalcRe();
            //Потом из WPF будут приходить нормальные цифры
            var pr = TryGetPr(_inputData.Temperature);
            var aas = TryGetAas(_inputData.AttackAngle);

            return CalcNu(re, aas, pr);
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

        private double TryGetPr(double key) => _prs.TryGetValue(key, out var pr)
                ? pr
                : throw new ArgumentOutOfRangeException(nameof(key));

        private double TryGetAas(double key) => _aas.TryGetValue(key, out var aa)
                ? aa
                : throw new ArgumentOutOfRangeException(nameof(key));
    }
}