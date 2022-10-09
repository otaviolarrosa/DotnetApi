using Application.UseCases.User.CreateUser.Input;
using Application.UseCases.User.RequestCreateUser.Input;

namespace Application.UseCases.User.RequestCreateUser
{
    public interface IRequestCreateUserUseCase
    {
        Task ExecuteAsync(RequestCreateUserInput input);
    }
}