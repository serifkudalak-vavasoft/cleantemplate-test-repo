using AutoMapper;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;
using MediatR;

namespace TestProject.Application.Features.AutoParts.Commands.DeleteAutoPArt
{
    public class DeleteAutoPartCommandHandler : IRequestHandler<DeleteAutoPartCommand>
    {
        private readonly IAsyncRepository<AutoPart> _autopartRepository;
        private readonly IMapper _mapper;

        public DeleteAutoPartCommandHandler(IMapper mapper, IAsyncRepository<AutoPart> autoPartRepository)
        {
            _mapper = mapper;
            _autopartRepository = autoPartRepository;
        }

        public async Task Handle(DeleteAutoPartCommand request, CancellationToken cancellationToken)
        {
            var autoPartToDelete = await _autopartRepository.GetByIdAsync(request.AutoPartId);

            await _autopartRepository.DeleteAsync(autoPartToDelete);
        }
    }
}
