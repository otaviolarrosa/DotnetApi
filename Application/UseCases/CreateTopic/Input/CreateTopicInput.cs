namespace Application.UseCases.CreateTopic.Input
{
    public class CreateTopicInput
    {
        public string TopicName { get; set; }
        public short? ReplicationFactor { get; set; }
        public int? NumberOfPartitions { get; set; }
    }
}
