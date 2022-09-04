using Application.UseCases.User.CreateUser.Input;

namespace Application.UseCases.User.CreateUser
{
    public interface ICreateUserUseCase
    {
        Task ExecuteAsync(RequestCreateUserInput input);
    }
}