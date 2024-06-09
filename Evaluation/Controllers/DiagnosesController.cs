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
    public async Task<IEnumerable<DiagnosisResource>> GetAllAsync()
    {
        var diagnoses = await _diagnoseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Diagnosis>, IEnumerable<DiagnosisResource>>(diagnoses);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<DiagnosisResource> GetDiagnosisbyId(int id)
    {
        var diagnose = await _diagnoseService.GetByIdAsync(id);
        var resource = _mapper.Map<Diagnosis, DiagnosisResource>(diagnose);
        
        return resource;
    }
}