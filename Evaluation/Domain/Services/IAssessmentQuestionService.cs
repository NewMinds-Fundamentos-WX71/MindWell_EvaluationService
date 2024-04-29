using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IAssessmentQuestionService
{
    Task<IEnumerable<AssessmentQuestion>> ListAsync();
    Task<AssessmentQuestion> GetByIdAsync(int id);
    Task<AssessmentQuestionResponse> SaveAsync(AssessmentQuestion assessmentQuestion);
    Task<AssessmentQuestionResponse> UpdateAsync(int id, AssessmentQuestion assessmentQuestion);
    Task<AssessmentQuestionResponse> DeleteAsync(int id);
}