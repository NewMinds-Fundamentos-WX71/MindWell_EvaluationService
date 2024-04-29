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
public class AssessmentQuestionsController : ControllerBase
{
    private readonly IAssessmentQuestionService _assessmentQuestionService;
    private readonly IMapper _mapper;

    public AssessmentQuestionsController(IAssessmentQuestionService assessmentQuestionService, IMapper mapper)
    {
        _assessmentQuestionService = assessmentQuestionService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AssessmentQuestionResource>> GetAllAsync()
    {
        var assessmentQuestions = await _assessmentQuestionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<AssessmentQuestion>, IEnumerable<AssessmentQuestionResource>>(assessmentQuestions);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<AssessmentQuestionResource> GetAssessmentQuestionbyId(int id)
    {
        var assessmentQuestion = await _assessmentQuestionService.GetByIdAsync(id);
        var resource = _mapper.Map<AssessmentQuestion, AssessmentQuestionResource>(assessmentQuestion);
        
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAssessmentQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var assessmentQuestion = _mapper.Map<SaveAssessmentQuestionResource, AssessmentQuestion>(resource);
        var result = await _assessmentQuestionService.SaveAsync(assessmentQuestion);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentQuestionResource = _mapper.Map<AssessmentQuestion, AssessmentQuestionResource>(result.Resource);

        return Ok(assessmentQuestionResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAssessmentQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var assessmentQuestion = _mapper.Map<SaveAssessmentQuestionResource, AssessmentQuestion>(resource);
        var result = await _assessmentQuestionService.UpdateAsync(id, assessmentQuestion);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentQuestionResource = _mapper.Map<AssessmentQuestion, AssessmentQuestionResource>(result.Resource);

        return Ok(assessmentQuestionResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _assessmentQuestionService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentQuestionResource = _mapper.Map<AssessmentQuestion, AssessmentQuestionResource>(result.Resource);

        return Ok(assessmentQuestionResource);
    }
}