using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class AssessmentRecommendationService : IAssessmentRecommendationService
{
    private readonly IAssessmentRecommendationRepository _assessmentRecommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssessmentRecommendationService(IAssessmentRecommendationRepository assessmentRecommendationRepository, IUnitOfWork unitOfWork)
    {
        _assessmentRecommendationRepository = assessmentRecommendationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<AssessmentRecommendation>> ListAllAsync()
    {
        return await _assessmentRecommendationRepository.FindAllAsync();
    }

    public async Task<IEnumerable<AssessmentRecommendation>> ListAllByAssessmentIdAsync(int id)
    {
        return await _assessmentRecommendationRepository.FindAllByAssessmentIdAsync(id);
    }

    public async Task<IEnumerable<AssessmentRecommendation>> ListAllByRecommendationIdAsync(int id)
    {
        return await _assessmentRecommendationRepository.FindAllByRecommendationIdAsync(id);
    }

    public async Task<AssessmentRecommendation> ListByIdAsync(int id)
    {
        return await _assessmentRecommendationRepository.FindByIdAsync(id);
    }

    public async Task<AssessmentRecommendationResponse> SaveAsync(AssessmentRecommendation assessmentRecommendation)
    {
        try
        {
            await _assessmentRecommendationRepository.AddAsync(assessmentRecommendation);
            await _unitOfWork.CompleteAsync();
            return new AssessmentRecommendationResponse(assessmentRecommendation);
        }
        catch (Exception e)
        {
            return new AssessmentRecommendationResponse("An error occurred while saving the assessment recommendation: " + e.Message);
        }
    }
}