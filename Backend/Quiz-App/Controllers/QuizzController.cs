using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_App.DTOs;
using Quiz_App.Exceptions;
using Quizz.Model;
using Quizz.Repository;
using Quizz.Service;
using System.Net;

namespace Quiz_App.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzController : ControllerBase
    {
        private readonly IQuestionService _questionServices;

        private readonly ILogger<QuizzController> _logger;

        public QuizzController(IQuestionService questionServices, ILogger<QuizzController> logger)
        {
            _questionServices = questionServices;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            
            _logger.LogInformation("Reading All Data");
            var questionsList = (await _questionServices.GetQuestions()).Select(q=>q.ToDTO()).ToList();
            return Ok(questionsList);
  
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestionById(int Id) 
        {
            _logger.LogInformation("'Fetching Product with ID from the database'");
            var question = await _questionServices.GetQuestionById(Id);


            if (question == null)
            {
                return NotFound();
                
            }
                return Ok(question.ToDTO());
        }


        [HttpPost]
        public async Task<ActionResult> AddQuestion(QuestionDto question)
        {
            _logger.LogInformation("'Post method is initailed'");         
            await _questionServices.AddQuestion(question.ToModel());
            return Ok(question);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionDto questionDto)
        {
            _logger.LogInformation("'Update method is initailed'");
            var item = _questionServices.GetQuestionById(id);
            if (item == null)
            {
                return NotFound();
            }
            await _questionServices.UpdateQuestion(id, questionDto.ToModel());
            return NoContent();
        }

       
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteQuestion(int Id)
        {
            _logger.LogInformation("'Delete method is initailed'");
            await _questionServices.DeleteQuestion(Id);
            return NoContent();
        }


        [HttpGet("page")]
        public async Task<List<QuestionDto>> GetByPagination([FromQuery]Pagination pagination)
        {
            _logger.LogInformation("'paging method is initailed'");
            return (await _questionServices.GetByPagination(pagination)).Select(q=>q.ToDTO()).ToList();
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> Search(string name)
        {
            _logger.LogInformation("'Search method is initailed'");
            try
            {
               var result = await _questionServices.Search(name);
                if (result.Any())
                {
                    return Ok(result.Select(q => q.ToDTO()));
                }
                return NotFound();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpGet("sorting")]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> Sorting()
        {
            _logger.LogInformation("'Sorting method is initailed'");
            try
            {
                var result = await _questionServices.Sorting();
                if (result.Any())
                {
                    return Ok(result.Select(q=>q.ToDTO()));
                }
                return NotFound();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("answer")]
        public async Task<AnswerDto> GetAnswer(int id)
        {
            var result = (await _questionServices.GetQuestionById(id)).ToAnswerDTO();
            return result;
        }

    }
}
