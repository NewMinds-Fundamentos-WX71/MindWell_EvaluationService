using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class AssessmentQuestionService : IAssessmentQuestionService
{
    private readonly IAssessmentQuestionRepository _assessmentQuestionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssessmentQuestionService(IAssessmentQuestionRepository assessmentQuestionRepository, IUnitOfWork unitOfWork)
    {
        _assessmentQuestionRepository = assessmentQuestionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AssessmentQuestion>> ListAsync()
    {
        return await _assessmentQuestionRepository.ListAsync();
    }

    public async Task<AssessmentQuestion> GetByIdAsync(int id)
    {
        return await _assessmentQuestionRepository.FindByIdAsync(id);
    }

    public async Task<AssessmentQuestionResponse> SaveAsync(AssessmentQuestion assessmentQuestion)
    {
        try
        {
            await _assessmentQuestionRepository.AddAsync(assessmentQuestion);
            await _unitOfWork.CompleteAsync();
            return new AssessmentQuestionResponse(assessmentQuestion);
        }
        catch (Exception e)
        {
            return new AssessmentQuestionResponse($"An error occurred while saving the assessment question: {e.Message}");
        }
    }

    public async Task<AssessmentQuestionResponse> UpdateAsync(int id, AssessmentQuestion assessmentQuestion)
    {
        try
        {
            var existingAssessmentQuestion = await _assessmentQuestionRepository.FindByIdAsync(id);

            if (existingAssessmentQuestion == null)
                return new AssessmentQuestionResponse("Assessment Question not found.");

            _assessmentQuestionRepository.Update(existingAssessmentQuestion);
            await _unitOfWork.CompleteAsync();
            return new AssessmentQuestionResponse(existingAssessmentQuestion);
        }
        catch (Exception e)
        {
            return new AssessmentQuestionResponse($"An error occurred while updating the assessment question: {e.Message}");
        }
    }

    public async Task<AssessmentQuestionResponse> DeleteAsync(int id)
    {
        try
        {
            var existingAssessmentQuestion = await _assessmentQuestionRepository.FindByIdAsync(id);

            if (existingAssessmentQuestion == null)
                return new AssessmentQuestionResponse("Assessment question not found.");

            _assessmentQuestionRepository.Remove(existingAssessmentQuestion);
            await _unitOfWork.CompleteAsync();
            return new AssessmentQuestionResponse(existingAssessmentQuestion);
        }
        catch (Exception e)
        {
            return new AssessmentQuestionResponse($"An error occurred while deleting the assessment question: {e.Message}");
        }
    }
}