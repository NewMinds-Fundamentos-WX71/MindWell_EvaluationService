using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class DiagnosisResponse : BaseResponse<Diagnosis>
{
    public DiagnosisResponse(string message) : base(message)
    {
    }

    public DiagnosisResponse(Diagnosis resource) : base(resource)
    {
    }
}