using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Commands.Implementation
{
    public class CreateBmiCommand : ICreateBmiCommand
    {
        private readonly IBmiDomainService _domainService;
        private readonly IBmiRepository _bmiRepository;
        public CreateBmiCommand(IBmiRepository bmiRePository, IBmiDomainService domainService)
        {
            _domainService = domainService;
            _bmiRepository = bmiRePository;
        }
        void ICreateBmiCommand.Create(BmiCreateRequestDto bmiCreateRequestDto)
        {
            var bmi = new BmiEntity(_domainService, bmiCreateRequestDto.Height, bmiCreateRequestDto.Weight, bmiCreateRequestDto.UserId);
            _bmiRepository.Add(bmi);
        }
    }
}
