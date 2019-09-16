namespace CoreMvc.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbConetxt _dbConetxt;

        public FeedbackRepository(AppDbConetxt dbConetxt)
        {
            _dbConetxt = dbConetxt;
        }

        public void AddFeedback(Feedback feedback)
        {
            _dbConetxt.Feedbacks.Add(feedback);
            _dbConetxt.SaveChanges();
        }
    }
}
