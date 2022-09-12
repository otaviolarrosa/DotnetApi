using Application.UseCases.CreateTopic.Input;

namespace Application.UseCases.CreateTopic
{
    public interface ICreateTopicUseCase
    {
        Task ExecuteAsync(CreateTopicInput input);
    }
}
