namespace ExamProctor.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(int questionId, string correctAnswer)
        {
            QuestionId = questionId;
            CorrectAnswer = correctAnswer;
        }
    }
}
