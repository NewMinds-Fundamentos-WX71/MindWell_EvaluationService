using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
    {
        _questionRepository = questionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Question>> ListAsync()
    {
        return await _questionRepository.ListAsync();
    }

    public async Task<Question> GetByIdAsync(int id)
    {
        return await _questionRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Question>> ListByTestIdAsync(int id)
    {
        return await _questionRepository.FindByTestIdAsync(id);
    }
}