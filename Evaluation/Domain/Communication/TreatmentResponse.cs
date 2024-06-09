using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class TreatmentResponse : BaseResponse<Treatment>
{
    public TreatmentResponse(string message) : base(message)
    {
    }

    public TreatmentResponse(Treatment resource) : base(resource)
    {
    }
}