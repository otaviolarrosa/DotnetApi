using Application.UseCases.CreateTopic.Input;
using StreamNet.Topic;

namespace Application.UseCases.CreateTopic
{
    public class CreateTopicUseCase : ICreateTopicUseCase
    {
        private readonly ITopicManagement _topicManagement;

        public CreateTopicUseCase(ITopicManagement topicManagement)
        {
            _topicManagement = topicManagement;
        }

        public async Task ExecuteAsync(CreateTopicInput input)
        {
            await _topicManagement.CreateTopicAsync(input.TopicName, input.ReplicationFactor, input.NumberOfPartitions);
        }
    }
}
