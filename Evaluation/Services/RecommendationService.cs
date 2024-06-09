using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecommendationService(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork)
    {
        _recommendationRepository = recommendationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Recommendation>> ListAsync()
    {
        return await _recommendationRepository.ListAsync();
    }

    public async Task<Recommendation> GetByIdAsync(int id)
    {
        return await _recommendationRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Recommendation>> ListByDiagnosisIdAsync(int id)
    {
        return await _recommendationRepository.FindAllByDiagnosisIdAsync(id);
    }

    public async Task<IEnumerable<Recommendation>> ListDepressionRecommendationsByTestScoreAsync(int score)
    {
        return score switch
        {
            <= 4 => await _recommendationRepository.FindAllByDiagnosisIdAsync(1),
            <= 9 => await _recommendationRepository.FindAllByDiagnosisIdAsync(2),
            <= 14 => await _recommendationRepository.FindAllByDiagnosisIdAsync(3),
            <= 19 => await _recommendationRepository.FindAllByDiagnosisIdAsync(4),
            <= 27 => await _recommendationRepository.FindAllByDiagnosisIdAsync(5),
            _ => await _recommendationRepository.FindAllByDiagnosisIdAsync(10),
        };
    }

    public async Task<IEnumerable<Recommendation>> ListAnxietyRecommendationsByTestScoreAsync(int score)
    {
        return score switch
        {
            <= 7 => await _recommendationRepository.FindAllByDiagnosisIdAsync(6),
            <= 15 => await _recommendationRepository.FindAllByDiagnosisIdAsync(7),
            <= 25 => await _recommendationRepository.FindAllByDiagnosisIdAsync(8),
            <= 63 => await _recommendationRepository.FindAllByDiagnosisIdAsync(9),
            _ => await _recommendationRepository.FindAllByDiagnosisIdAsync(10),
        };
    }
}