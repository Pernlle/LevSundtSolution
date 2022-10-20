using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Commands.Implementation
{
    public class EditBmiCommand : IEditBmiCommand
    {
        private readonly IBmiRepository _repository;
        public EditBmiCommand(IBmiRepository repository)
        {
            _repository = repository;
        }

        void IEditBmiCommand.Edit(BmiEditRequestDto requestDto)
        {
            //Read
            var model = _repository.Load(requestDto.Id, requestDto.UserId);
            //DoIt
            model.Edit(requestDto.Height, requestDto.Weight, requestDto.RowVersion);
            //Save
            _repository.Update(model);
        }
    }
}
