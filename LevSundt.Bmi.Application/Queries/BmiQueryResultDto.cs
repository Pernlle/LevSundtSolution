
namespace LevSundt.Bmi.Application.Queries
{
    public class BmiQueryResultDto
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bmi { get; set; }
        public string WeightCategori { get; set; }
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime Date { get; set; }
    }
}
