using ConvTeploobmen.MathLib;

namespace ConvTeploobmen.Tests
{
    public class Tests
    {
        private MathLib.TeploobmenCalc _lib;
        private InputData _inputData;

        [SetUp]
        public void Setup()
        {
            _inputData = new InputData()
            {
                FlowVelocity = 20d,
                PipeDiameter = 155,
                KinematicViscosity = 1,
                AttackAngle = 90,
                Temperature = 20,
                LocationQuery = LocationQuery.Коридорное
            };
            _lib = new(_inputData);
        }

        [Test]
        public void TestCorrect()
        {
            var expectedRes = 27.46456918;
            var actualRes = _lib.Calc();

            Assert.That(actualRes, Is.EqualTo(expectedRes).Within(1e-5));
        }

        [Test]
        public void TestIncorrectAngle()
        {
            _inputData.AttackAngle = -2;
            var lib = new MathLib.TeploobmenCalc(_inputData);

            Assert.Throws<ArgumentOutOfRangeException>(() => lib.Calc());
            _inputData.AttackAngle = 90;
        }

        [Test]
        public void TestIncorrectTemperature()
        {
            _inputData.Temperature = -60;
            var lib = new MathLib.TeploobmenCalc(_inputData);

            Assert.Throws<ArgumentOutOfRangeException>(() => lib.Calc());
            _inputData.Temperature = 20;
        }

        [Test]
        public void TestDivideByZero()
        {
            _inputData.KinematicViscosity = 0;
            var lib = new MathLib.TeploobmenCalc(_inputData);

            Assert.Throws<DivideByZeroException>(() => lib.Calc());
            _inputData.KinematicViscosity = 1;
        }
    }
}