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
    
    [HttpGet("test/{id:int}")]
    public async Task<IEnumerable<QuestionResource>> GetAllByTestId(int id)
    {
        var question = await _questionService.ListByTestIdAsync(id);
        var resource = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionResource>>(question);
        
        return resource;
    }
}