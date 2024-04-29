using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class AssessmentResponse : BaseResponse<Assessment>
{
    public AssessmentResponse(string message) : base(message)
    {
    }

    public AssessmentResponse(Assessment resource) : base(resource)
    {
    }
}