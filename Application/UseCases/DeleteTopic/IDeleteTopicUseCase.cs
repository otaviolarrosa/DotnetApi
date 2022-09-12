namespace Application.UseCases.DeleteTopic
{
    public interface IDeleteTopicUseCase
    {
        void ExecuteAsync(string topicName);
    }
}
