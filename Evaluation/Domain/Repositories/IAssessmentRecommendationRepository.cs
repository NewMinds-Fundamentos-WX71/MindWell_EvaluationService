using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IAssessmentRecommendationRepository
{  
    Task<IEnumerable<AssessmentRecommendation>> FindAllAsync();
    Task<IEnumerable<AssessmentRecommendation>> FindAllByAssessmentIdAsync(int id);
    Task<IEnumerable<AssessmentRecommendation>> FindAllByRecommendationIdAsync(int id);
    Task<AssessmentRecommendation> FindByIdAsync(int id);
    Task AddAsync(AssessmentRecommendation assessmentRecommendation);
}