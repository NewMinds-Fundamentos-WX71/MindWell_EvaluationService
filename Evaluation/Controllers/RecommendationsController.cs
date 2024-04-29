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
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;
    private readonly IMapper _mapper;

    public RecommendationsController(IRecommendationService recommendationService, IMapper mapper)
    {
        _recommendationService = recommendationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RecommendationResource>> GetAllAsync()
    {
        var recommendations = await _recommendationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Recommendation>, IEnumerable<RecommendationResource>>(recommendations);
        
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<RecommendationResource> GetRecommendationbyId(int id)
    {
        var recommendation = await _recommendationService.GetByIdAsync(id);
        var resource = _mapper.Map<Recommendation, RecommendationResource>(recommendation);
        
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRecommendationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recommendation = _mapper.Map<SaveRecommendationResource, Recommendation>(resource);
        var result = await _recommendationService.SaveAsync(recommendation);

        if (!result.Success)
            return BadRequest(result.Message);

        var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(result.Resource);

        return Ok(recommendationResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecommendationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recommendation = _mapper.Map<SaveRecommendationResource, Recommendation>(resource);
        var result = await _recommendationService.UpdateAsync(id, recommendation);

        if (!result.Success)
            return BadRequest(result.Message);

        var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(result.Resource);

        return Ok(recommendationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _recommendationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var recommendationResource = _mapper.Map<Recommendation, RecommendationResource>(result.Resource);

        return Ok(recommendationResource);
    }
}