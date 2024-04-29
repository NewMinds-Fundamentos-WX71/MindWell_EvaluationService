using AutoMapper;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Evaluation.Resources.GET;

namespace MindWell_EvaluationService.Evaluation.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Assessment, AssessmentResource>();
        CreateMap<AssessmentQuestion, AssessmentQuestionResource>();
        CreateMap<Diagnose, DiagnoseResource>();
        CreateMap<Question, QuestionResource>();
        CreateMap<Recommendation, RecommendationResource>();
    }
}