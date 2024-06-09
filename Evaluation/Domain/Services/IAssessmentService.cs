using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IAssessmentService
{
    Task<IEnumerable<Assessment>> ListAsync();
    Task<Assessment> GetByIdAsync(int id);
    Task<AssessmentResponse> SaveAsync(Assessment assessment);
    Task<AssessmentResponse> CalculateAnxietyDiagnosis(int id, IEnumerable<int> answers);
    Task<AssessmentResponse> CalculateDepressionDiagnosis(int id, IEnumerable<int> answers);
    Task<AssessmentResponse> UpdateAsync(int id, Assessment assessment);
    Task<AssessmentResponse> DeleteAsync(int id);
}