using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Evaluation.Resources.GET;
using MindWell_EvaluationService.Evaluation.Resources.POST;
using MindWell_EvaluationService.Shared.Extensions;

namespace MindWell_EvaluationService.Evaluation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly IMapper _mapper;

    public QuestionsController(IQuestionService questionService, IMapper mapper)
    {
        _questionService = questionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<QuestionResource>> GetAllAsync()
    {
        var questions = await _questionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(questions);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<QuestionResource> GetQuestionbyId(int id)
    {
        var question = await _questionService.GetByIdAsync(id);
        var resource = _mapper.Map<Question, QuestionResource>(question);
        
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var question = _mapper.Map<SaveQuestionResource, Question>(resource);
        var result = await _questionService.SaveAsync(question);

        if (!result.Success)
            return BadRequest(result.Message);

        var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);

        return Ok(questionResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var question = _mapper.Map<SaveQuestionResource, Question>(resource);
        var result = await _questionService.UpdateAsync(id, question);

        if (!result.Success)
            return BadRequest(result.Message);

        var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);

        return Ok(questionResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _questionService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var questionResource = _mapper.Map<Question, QuestionResource>(result.Resource);

        return Ok(questionResource);
    }
}