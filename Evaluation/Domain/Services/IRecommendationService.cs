using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IRecommendationService
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task<Recommendation> GetByIdAsync(int id);
    Task<RecommendationResponse> SaveAsync(Recommendation recommendation);
    Task<RecommendationResponse> UpdateAsync(int id, Recommendation recommendation);
    Task<RecommendationResponse> DeleteAsync(int id);
}