using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Domain.Services.Communication;

namespace MindWell_EvaluationService.Evaluation.Domain.Communication;

public class TestResponse : BaseResponse<Test>
{
    public TestResponse(string message) : base(message)
    {
    }

    public TestResponse(Test resource) : base(resource)
    {
    }
}