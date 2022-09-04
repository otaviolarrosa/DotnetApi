using Application.UseCases.User.CreateUser.Input;

namespace Application.UseCases.User.RequestCreateUser
{
    public interface IRequestCreateUserUseCase
    {
        Task ExecuteAsync(RequestCreateUserInput input);
    }
}