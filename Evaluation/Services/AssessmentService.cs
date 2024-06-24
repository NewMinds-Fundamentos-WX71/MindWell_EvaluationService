using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class AssessmentService : IAssessmentService
{
    private readonly IAssessmentRepository _assessmentRepository;
    private readonly IAssessmentRecommendationRepository _assessmentRecommendationRepository;
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssessmentService(IAssessmentRepository assessmentRepository, IUnitOfWork unitOfWork, IAssessmentRecommendationRepository assessmentRecommendationRepository, IRecommendationRepository recommendationRepository)
    {
        _assessmentRepository = assessmentRepository;
        _unitOfWork = unitOfWork;
        _assessmentRecommendationRepository = assessmentRecommendationRepository;
        _recommendationRepository = recommendationRepository;
    }

    public async Task<IEnumerable<Assessment>> ListAsync()
    {
        return await _assessmentRepository.ListAsync();
    }

    public async Task<Assessment> GetByIdAsync(int id)
    {
        return await _assessmentRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Assessment>> ListByPatientIdAsync(int id)
    {
        return await _assessmentRepository.ListByPatientIdAsync(id);
    }

    public async Task<AssessmentResponse> SaveAsync(Assessment assessment)
    {
        try
        {
            assessment.Diagnosis_Id = 10;
            
            await _assessmentRepository.AddAsync(assessment);
            await _unitOfWork.CompleteAsync();
            return new AssessmentResponse(assessment);
        }
        catch (Exception e)
        {
            return new AssessmentResponse($"An error occurred while saving the assessment: {e.Message}");
        }
    }
    
    public async Task<AssessmentResponse> CalculateAnxietyDiagnosis(int id, IEnumerable<int> answers)
    {
        try
        {
            var existingAssessment = await _assessmentRepository.FindByIdAsync(id);
            
            if (existingAssessment == null)
                return new AssessmentResponse("Assessment not found.");
            
            var result = answers.Sum();

            var diagnosisId = result switch
            {
                <= 7 => 6,
                <= 15 => 7,
                <= 25 => 8,
                <= 63 => 9,
                _ => 10
            };
            
            existingAssessment.Diagnosis_Id = diagnosisId;
            
            _assessmentRepository.Update(existingAssessment);
            await _unitOfWork.CompleteAsync();

            var recommendations = await _recommendationRepository.FindAllByDiagnosisIdAsync(diagnosisId);
            
            // Crea un registro en AssessmentRecommendation para cada recomendación
            foreach (var recommendation in recommendations)
            {
                var assessmentRecommendation = new AssessmentRecommendation
                {
                    Assessment_Id = existingAssessment.Id,
                    Recommendation_Id = recommendation.Id
                };

                await _assessmentRecommendationRepository.AddAsync(assessmentRecommendation);
            }
            
            await _unitOfWork.CompleteAsync();
            return new AssessmentResponse(existingAssessment);
        }
        catch (Exception e)
        {
            return new AssessmentResponse("An error occurred while calculating the anxiety diagnosis of the assessment: " + e.Message);
        }
    }

    public async Task<AssessmentResponse> CalculateDepressionDiagnosis(int id, IEnumerable<int> answers)
    {
        try
        {
            var existingAssessment = await _assessmentRepository.FindByIdAsync(id);
            
            if (existingAssessment == null)
                return new AssessmentResponse("Assessment not found.");
            
            var result = answers.Sum();
            
            var diagnose = result switch
            {
                <= 4 => 1,
                <= 9 => 2,
                <= 14 => 3,
                <= 19 => 4,
                <= 27 => 5,
                _ => 10
            };
            
            existingAssessment.Diagnosis_Id = diagnose;
            
            _assessmentRepository.Update(existingAssessment);
            await _unitOfWork.CompleteAsync();
            return new AssessmentResponse(existingAssessment);
        }
        catch (Exception e)
        {
            return new AssessmentResponse("An error occurred while calculating the depression diagnosis of the assessment: " + e.Message);
        }
    }

    public async Task<AssessmentResponse> UpdateAsync(int id, Assessment assessment)
    {
        try
        {
            var existingAssessment = await _assessmentRepository.FindByIdAsync(id);

            if (existingAssessment == null)
                return new AssessmentResponse("Assessment not found.");

            existingAssessment.Diagnosis_Id = assessment.Diagnosis_Id;

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