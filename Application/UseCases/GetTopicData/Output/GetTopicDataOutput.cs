using StreamNet.Topic;

namespace Application.UseCases.GetTopicData.Output
{
    public class GetTopicDataOutput
    {
        public GetTopicDataOutput(TopicData topicData) => TopicData = topicData;

        public TopicData TopicData { get; set; }
    }
}
