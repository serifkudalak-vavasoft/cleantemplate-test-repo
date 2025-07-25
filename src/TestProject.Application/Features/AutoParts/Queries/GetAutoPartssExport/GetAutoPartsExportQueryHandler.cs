using AutoMapper;
using TestProject.Application.Contracts.Infrastructure;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;
using MediatR;

namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport
{
    public class GetAutoPartsExportQueryHandler : IRequestHandler<GetAutoPartExportQuery, AutoPartExportFileVm>
    {
        private readonly IAsyncRepository<AutoPart> _autopartRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetAutoPartsExportQueryHandler(IMapper mapper, IAsyncRepository<AutoPart> autopartRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _autopartRepository = autopartRepository;
            _csvExporter = csvExporter;
        }

        public async Task<AutoPartExportFileVm> Handle(GetAutoPartExportQuery request, CancellationToken cancellationToken)
        {
            var allAutoParts = _mapper.Map<List<AutoPartExportDto>>((await _autopartRepository.ListAllAsync()));

            var fileData = _csvExporter.ExportAutoPartsToCsv(allAutoParts);

            var autopartExportFileDto = new AutoPartExportFileVm() { ContentType = "text/csv", Data = fileData, AutoPartExportFileName = $"{Guid.NewGuid()}.csv" };

            return autopartExportFileDto;
        }
    }
}
