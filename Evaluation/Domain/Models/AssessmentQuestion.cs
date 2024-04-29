namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class AssessmentQuestion
{
    public int Id { get; set; }
    
    public int Assessment_Id { get; set; }
    public Assessment Assessment { get; set; }
    public int Question_Id { get; set; }
    public Question Question { get; set; }
}