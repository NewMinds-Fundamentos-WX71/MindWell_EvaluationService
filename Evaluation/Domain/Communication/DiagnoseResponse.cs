using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class DiagnoseResponse : BaseResponse<Diagnose>
{
    public DiagnoseResponse(string message) : base(message)
    {
    }

    public DiagnoseResponse(Diagnose resource) : base(resource)
    {
    }
}