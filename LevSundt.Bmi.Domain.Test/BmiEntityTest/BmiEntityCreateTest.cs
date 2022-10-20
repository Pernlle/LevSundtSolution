using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;
using Moq;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTest
{
    public class BmiEntityCreateTest
    {
        /// <summary>
        /// Acceptabel højde er [100;250]
        /// </summary>
        /// <param name="height"></param>
        [Theory]
        [InlineData(200)]
        [InlineData(250)]
        [InlineData(100)]
        //[InlineData(250.01)]
        //[InlineData(99.99)]
        public void Given_Height_Is_Valid_Then_BmiEntity_Is_Created(double height) //behaviorDriven nameing
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();

            var sut = new BmiEntity(mock.Object, height, 100,"");
            // Assert
        }

        /// <summary>
        /// Acceptabel højde er [100; 250]
        /// </summary>
        /// <param name="height"></param>
        [Theory]
        //[InlineData(200)]
        //[InlineData(250)]
        //[InlineData(100)]
        [InlineData(250.01)]
        [InlineData(99.99)]
        public void Given_Height_Is_Invalid_Then_ArgumentExeption_Is_Thrown(double height)
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();
            mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>())).Returns(false);

            // Assert
            Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, height, 100,""));
        }


        /// <summary>
        /// Acceptabel vægt er [40; 250]
        /// </summary>
        /// <param name="weight"></param>
        [Theory]
        [InlineData(200)]
        [InlineData(250)]
        [InlineData(40)]
        public void Given_Weight_Is_Valid_Then_BmiEntity_Is_Created(double weight)
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();

            var sut = new BmiEntity(mock.Object, 200, weight,"");
        }
        /// <summary>
        /// Acceptabel vægt er [40; 250]
        /// </summary>
        /// <param name="weight"></param>
        [Theory]
        [InlineData(250.01)]
        [InlineData(39.99)]
        public void Given_Weight_Is_Invalid_Then_ArgumentExeption_Is_Thrown(double weight)
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();
            mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>())).Returns(false);

            // Assert
            Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, 200, weight, ""));
        }

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
            // Act
            var sut = new BmiEntity(mock.Object, height, weight, "");
            // Assert
            Assert.Equal(expected, Math.Round(sut.Bmi, 1));
        }
        /// <summary>
        /// </summary>
        [Fact]
        public void Given_Date_Is_Valid_Then_BmiEntity_Is_Created() //behaviorDriven nameing
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();
            mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>())).Returns(false);

            var sut = new BmiEntity(mock.Object, 100, 100, "");
            // Assert
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void Given_Date_Is_Invalid_Then_ArgumentExeption_Is_Thrown()
        {
            // Arrange
            var mock = new Mock<IBmiDomainService>();
            mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>())).Returns(true);

            // Assert
            Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, 100, 100, ""));
        }


    }
}
// Arrange

// Act

// Assert