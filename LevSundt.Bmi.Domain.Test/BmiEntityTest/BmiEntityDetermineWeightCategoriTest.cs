using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;
using Moq;


namespace Bmi.Domain.Test.BmiEntity_Test
{
    public class BmiEntityDetermineWeightCategoriTest
    {
        [Theory]
        [InlineData(10, "Undervægtig")]  // Mid value for Undervægtig
        [InlineData(18.4, "Undervægtig")] // Max value for Undervægtig
        [InlineData(18.5, "Normalvægtig")] // Min value for Normalvægtig
        [InlineData(20, "Normalvægtig")] // Mid value for Normalvægtig
        [InlineData(25, "Normalvægtig")] // Max value for Normalvægtig
        [InlineData(25.1, "Overvægtig")] // Min value for Overvægtig
        [InlineData(27, "Overvægtig")] // Mid value for Overvægtig
        [InlineData(30, "Overvægtig")] // Max value for Overvægtig
        [InlineData(30.1, "Svært Overvægtig")] // Min value for Svært Overvægtig
        [InlineData(35, "Svært Overvægtig")] // Mid value for Svært Overvægtig
        public void Given_Bmi__The_WeightCategori_Is_Determined(double bmi, string exptected)
        {
            // Arrange 
            var mock = new Mock<IBmiDomainService>();
            var sut = new BmiEntityTest(mock.Object, 150, 150, bmi);
            // Act
            sut.DetermineCategori();
            // Assert 
            Assert.Equal(exptected, sut.WeightCategori);

        }
    }
    public class BmiEntityTest : BmiEntity
    {
        public BmiEntityTest(IBmiDomainService bmiDomainService, double height, double weight, double bmi) : base(bmiDomainService, height, weight, String.Empty)
        {
            base.Bmi = bmi;
        }

        public new void DetermineCategori()
        {
            base.DetermineCategori();
        }

    }
}
