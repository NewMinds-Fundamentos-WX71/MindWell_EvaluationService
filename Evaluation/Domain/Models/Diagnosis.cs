namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Diagnosis
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Recommendation> Recommendations { get; set; }
    public List<Assessment> Assessments { get; set; }
}