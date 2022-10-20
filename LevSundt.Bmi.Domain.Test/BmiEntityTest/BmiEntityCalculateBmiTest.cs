using LevSundt.Bmi.Domain.Model;
using LevSundt.Bmi.Domain.DomainServices;
using Moq;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTest
{
    public class BmiEntityCalculateBmiTest
    {

        /// <summary>
        /// Bmi udregning
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(200, 100, 25)]
        [InlineData(190, 90, 24.9)]
        public void Given_Height_And_Weight_The_Bmi_Is_Calculatet_Correct(double height, double weight, double expected) //behaviorDriven nameing
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();
            var sut = new BmiEntityTest(mock.Object, height, weight);
            // Act
            sut.CalculateBmi();
            // Assert
            Assert.Equal(expected, Math.Round(sut.Bmi, 1));
        }

        public class BmiEntityTest : BmiEntity
        {
            public BmiEntityTest(IBmiDomainService domainService, double height, double weight) : base(domainService, height, weight, String.Empty) { }
            public new void CalculateBmi()
            {
                base.CalculateBmi();
            }
        }
    }
}
