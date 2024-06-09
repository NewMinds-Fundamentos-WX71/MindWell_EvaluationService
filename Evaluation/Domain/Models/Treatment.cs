namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Treatment
{
    public int Id { get; set; }
    public int Counter { get; set; }
    
    public int Assessment_Id { get; set; }
    public Assessment Assessment { get; set; }
}