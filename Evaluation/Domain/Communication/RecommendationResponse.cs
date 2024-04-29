using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class RecommendationResponse : BaseResponse<Recommendation>
{
    public RecommendationResponse(string message) : base(message)
    {
    }

    public RecommendationResponse(Recommendation resource) : base(resource)
    {
    }
}