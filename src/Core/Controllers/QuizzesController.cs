using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Modules.Quiz.Service;
using quiz_app_api.src.Packages.HttpExceptions;

namespace quiz_app_api.src.Core.Controllers
{
    [Route("api/quizzes")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizService quizService;
        public QuizzesController(AppDbContext context)
        {
            quizService = new QuizService(context);
        }

        [HttpPost("take-quiz")]
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
    }
}
