namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Test
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Objective { get; set; }
    
    public IList<Question> Questions { get; set; }
}