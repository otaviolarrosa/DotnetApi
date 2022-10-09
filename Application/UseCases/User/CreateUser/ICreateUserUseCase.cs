using Application.UseCases.User.CreateUser.Input;
using Application.UseCases.User.RequestCreateUser.Input;

namespace Application.UseCases.User.CreateUser
{
    public interface ICreateUserUseCase
    {
        Task ExecuteAsync(RequestCreateUserInput input);
    }
}