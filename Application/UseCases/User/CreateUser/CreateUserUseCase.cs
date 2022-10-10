using Application.Infrastructure.Data.MongoDb.Repositories;
using Application.Infrastructure.Data.Postgres.Repositories;
using Application.UseCases.User.CreateUser.Input;
using Application.UseCases.User.RequestCreateUser.Input;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IMongoRepository<Domain.Entities.User> _repository;
        private readonly ILogger<CreateUserUseCase> _logger;

        public CreateUserUseCase(IMongoRepository<Domain.Entities.User> repository, ILogger<CreateUserUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task ExecuteAsync(RequestCreateUserInput input)
        {
            var entity = new Domain.Entities.User(input.FirstName, input.LastName, input.Address);
            await _repository.InsertOneAsync(entity);
            _logger.LogInformation("Saved User {userId} in database", entity.Id);
        }
    }
}
