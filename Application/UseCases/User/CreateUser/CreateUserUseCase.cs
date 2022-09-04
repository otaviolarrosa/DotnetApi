using Application.Infrastructure.Data.Repositories;
using Application.UseCases.User.CreateUser.Input;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User.CreateUser
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        private readonly ILogger<CreateUserUseCase> _logger;

        public CreateUserUseCase(IRepository<Domain.Entities.User> repository, ILogger<CreateUserUseCase> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task ExecuteAsync(RequestCreateUserInput input)
        {
            var entity = new Domain.Entities.User(input.FirstName, input.LastName, input.Address);
            _repository.Add(entity);
            _logger.LogInformation("Saved User {userId} in database", entity.Id);
            return;
        }
    }
}
