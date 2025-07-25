using AutoMapper;
using TestProject.Application.Contracts.Infrastructure;
using TestProject.Application.Contracts.Persistence;
using TestProject.Application.Models.Mail;
using TestProject.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TestProject.Application.Features.AutoParts.Commands.CreateAutoPart
{
    public class CreateAutoPartCommandHandler : IRequestHandler<CreateAutoPartCommand, Guid>
    {
        private readonly IAutoPartRepository _autopartRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateAutoPartCommandHandler> _logger;


        public CreateAutoPartCommandHandler(IMapper mapper, IAutoPartRepository autopartRepository, IEmailService emailService, ILogger<CreateAutoPartCommandHandler> logger)
        {
            _mapper = mapper;
            _autopartRepository = autopartRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateAutoPartCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAutoPartCommandValidator(_autopartRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var autoPart = _mapper.Map<AutoPart>(request);


            autoPart = await _autopartRepository.AddAsync(autoPart);


            var email = new Email() { To = "test@vavasoft.com", Body = $"A new auto part was created: {request}", Subject = "A new autopart was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about autopart {@autoPart.AutoPartId} failed due to an error with the mail service: {ex.Message}");
            }

            return @autoPart.AutoPartId;
        }
    }
}
