using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IRecommendationService
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task<Recommendation> GetByIdAsync(int id);
    Task<IEnumerable<Recommendation>> ListByDiagnosisIdAsync(int id);
    Task<IEnumerable<Recommendation>> ListDepressionRecommendationsByTestScoreAsync(int score);
    Task<IEnumerable<Recommendation>> ListAnxietyRecommendationsByTestScoreAsync(int score);
}