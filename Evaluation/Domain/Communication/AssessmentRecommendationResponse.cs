using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class AssessmentRecommendationResponse : BaseResponse<AssessmentRecommendation>
{
    public AssessmentRecommendationResponse(string message) : base(message)
    {
    }

    public AssessmentRecommendationResponse(AssessmentRecommendation resource) : base(resource)
    {
    }
}