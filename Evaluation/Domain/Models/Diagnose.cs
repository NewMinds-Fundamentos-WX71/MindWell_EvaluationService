namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Diagnose
{
    public int Id { get; set; }
    public string Result { get; set; }
    
    public Assessment Assessment { get; set; }
    public IList<Recommendation> Recommendations { get; set; }
}