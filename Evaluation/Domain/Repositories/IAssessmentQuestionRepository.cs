using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Repositories;

public interface IAssessmentQuestionRepository
{
    Task<IEnumerable<AssessmentQuestion>> ListAsync();
    Task<AssessmentQuestion> FindByIdAsync(int id);
    Task AddAsync(AssessmentQuestion assessmentQuestion);
    void Update(AssessmentQuestion assessmentQuestion);
    void Remove(AssessmentQuestion assessmentQuestion);
}