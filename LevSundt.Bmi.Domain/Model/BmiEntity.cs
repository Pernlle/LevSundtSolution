using LevSundt.Bmi.Domain.DomainServices;
using System.ComponentModel.DataAnnotations;

namespace LevSundt.Bmi.Domain.Model
{
    public class BmiEntity
    {
        // For Entity Framework
        internal BmiEntity()
        {

        }
        private readonly IBmiDomainService _domainService;
        public BmiEntity(IBmiDomainService domainService, double height, double weight, string userId)
        {
            // Check pre-condition
            Height = height;
            Weight = weight;
            Date = DateTime.Now;
            _domainService = domainService;
            UserId = userId;

            if (!IsValid()) throw new ArgumentException("Pre-Conditions er ikke overholdt");
            if (_domainService.BmiExistsOnDate(Date.Date, userId)) throw new ArgumentException("Pre-Conditions er ikke overholdt, Der eksisterer allerede en BMI måling for idag");

            CalculateBmi();
            DetermineCategori();
        }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public double Bmi { get; protected set; }
        public string WeightCategori { get; private set; }
        public string UserId { get; private set; }
        public DateTime Date { get; set; }
        public int Id { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Acceptabel højde er [100; 250]
        /// Acceptabel vægt er [40; 250]
        /// </summary>
        /// <returns></returns>
        protected bool IsValid()
        {
            if (Height < 100) return false;
            if (Height > 250) return false; 

            if (Weight < 40) return false;
            if (Weight > 250) return false;

            return true;
        }
        protected void CalculateBmi()
        {
            Bmi = Math.Round((Weight / ((Height * Height) / 10000)), 1);
        }
        protected void DetermineCategori()
        {
            if (Bmi < 18.5) WeightCategori = "Undervægtig";
            if (Bmi >= 18.5 && Bmi <= 25) WeightCategori = "Normalvægtig";
            if (Bmi > 25 && Bmi <= 30) WeightCategori = "Overvægtig";
            if (Bmi > 30) WeightCategori = "Svært Overvægtig";
        }

        public void Edit(double height, double weight, byte[] rowVersion)
        {
            // Check pre-condition
            Height = height;
            Weight = weight;
            RowVersion = rowVersion;

            if (!IsValid()) throw new ArgumentException("Pre-Conditions er ikke overholdt");

            CalculateBmi();
            DetermineCategori();
        }
    }
}
