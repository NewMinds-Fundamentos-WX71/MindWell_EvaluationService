using MindWell_EvaluationService.Evaluation.Domain.Communication;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Domain.Repositories;
using MindWell_EvaluationService.Evaluation.Domain.Services;
using MindWell_EvaluationService.Shared.Persistence.Repositories;

namespace MindWell_EvaluationService.Evaluation.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IRecommendationRepository _recommendationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RecommendationService(IRecommendationRepository recommendationRepository, IUnitOfWork unitOfWork)
    {
        _recommendationRepository = recommendationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Recommendation>> ListAsync()
    {
        return await _recommendationRepository.ListAsync();
    }

    public async Task<Recommendation> GetByIdAsync(int id)
    {
        return await _recommendationRepository.FindByIdAsync(id);
    }

    public async Task<RecommendationResponse> SaveAsync(Recommendation recommendation)
    {
        try
        {
            await _recommendationRepository.AddAsync(recommendation);
            await _unitOfWork.CompleteAsync();
            return new RecommendationResponse(recommendation);
        }
        catch (Exception e)
        {
            return new RecommendationResponse($"An error occurred while saving the recommendation: {e.Message}");
        }
    }

    public async Task<RecommendationResponse> UpdateAsync(int id, Recommendation recommendation)
    {
        try
        {
            var existingRecommendation = await _recommendationRepository.FindByIdAsync(id);

            if (existingRecommendation == null)
                return new RecommendationResponse("Recommendation not found.");

            existingRecommendation.Frecuency = recommendation.Frecuency;
            existingRecommendation.Category = recommendation.Category;
            existingRecommendation.Details = recommendation.Details;

            _recommendationRepository.Update(existingRecommendation);
            await _unitOfWork.CompleteAsync();
            return new RecommendationResponse(existingRecommendation);
        }
        catch (Exception e)
        {
            return new RecommendationResponse($"An error occurred while updating the recommendation: {e.Message}");
        }
    }

    public async Task<RecommendationResponse> DeleteAsync(int id)
    {
        try
        {
            var existingRecommendation = await _recommendationRepository.FindByIdAsync(id);

            if (existingRecommendation == null)
                return new RecommendationResponse("Recommendation not found.");

            _recommendationRepository.Remove(existingRecommendation);
            await _unitOfWork.CompleteAsync();
            return new RecommendationResponse(existingRecommendation);
        }
        catch (Exception e)
        {
            return new RecommendationResponse($"An error occurred while deleting the recommendation: {e.Message}");
        }
    }
}