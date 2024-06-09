namespace MindWell_EvaluationService.Evaluation.Domain.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    
    public int Test_Id { get; set; }
    public Test Test { get; set; }
}