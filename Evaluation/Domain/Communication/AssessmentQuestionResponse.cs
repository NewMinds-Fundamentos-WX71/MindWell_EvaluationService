using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class AssessmentQuestionResponse : BaseResponse<AssessmentQuestion>
{
    public AssessmentQuestionResponse(string message) : base(message)
    {
    }

    public AssessmentQuestionResponse(AssessmentQuestion resource) : base(resource)
    {
    }
}