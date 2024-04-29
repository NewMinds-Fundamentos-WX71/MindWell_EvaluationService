namespace MindWell_EvaluationService.Evaluation.Resources.GET;

public class AssessmentResource
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int User_Id { get; set; }

    public int Diagnose_Id { get; set; }
}