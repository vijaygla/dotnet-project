using ExamProctor.Models;
using System.Collections.Generic;

namespace ExamProctor.Utilities
{
    public static class ExamEvaluator
    {
        public static int CalculateScore(
            List<Question> questions,
            Dictionary<int, string> answers)
        {
            int score = 0;

            foreach (var question in questions)
            {
                if (answers.ContainsKey(question.QuestionId) &&
                    answers[question.QuestionId]
                    .Equals(question.CorrectAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                }
            }
            return score;
        }
    }
}
