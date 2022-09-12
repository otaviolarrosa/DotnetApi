using StreamNet.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteTopic
{
    public class DeleteTopicUseCase : IDeleteTopicUseCase
    {
        private readonly ITopicManagement _topicManagement;

        public DeleteTopicUseCase(ITopicManagement topicManagement) => _topicManagement = topicManagement;

        public void ExecuteAsync(string topicName) => _topicManagement.DeleteTopicAsync(topicName);
    }
}
