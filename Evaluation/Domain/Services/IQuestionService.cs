using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;

namespace MindWell_EvaluationService.Evaluation.Domain.Services;

public interface IQuestionService
{
    Task<IEnumerable<Question>> ListAsync();
    Task<Question> GetByIdAsync(int id);
    Task<QuestionResponse> SaveAsync(Question question);
    Task<QuestionResponse> UpdateAsync(int id, Question question);
    Task<QuestionResponse> DeleteAsync(int id);
}