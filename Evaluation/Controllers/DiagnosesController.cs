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
public class DiagnosesController : ControllerBase
{
    private readonly IDiagnoseService _diagnoseService;
    private readonly IMapper _mapper;

    public DiagnosesController(IDiagnoseService diagnoseService, IMapper mapper)
    {
        _diagnoseService = diagnoseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DiagnoseResource>> GetAllAsync()
    {
        var diagnoses = await _diagnoseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Diagnose>, IEnumerable<DiagnoseResource>>(diagnoses);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<DiagnoseResource> GetDiagnosebyId(int id)
    {
        var diagnose = await _diagnoseService.GetByIdAsync(id);
        var resource = _mapper.Map<Diagnose, DiagnoseResource>(diagnose);
        
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDiagnoseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var diagnose = _mapper.Map<SaveDiagnoseResource, Diagnose>(resource);
        var result = await _diagnoseService.SaveAsync(diagnose);

        if (!result.Success)
            return BadRequest(result.Message);

        var diagnoseResource = _mapper.Map<Diagnose, DiagnoseResource>(result.Resource);

        return Ok(diagnoseResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDiagnoseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var diagnose = _mapper.Map<SaveDiagnoseResource, Diagnose>(resource);
        var result = await _diagnoseService.UpdateAsync(id, diagnose);

        if (!result.Success)
            return BadRequest(result.Message);

        var diagnoseResource = _mapper.Map<Diagnose, DiagnoseResource>(result.Resource);

        return Ok(diagnoseResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _diagnoseService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var diagnoseResource = _mapper.Map<Diagnose, DiagnoseResource>(result.Resource);

        return Ok(diagnoseResource);
    }
}