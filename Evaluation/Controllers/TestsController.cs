using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Evaluation.Resources.GET;

namespace MindWell_EvaluationService.Evaluation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TestsController : ControllerBase
{
    private readonly ITestService _testService;
    private readonly IMapper _mapper;

    public TestsController(ITestService testService, IMapper mapper)
    {
        _testService = testService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TestResource>> GetAllAsync()
    {
        var tests = await _testService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Test>, IEnumerable<TestResource>>(tests);
        
        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<TestResource> GetTestbyId(int id)
    {
        var test = await _testService.GetByIdAsync(id);
        var resource = _mapper.Map<Test, TestResource>(test);
        
        return resource;
    }
    
}