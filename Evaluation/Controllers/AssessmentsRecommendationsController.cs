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
public class AssessmentsRecommendationsController : ControllerBase
{
    private readonly IAssessmentRecommendationService _assessmentRecommendationService;
    private readonly IMapper _mapper;

    public AssessmentsRecommendationsController(IAssessmentRecommendationService assessmentRecommendationService, IMapper mapper)
    {
        _assessmentRecommendationService = assessmentRecommendationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AssessmentRecommendationResource>> GetAllAsync()
    {
        var assessments = await _assessmentRecommendationService.ListAllAsync();
        var resources = _mapper.Map<IEnumerable<AssessmentRecommendation>, IEnumerable<AssessmentRecommendationResource>>(assessments);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<AssessmentRecommendationResource> GetByIdAsync(int id)
    {
        var assessment = await _assessmentRecommendationService.ListByIdAsync(id);
        var resource = _mapper.Map<AssessmentRecommendation, AssessmentRecommendationResource>(assessment);
        
        return resource;
    }
    
    [HttpGet("assessment/{id:int}")]
    public async Task<IEnumerable<AssessmentRecommendationResource>> GetAllByAssessmentIdAsync(int id)
    {
        var assessments = await _assessmentRecommendationService.ListAllByAssessmentIdAsync(id);
        var resources = _mapper.Map<IEnumerable<AssessmentRecommendation>, IEnumerable<AssessmentRecommendationResource>>(assessments);
        
        return resources;
    }
    
    [HttpGet("recommendation/{id:int}")]
    public async Task<IEnumerable<AssessmentRecommendationResource>> GetAllByRecommendationIdAsync(int id)
    {
        var assessments = await _assessmentRecommendationService.ListAllByRecommendationIdAsync(id);
        var resources = _mapper.Map<IEnumerable<AssessmentRecommendation>, IEnumerable<AssessmentRecommendationResource>>(assessments);
        
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAssessmentRecommendationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var assessment = _mapper.Map<SaveAssessmentRecommendationResource, AssessmentRecommendation>(resource);
        var result = await _assessmentRecommendationService.SaveAsync(assessment);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentResource = _mapper.Map<AssessmentRecommendation, AssessmentRecommendationResource>(result.Resource);

        return Ok(assessmentResource);
    }
}