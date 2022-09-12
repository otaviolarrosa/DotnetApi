using Application.UseCases.GetTopicData.Output;
using StreamNet.Producers;
using StreamNet.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GetTopicData
{
    public class GetTopicDataUseCase : IGetTopicDataUseCase
    {
        private readonly ITopicManagement _topicManagement;

        public GetTopicDataUseCase(ITopicManagement topicManagement)
        {
            _topicManagement = topicManagement;
        }

        public async Task<GetTopicDataOutput> ExecuteAsync(string topicName)
        {
            var result = _topicManagement.GetTopicData(topicName);
            return new GetTopicDataOutput(result);
        }
    }
}
