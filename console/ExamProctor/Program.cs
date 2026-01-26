using ExamProctor.Services;

namespace ExamProctor
{
    class Program
    {
        static void Main()
        {
            ExamProctorService exam = new ExamProctorService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Exam Proctor Menu ===");
                Console.WriteLine("1. Visit Question");
                Console.WriteLine("2. Submit Answer");
                Console.WriteLine("3. View Navigation History");
                Console.WriteLine("4. Submit Exam");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter Question ID: ");
                        exam.VisitQuestion(int.Parse(Console.ReadLine()));
                        break;

                    case "2":
                        Console.Write("Question ID: ");
                        int qid = int.Parse(Console.ReadLine());
                        Console.Write("Answer: ");
                        exam.SubmitAnswer(qid, Console.ReadLine());
                        break;

                    case "3":
                        exam.ShowNavigationHistory();
                        break;

                    case "4":
                        exam.SubmitExam();
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
