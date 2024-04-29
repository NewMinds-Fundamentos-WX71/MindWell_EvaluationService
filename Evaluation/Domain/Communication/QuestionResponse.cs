using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class QuestionResponse : BaseResponse<Question>
{
    public QuestionResponse(string message) : base(message)
    {
    }

    public QuestionResponse(Question resource) : base(resource)
    {
    }
}