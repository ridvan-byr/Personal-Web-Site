using Microsoft.AspNetCore.Mvc;
using PersonalWebSite.Business.Interfaces;
using PersonalWebSite.Core.Models;

namespace PersonalWebSite.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var answers = await _answerService.GetAllAsync();
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var answer = await _answerService.GetByIdAsync(id);
            if (answer == null)
                return NotFound();
            return Ok(answer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Answer answer)
        {
            await _answerService.AddAsync(answer);
            return CreatedAtAction(nameof(GetById), new { id = answer.Id }, answer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Answer answer)
        {
            if (id != answer.Id)
                return BadRequest();

            await _answerService.UpdateAsync(answer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _answerService.GetByIdAsync(id);
            if (answer == null)
                return NotFound();

            await _answerService.DeleteAsync(answer);
            return NoContent();
        }
    }
} 