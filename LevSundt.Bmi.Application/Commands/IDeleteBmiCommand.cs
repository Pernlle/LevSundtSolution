
namespace LevSundt.Bmi.Application.Commands
{
    public interface IDeleteBmiCommand
    {
        void Delete(BmiCreateRequestDto bmiCreateRequestDto);
    }
}
