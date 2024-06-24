using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Evaluation.Resources.GET;
using MindWell_EvaluationService.Evaluation.Resources.POST;
using MindWell_EvaluationService.Evaluation.Resources.UPDATE;
using MindWell_EvaluationService.Shared.Extensions;

namespace MindWell_EvaluationService.Evaluation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AssessmentsController : ControllerBase
{
    private readonly IAssessmentService _assessmentService;
    private readonly IMapper _mapper;

    public AssessmentsController(IAssessmentService assessmentService, IMapper mapper)
    {
        _assessmentService = assessmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AssessmentResource>> GetAllAsync()
    {
        var assessments = await _assessmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Assessment>, IEnumerable<AssessmentResource>>(assessments);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<AssessmentResource> GetAssessmentbyId(int id)
    {
        var assessment = await _assessmentService.GetByIdAsync(id);
        var resource = _mapper.Map<Assessment, AssessmentResource>(assessment);
        
        return resource;
    }
    
    [HttpGet("patientId/{id}")]
    public async Task<IEnumerable<AssessmentResource>> GetAllByPatientId(int id)
    {
        var assessments = await _assessmentService.ListByPatientIdAsync(id);
        var resources = _mapper.Map<IEnumerable<Assessment>, IEnumerable<AssessmentResource>>(assessments);
        
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAssessmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var assessment = _mapper.Map<SaveAssessmentResource, Assessment>(resource);
        var result = await _assessmentService.SaveAsync(assessment);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentResource = _mapper.Map<Assessment, AssessmentResource>(result.Resource);

        return Ok(assessmentResource);
    }
    
    [HttpPost("calc-anxiety")]
    public async Task<IActionResult> CalculateAnxietyDiagnosis([FromBody] CalculateAssessmentDiagnosis resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var result = await _assessmentService.CalculateAnxietyDiagnosis(resource.Assessment_Id, resource.Answers);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resourceResource = _mapper.Map<Assessment, AssessmentResource>(result.Resource);
        
        return Ok(resourceResource);
    }

    [HttpPost("calc-depression")]
    public async Task<IActionResult> CalculateDepressionDiagnosis([FromBody] CalculateAssessmentDiagnosis resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var result = await _assessmentService.CalculateDepressionDiagnosis(resource.Assessment_Id, resource.Answers);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resourceResource = _mapper.Map<Assessment, AssessmentResource>(result.Resource);
        
        return Ok(resourceResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateAssessmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var assessment = _mapper.Map<UpdateAssessmentResource, Assessment>(resource);
        var result = await _assessmentService.UpdateAsync(id, assessment);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentResource = _mapper.Map<Assessment, AssessmentResource>(result.Resource);

        return Ok(assessmentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _assessmentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var assessmentResource = _mapper.Map<Assessment, AssessmentResource>(result.Resource);

        return Ok(assessmentResource);
    }
}