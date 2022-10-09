using Application.UseCases.User.CreateUser.Input;
using Application.UseCases.User.RequestCreateUser;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.UseCases.User.RequestCreateUser.Input;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRequestCreateUserUseCase _requestCreateUserUseCase;
        private readonly ILogger<UserController> _logger;

        public UserController(IRequestCreateUserUseCase requestCreateUserUseCase, ILogger<UserController> logger)
        {
            _requestCreateUserUseCase = requestCreateUserUseCase;
            _logger = logger;
        }

        [HttpPost]
        [Route("/user")]
        public async Task<IActionResult> CreateUser([FromBody]RequestCreateUserInput userInput)
        {
            try
            {
                _logger.LogInformation("Starting request {method} with params {@input}", nameof(CreateUser), userInput);
                await _requestCreateUserUseCase.ExecuteAsync(userInput);
                _logger.LogInformation("Ended request {method} with params {@input}", nameof(CreateUser), userInput);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "A unexpected error occurred in {method} with params {@input}", nameof(CreateUser), userInput);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A unexpected error occurred in CreateUser.");
            }
        }
    }
}

