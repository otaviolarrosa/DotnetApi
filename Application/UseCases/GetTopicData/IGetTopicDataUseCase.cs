using Application.UseCases.GetTopicData.Output;

namespace Application.UseCases.GetTopicData
{
    public interface IGetTopicDataUseCase
    {
        public Task<GetTopicDataOutput> ExecuteAsync(string topicName);
    }
}
