using Xunit;

namespace Sparky
{
    public class GradingCalculator_XUnitTests
    {
        private GradingCalculator _gradingCalc;
        public GradingCalculator_XUnitTests()
        {
            _gradingCalc = new GradingCalculator();
        }

        [Fact]
        public void GradeChecker_InputScore95AndAttendance90_ReturnGradeA()
        {
            _gradingCalc.Score = 95;
            _gradingCalc.AttendancePercentage = 90;

            var result = _gradingCalc.GetGrade();

            Assert.Equal("A", result);
        }

        [Fact]
        public void GradeChecker_InputScore85AndAttendance90_ReturnGradeB()
        {
            _gradingCalc.Score = 85;
            _gradingCalc.AttendancePercentage = 90;

            var result = _gradingCalc.GetGrade();

            Assert.Equal("B", result);
        }

        [Fact]
        public void GradeChecker_InputScore95AndAttendance65_ReturnGradeB_2()
        {
            _gradingCalc.Score = 95;
            _gradingCalc.AttendancePercentage = 65;

            var result = _gradingCalc.GetGrade();

            Assert.Equal("B", result);
        }

        [Fact]
        public void GradeChecker_InputScore65AndAttendance90_ReturnGradeC()
        {
            _gradingCalc.Score = 65;
            _gradingCalc.AttendancePercentage = 90;

            var result = _gradingCalc.GetGrade();

            Assert.Equal("C", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(75, 55)]
        [InlineData(50, 90)]
        public void GradeChecker_InputMultipleScoreAndAttendance_ReturnGradeF(int score, int attendancePercentage)
        {
            _gradingCalc.Score = score;
            _gradingCalc.AttendancePercentage = attendancePercentage;

            var result = _gradingCalc.GetGrade();

            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(75, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GradeChecker_InputMultipleScoreAndAttendance_ReturnGrade(int score, int attendancePercentage, string expectedResult)
        {
            _gradingCalc.Score = score;
            _gradingCalc.AttendancePercentage = attendancePercentage;

            var result = _gradingCalc.GetGrade();

            Assert.Equal(expectedResult, result);
        }
    }
}
