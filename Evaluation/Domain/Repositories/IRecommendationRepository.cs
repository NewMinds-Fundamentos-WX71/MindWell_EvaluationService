using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IRecommendationRepository
{
    Task<IEnumerable<Recommendation>> ListAsync();
    Task<Recommendation> FindByIdAsync(int id);
    Task AddAsync(Recommendation recommendation);
    void Update(Recommendation recommendation);
    void Remove(Recommendation recommendation);
}