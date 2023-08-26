namespace X.Kwiz.Api.Entities;
public class SubmissionSelection
{
    public int QuestionId {get;set;}
    public List<char> SelectedOptionIds { get; set; }
    public bool IsSkipped { get; set; }
    public int TimeSpentOnQuestion { get; set; }
}