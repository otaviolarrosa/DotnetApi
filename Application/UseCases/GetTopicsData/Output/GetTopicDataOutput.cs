
using StreamNet.Topic;

namespace Application.UseCases.GetTopicsData.Output
{
    public class GetTopicsDataOutput
    {
        public GetTopicsDataOutput(TopicData topicData) => TopicData = topicData;

        public TopicData TopicData { get; set; }
    }
}
