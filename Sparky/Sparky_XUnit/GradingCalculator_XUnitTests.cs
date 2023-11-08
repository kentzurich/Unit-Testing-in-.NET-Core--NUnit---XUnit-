using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculator_XUnitTests
    {
        private GradingCalculator _gradingCalc;
        [SetUp]
        public void SetUp()
        {
            _gradingCalc = new GradingCalculator();
        }

        [Test]
        public void GradeChecker_InputScore95AndAttendance90_ReturnGradeA()
        {
            _gradingCalc.Score = 95;
            _gradingCalc.AttendancePercentage = 90;

            var result = _gradingCalc.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradeChecker_InputScore85AndAttendance90_ReturnGradeB()
        {
            _gradingCalc.Score = 85;
            _gradingCalc.AttendancePercentage = 90;

            var result = _gradingCalc.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GradeChecker_InputScore95AndAttendance65_ReturnGradeB_2()
        {
            _gradingCalc.Score = 95;
            _gradingCalc.AttendancePercentage = 65;

            var result = _gradingCalc.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GradeChecker_InputScore65AndAttendance90_ReturnGradeC()
        {
            _gradingCalc.Score = 65;
            _gradingCalc.AttendancePercentage = 90;

            var result = _gradingCalc.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(75, 55)]
        [TestCase(50, 90)]
        public void GradeChecker_InputMultipleScoreAndAttendance_ReturnGradeF(int score, int attendancePercentage)
        {
            _gradingCalc.Score = score;
            _gradingCalc.AttendancePercentage = attendancePercentage;

            var result = _gradingCalc.GetGrade();

            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(75, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeChecker_InputMultipleScoreAndAttendance_ReturnGrade(int score, int attendancePercentage)
        {
            _gradingCalc.Score = score;
            _gradingCalc.AttendancePercentage = attendancePercentage;

            return _gradingCalc.GetGrade();
        }
    }
}
