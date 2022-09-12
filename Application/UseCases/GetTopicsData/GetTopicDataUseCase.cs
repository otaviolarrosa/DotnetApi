using Application.UseCases.GetTopicsData.Output;
using StreamNet.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.GetTopicsData
{
    public class GetTopicsDataUseCase : IGetTopicsDataUseCase
    {
        private readonly ITopicManagement _topicManagement;

        public GetTopicsDataUseCase(ITopicManagement topicManagement)
        {
            _topicManagement = topicManagement;
        }

        public async Task<GetTopicsDataOutput> ExecuteAsync()
        {
            var result = _topicManagement.GetTopicsData();
            return new GetTopicsDataOutput(result);
        }
    }
}
