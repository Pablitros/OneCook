namespace OneCook.DL.Models
{
    public class StepVM
    {
        public int Id { get; set; }
        public int PreparationGuideId { get; set; }
        public string Content { get; set; }
        public string TimeUsed { get; set; }
        public virtual PreparationGuideVM PreparationGuide { get; set; }

        public StepVM() { }
        public StepVM(Step step)
        {
            Id = step.Id;
            PreparationGuideId = step.PreparationGuideId;
            Content = step.Content;
            TimeUsed = step.TimeUsed;
            if (step.PreparationGuide != null)
            {
                PreparationGuide = new PreparationGuideVM(step.PreparationGuide);
            }
        }

    }
}
