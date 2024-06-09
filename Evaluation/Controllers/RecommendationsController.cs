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
    
    [HttpGet("diagnosis/{id:int}")]
    public async Task<IEnumerable<RecommendationResource>> GetAllRecommendationsByDiagnosisId(int id)
    {
        var recommendation = await _recommendationService.ListByDiagnosisIdAsync(id);
        var resource = _mapper.Map<IEnumerable<Recommendation>, IEnumerable<RecommendationResource>>(recommendation);
        
        return resource;
    }
    
    [HttpGet("depression-test/{score:int}")]
    public async Task<IEnumerable<RecommendationResource>> GetAllDepressionRecommendationsByTestScore(int score)
    {
        var recommendation = await _recommendationService.ListDepressionRecommendationsByTestScoreAsync(score);
        var resource = _mapper.Map<IEnumerable<Recommendation>, IEnumerable<RecommendationResource>>(recommendation);
        
        return resource;
    }
    
    [HttpGet("anxiety-test/{score:int}")]
    public async Task<IEnumerable<RecommendationResource>> GetAllAnxietyRecommendationsByTestScore(int score)
    {
        var recommendation = await _recommendationService.ListAnxietyRecommendationsByTestScoreAsync(score);
        var resource = _mapper.Map<IEnumerable<Recommendation>, IEnumerable<RecommendationResource>>(recommendation);
        
        return resource;
    }
}