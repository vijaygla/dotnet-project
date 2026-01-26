using ExamProctor.Interfaces;
using ExamProctor.Models;
using ExamProctor.Utilities;
using System.Collections.Generic;

namespace ExamProctor.Services
{
    public class ExamProctorService : IExamProctor
    {
        private Stack<int> navigationStack;
        private Dictionary<int, string> answerMap;
        private List<Question> questions;

        public ExamProctorService()
        {
            navigationStack = new Stack<int>();
            answerMap = new Dictionary<int, string>();

            // Sample questions (not answers)
            questions = new List<Question>
            {
                new Question(1, "A"),
                new Question(2, "B"),
                new Question(3, "C")
            };
        }

        public void VisitQuestion(int questionId)
        {
            navigationStack.Push(questionId);
            Console.WriteLine($"Visited Question {questionId}");
        }

        public void SubmitAnswer(int questionId, string answer)
        {
            answerMap[questionId] = answer;
            Console.WriteLine("Answer saved.");
        }

        public void ShowNavigationHistory()
        {
            if (navigationStack.Count == 0)
            {
                Console.WriteLine("No navigation history.");
                return;
            }

            Console.WriteLine("Navigation History (Last Visited First):");
            foreach (var q in navigationStack)
            {
                Console.WriteLine($"Question {q}");
            }
        }

        public void SubmitExam()
        {
            int score = ExamEvaluator.CalculateScore(questions, answerMap);
            Console.WriteLine($"Exam Submitted. Score: {score}/{questions.Count}");
        }
    }
}
