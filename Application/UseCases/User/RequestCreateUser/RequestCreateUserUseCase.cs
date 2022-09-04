using Application.UseCases.User.CreateUser.Input;
using Events.User;
using Microsoft.Extensions.Logging;
using StreamNet.Producers;

namespace Application.UseCases.User.RequestCreateUser
{
    public class RequestCreateUserUseCase : IRequestCreateUserUseCase
    {
        private readonly IPublisher _publisher;
        private readonly ILogger<RequestCreateUserUseCase> _logger;

        public RequestCreateUserUseCase(IPublisher publisher, ILogger<RequestCreateUserUseCase> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        public async Task ExecuteAsync(RequestCreateUserInput input)
        {
            _logger.LogInformation("{useCase} - Starting method with values - {@input}", nameof(RequestCreateUser), input);
            await _publisher.ProduceAsync(new RequestCreateUserEvent(input.FirstName, input.LastName, input.Address));
        }
    }
}
