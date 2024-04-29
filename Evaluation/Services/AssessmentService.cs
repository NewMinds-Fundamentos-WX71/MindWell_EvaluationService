using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class AssessmentService : IAssessmentService
{
    private readonly IAssessmentRepository _assessmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssessmentService(IAssessmentRepository assessmentRepository, IUnitOfWork unitOfWork)
    {
        _assessmentRepository = assessmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Assessment>> ListAsync()
    {
        return await _assessmentRepository.ListAsync();
    }

    public async Task<Assessment> GetByIdAsync(int id)
    {
        return await _assessmentRepository.FindByIdAsync(id);
    }

    public async Task<AssessmentResponse> SaveAsync(Assessment assessment)
    {
        try
        {
            await _assessmentRepository.AddAsync(assessment);
            await _unitOfWork.CompleteAsync();
            return new AssessmentResponse(assessment);
        }
        catch (Exception e)
        {
            return new AssessmentResponse($"An error occurred while saving the assessment: {e.Message}");
        }
    }

    public async Task<AssessmentResponse> UpdateAsync(int id, Assessment assessment)
    {
        try
        {
            var existingAssessment = await _assessmentRepository.FindByIdAsync(id);

            if (existingAssessment == null)
                return new AssessmentResponse("Assessment not found.");

            existingAssessment.Date = assessment.Date;

            _assessmentRepository.Update(existingAssessment);
            await _unitOfWork.CompleteAsync();
            return new AssessmentResponse(existingAssessment);
        }
        catch (Exception e)
        {
            return new AssessmentResponse($"An error occurred while updating the assessment: {e.Message}");
        }
    }

    public async Task<AssessmentResponse> DeleteAsync(int id)
    {
        try
        {
            var existingAssessment = await _assessmentRepository.FindByIdAsync(id);

            if (existingAssessment == null)
                return new AssessmentResponse("Assessment not found.");

            _assessmentRepository.Remove(existingAssessment);
            await _unitOfWork.CompleteAsync();
            return new AssessmentResponse(existingAssessment);
        }
        catch (Exception e)
        {
            return new AssessmentResponse($"An error occurred while deleting the assessment: {e.Message}");
        }
    }
}