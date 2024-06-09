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
public class TreatmentsController : ControllerBase
{
    private readonly ITreatmentService _treatmentService;
    private readonly IMapper _mapper;

    public TreatmentsController(ITreatmentService treatmentService, IMapper mapper)
    {
        _treatmentService = treatmentService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TreatmentResource>> GetAllAsync()
    {
        var treatments = await _treatmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Treatment>, IEnumerable<TreatmentResource>>(treatments);
        
        return resources;
    }
    
    [HttpGet("{id:int}")]
    public async Task<TreatmentResource> GetTreatmentbyId(int id)
    {
        var treatment = await _treatmentService.GetByIdAsync(id);
        var resource = _mapper.Map<Treatment, TreatmentResource>(treatment);
        
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTreatmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var treatment = _mapper.Map<SaveTreatmentResource, Treatment>(resource);
        var result = await _treatmentService.SaveAsync(treatment);

        if (!result.Success)
            return BadRequest(result.Message);

        var treatmentResource = _mapper.Map<Treatment, TreatmentResource>(result.Resource);

        return Ok(treatmentResource);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTreatmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var treatment = _mapper.Map<SaveTreatmentResource, Treatment>(resource);
        var result = await _treatmentService.UpdateAsync(id, treatment);

        if (!result.Success)
            return BadRequest(result.Message);

        var treatmentResource = _mapper.Map<Treatment, TreatmentResource>(result.Resource);

        return Ok(treatmentResource);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _treatmentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var treatmentResource = _mapper.Map<Treatment, TreatmentResource>(result.Resource);

        return Ok(treatmentResource);
    }
}