using Application.UseCases.CreateTopic;
using Application.UseCases.CreateTopic.Input;
using Application.UseCases.DeleteTopic;
using Application.UseCases.GetTopicData;
using Application.UseCases.GetTopicsData;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ILogger<TopicController> _logger;
        private readonly ICreateTopicUseCase _createTopicUseCase;
        private readonly IGetTopicDataUseCase _getTopicDataUseCase;
        private readonly IGetTopicsDataUseCase _getTopicsDataUseCase;
        private readonly IDeleteTopicUseCase _deleteTopicUseCase;

        public TopicController(ILogger<TopicController> logger, 
            ICreateTopicUseCase createTopicUseCase, 
            IGetTopicDataUseCase getTopicDataUseCase, 
            IGetTopicsDataUseCase getTopicsDataUseCase, 
            IDeleteTopicUseCase deleteTopicUseCase)
        {
            _logger = logger;
            _createTopicUseCase = createTopicUseCase;
            _getTopicDataUseCase = getTopicDataUseCase;
            _getTopicsDataUseCase = getTopicsDataUseCase;
            _deleteTopicUseCase = deleteTopicUseCase;
        }


        [HttpPost]
        [Route("/topic")]
        public async Task<IActionResult> CreateTopic([FromBody] CreateTopicInput createTopicInput)
        {
            try
            {
                _logger.LogInformation("Starting request {method} with params {@input}", nameof(CreateTopic), createTopicInput);
                await _createTopicUseCase.ExecuteAsync(createTopicInput);
                _logger.LogInformation("Ended request {method} with params {@input}", nameof(CreateTopic), createTopicInput);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A unexpected error occurred in {method} with params {@input}", nameof(CreateTopic), createTopicInput);
                return StatusCode((int)HttpStatusCode.InternalServerError, $"A unexpected error occurred in {nameof(CreateTopic)}.");
            }
        }

        [HttpGet]
        [Route("/topic/{topicName}")]
        public async Task<IActionResult> GetTopicData([FromRoute] string topicName)
        {
            try
            {
                _logger.LogInformation("Starting request {method} with params {@input}", nameof(GetTopicData), topicName);
                var result = await _getTopicDataUseCase.ExecuteAsync(topicName);
                _logger.LogInformation("Ended request {method} with params {@input}", nameof(GetTopicData), topicName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A unexpected error occurred in {method} with params {@input}", nameof(CreateTopic), topicName);
                return StatusCode((int)HttpStatusCode.InternalServerError, $"A unexpected error occurred in {nameof(GetTopicData)}.");
            }
        }

        [HttpGet]
        [Route("/topics/")]
        public async Task<IActionResult> GetTopicsData()
        {
            try
            {
                _logger.LogInformation("Starting request {method}", nameof(GetTopicData));
                var result = await _getTopicsDataUseCase.ExecuteAsync();
                _logger.LogInformation("Ended request {method}", nameof(GetTopicData));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A unexpected error occurred in {method}", nameof(CreateTopic));
                return StatusCode((int)HttpStatusCode.InternalServerError, $"A unexpected error occurred in {nameof(GetTopicData)}.");
            }
        }

        [HttpDelete]
        [Route("/topic/{topicName}")]
        public IActionResult DeleteTopic([FromRoute] string topicName)
        {
            try
            {
                _logger.LogInformation("Starting request {method} with params {@input}", nameof(DeleteTopic), topicName);
                _deleteTopicUseCase.ExecuteAsync(topicName);
                _logger.LogInformation("Ended request {method} with params {@input}", nameof(DeleteTopic), topicName);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A unexpected error occurred in {method} with params {@input}", nameof(CreateTopic), topicName);
                return StatusCode((int)HttpStatusCode.InternalServerError, $"A unexpected error occurred in {nameof(GetTopicData)}.");
            }
        }
    }
}
