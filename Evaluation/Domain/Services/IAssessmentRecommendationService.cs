using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IAssessmentRecommendationService
{ 
    Task<IEnumerable<AssessmentRecommendation>> ListAllAsync();
    Task<IEnumerable<AssessmentRecommendation>> ListAllByAssessmentIdAsync(int id);
    Task<IEnumerable<AssessmentRecommendation>> ListAllByRecommendationIdAsync(int id);
    Task<AssessmentRecommendation> ListByIdAsync(int id);
    Task<AssessmentRecommendationResponse> SaveAsync(AssessmentRecommendation assessmentRecommendation);
}