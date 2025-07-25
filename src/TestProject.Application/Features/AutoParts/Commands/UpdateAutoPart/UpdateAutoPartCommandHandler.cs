using AutoMapper;
using TestProject.Application.Contracts.Persistence;
using TestProject.Application.Exceptions;
using TestProject.Domain.Entities;
using MediatR;

namespace TestProject.Application.Features.AutoParts.Commands.UpdateAutoPart
{
    public class UpdateAutoPartCommandHandler : IRequestHandler<UpdateAutoPartCommand>
    {
        private readonly IAsyncRepository<AutoPart> _autopartRepository;
        private readonly IMapper _mapper;

        public UpdateAutoPartCommandHandler(IMapper mapper, IAsyncRepository<AutoPart> autopartRepository)
        {
            _mapper = mapper;
            _autopartRepository = autopartRepository;
        }

        public async Task Handle(UpdateAutoPartCommand request, CancellationToken cancellationToken)
        {

            var autopartToUpdate = await _autopartRepository.GetByIdAsync(request.AutoPartId);

            if (autopartToUpdate == null)
            {
                throw new NotFoundException(nameof(AutoPart), request.AutoPartId);
            }

            var validator = new UpdateAutoPartCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, autopartToUpdate, typeof(UpdateAutoPartCommand), typeof(AutoPart));

            await _autopartRepository.UpdateAsync(autopartToUpdate);
        }
    }
}