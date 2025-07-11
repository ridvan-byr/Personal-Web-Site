using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalWebSite.Business.Interfaces;
using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;
        private readonly UserManager<User> _userManager;

        public AnswerController(
            IAnswerService answerService, 
            IQuestionService questionService,
            UserManager<User> userManager)
        {
            _answerService = answerService;
            _questionService = questionService;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int questionId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return BadRequest("Cevap içeriği boş olamaz.");
            }

            var question = await _questionService.GetQuestionByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Unauthorized();
            }

            var answer = new Answer
            {
                Content = content,
                QuestionId = questionId,
                UserId = currentUser.Id
            };

            await _answerService.CreateAnswerAsync(answer);
            return RedirectToAction("Details", "Question", new { id = questionId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            await _answerService.DeleteAnswerAsync(id);
            return RedirectToAction("Details", "Question", new { id = answer.QuestionId });
        }
    }
} 