namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class AssessmentRecommendation
{
    public int Id { get; set; }
    public int Assessment_Id { get; set; }
    public Assessment Assessment { get; set; }
    public int Recommendation_Id { get; set; }
    public Recommendation Recommendation { get; set; }
}