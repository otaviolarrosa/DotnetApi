using Application.UseCases.User.CreateUser;
using Events.User;
using Microsoft.Extensions.Logging;
using StreamNet.Consumers;
using Application.UseCases.User.CreateUser.Input;
using Application.UseCases.User.RequestCreateUser.Input;
using MongoDB.Driver;

namespace Consumers.User
{
    [ConsumerGroup("RequestCreateUserEventConsumer")]
    [TopicName("Events.User.RequestCreateUserEvent")]
    public class CreateUserEventConsumer : Consumer<RequestCreateUserEvent>
    {
        private readonly ICreateUserUseCase _useCase;
        private readonly ILogger<CreateUserEventConsumer> _logger;

        public CreateUserEventConsumer(ICreateUserUseCase useCase, ILogger<CreateUserEventConsumer> logger) : base(logger)
        {
            _useCase = useCase;
            _logger = logger;
        }

        public override async Task HandleAsync()
        {
            try
            {
                _logger.LogInformation("Received event {event} with values {@message}", nameof(RequestCreateUserEvent), Message);
                await _useCase.ExecuteAsync(new RequestCreateUserInput(Message.FirstName, Message.LastName, Message.Address));
                _logger.LogInformation("Ended event {event} with values {@message}", nameof(RequestCreateUserEvent), Message);
            }
            catch (MongoWriteException ex)
            {
                if(ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
                    _logger.LogError(ex,"Unique key detected for values: {input}", Message);
            }
        }
    }
}