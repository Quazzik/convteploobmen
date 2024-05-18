﻿using ConvTeploobmen.Client.Models;
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
            var pr = Math.Round(_inputData.Prandtl,3);
            var aas = Math.Round(_inputData.AttackAngleValue,3);
            var nu = CalcNu(re, aas, pr);

            var res = new OutputData() { re = re, aas = aas, pr = pr, nu = nu, alpha = CalcAlpha(nu)};
            return res;
        }

        private double CalcNu(double re, double aas, double pr)
        {
            return re >= 1e+3
                ? Math.Round((0.56 * aas * Pow(re, 0.5) * Pow(pr, 0.36)), 3)
                : _inputData.LocationQuery switch
                {
                    LocationQuery.Шахматное => Math.Round((0.4 * aas * Pow(re, 0.6) * Pow(pr, 0.36)), 3),
                    _ => Math.Round((0.22 * aas * Pow(re, 0.65) * Pow(pr, 0.36)), 3)
                };
        }

        private double CalcRe() => _inputData.KinematicViscosity > 0
                ? Math.Round((_inputData.FlowVelocity * _inputData.PipeDiameter / _inputData.KinematicViscosity),3)
                : throw new DivideByZeroException();

        private double CalcAlpha(double nu) => _inputData.Lambda * nu / _inputData.PipeDiameter;
    }
}