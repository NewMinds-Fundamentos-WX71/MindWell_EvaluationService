namespace MindWell_EvaluationService.Evaluation.Resources.POST;

public class SaveAssessmentResource
{
    public DateTime Date { get; set; }
    public int User_Id { get; set; }

    public int Diagnose_Id { get; set; }
}