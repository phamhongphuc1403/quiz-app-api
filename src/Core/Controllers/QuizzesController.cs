using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Modules.Quiz.Dto;
using quiz_app_api.src.Core.Modules.Quiz.Service;
using quiz_app_api.src.Packages.HttpExceptions;

namespace quiz_app_api.src.Core.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizService quizService;
        public QuizzesController(AppDbContext context)
        {
            quizService = new QuizService(context);
        }

        [HttpPost("quizzes/take-quiz")]
        [Authorize]
        public async Task<IActionResult> TakeQuiz()
        {
            try
            {
                var idClaim = HttpContext.User.FindFirst("id")?.Value;

                return Ok(await quizService.TakeQuiz(Convert.ToInt32(idClaim)));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }

        [HttpPost("quizzes/{quizId}/questions/{questionId}/answer")]
        [Authorize]
        public async Task<IActionResult> ValidateAnswer(string quizId, int questionId, AnswerQuestionDto model)
        {
            try
            {
                var idClaim = HttpContext.User.FindFirst("id")?.Value;

                return Ok(await quizService.ValidateAnswer(quizId, questionId, Convert.ToInt32(idClaim), model));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }

        [HttpGet("users/me/results")]
        [Authorize]
        public IActionResult GetResults()
        {
            try
            {
                var idClaim = HttpContext.User.FindFirst("id")?.Value;

                return Ok(quizService.GetUserResults(Convert.ToInt32(idClaim)));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }

        [HttpGet("users/me/results/{quizId}")]
        [Authorize]
        public IActionResult GetResult(string quizId)
        {
            try
            {
                var idClaim = HttpContext.User.FindFirst("id")?.Value;

                return Ok(quizService.GetUserResult(Convert.ToInt32(idClaim), quizId));
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.statusCode, ex.response);
            }
        }
    }
}
