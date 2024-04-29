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

    public async Task<QuestionResponse> SaveAsync(Question question)
    {
        try
        {
            await _questionRepository.AddAsync(question);
            await _unitOfWork.CompleteAsync();
            return new QuestionResponse(question);
        }
        catch (Exception e)
        {
            return new QuestionResponse($"An error occurred while saving the question: {e.Message}");
        }
    }

    public async Task<QuestionResponse> UpdateAsync(int id, Question question)
    {
        try
        {
            var existingQuestion = await _questionRepository.FindByIdAsync(id);

            if (existingQuestion == null)
                return new QuestionResponse("Question not found.");

            existingQuestion.Text = question.Text;

            _questionRepository.Update(existingQuestion);
            await _unitOfWork.CompleteAsync();
            return new QuestionResponse(existingQuestion);
        }
        catch (Exception e)
        {
            return new QuestionResponse($"An error occurred while updating the question: {e.Message}");
        }
    }

    public async Task<QuestionResponse> DeleteAsync(int id)
    {
        try
        {
            var existingQuestion = await _questionRepository.FindByIdAsync(id);

            if (existingQuestion == null)
                return new QuestionResponse("Question not found.");

            _questionRepository.Remove(existingQuestion);
            await _unitOfWork.CompleteAsync();
            return new QuestionResponse(existingQuestion);
        }
        catch (Exception e)
        {
            return new QuestionResponse($"An error occurred while deleting the question: {e.Message}");
        }
    }
}