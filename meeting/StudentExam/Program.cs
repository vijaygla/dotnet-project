/*
🧩 Scenario: Student Exam Performance Analyzer
 
👤 Background:
John has taken up a freelance project for a coaching institute. The institute wants an application to manage student exam records. Each record includes the student's name, subject, and score. The application should allow adding records, grouping students by subject, and analyzing performance using LINQ.
Help John build this application using your C# skills.
🛠️ Functionalities
 In class Program:
C#
public static SortedDictionary<int, StudentRecord> studentRecords;

 
Show more lines
 
This sorted dictionary is already provided. It stores student exam records with an auto-incremented key.
 In class StudentRecord, implement the following properties:
Data Type	Property Name
string	StudentName
string	Subject
int	Score
 In class RecordUtility, implement the following methods:
Method 1:
 
C#
public void AddStudentRecord(string studentName, string subject, int score)

 
Show more lines
 
Adds a new student record to the studentRecords dictionary.
The key is set to one more than the current number of items in the dictionary.
Method 2:
 
C#
public SortedDictionary<string, List<StudentRecord>> GroupRecordsBySubject()

 
Show more lines
 
Groups all student records by their subject.
Returns a dictionary where:
Key = Subject name
Value = List of student records under that subject
Method 3:
 
C#
public Dictionary<string, double> GetAverageScorePerSubject()

 
Show more lines
 
Uses LINQ to calculate the average score for each subject.
Method 4:
 
C#
public StudentRecord GetTopScorer()

 
Show more lines
 
Uses LINQ to find the student with the highest score across all subjects.
Method 5:
 
C#
public List<StudentRecord> FilterStudentsByScore(int minScore)

 
Show more lines
 
Returns a list of students whose score is greater than or equal to minScore.
🧪 Sample Input/Output
1. Add Student Record
2. Group Records By Subject
3. Show Average Score Per Subject
4. Show Top Scorer
5. Filter Students By Minimum Score
6. Exit
Enter your choice
1
Enter student name
Alice
Enter subject
Math
Enter score
85
Student record added successfully
Enter your choice
1
Enter student name
Bob
Enter subject
Science
Enter score
90
Student record added successfully
Enter your choice
1
Enter student name
Charlie
Enter subject
Math
Enter score
78
Student record added successfully
Enter your choice
2
Math
Alice - 85
Charlie - 78
Science
Bob - 90
Enter your choice
3
Average Scores:
Math - 81.5
Science - 90.0
Enter your choice
4
Top Scorer:
Bob - 90
Enter your choice
5
Enter minimum score
80
Students with score >= 80:
Alice - 85
Bob - 90
Enter your choice
6

*/

using System;

namespace StudentExam
{
    class Program
    {
        public static SortedDictionary<int, StudentRecord> studentRecords = new SortedDictionary<int, StudentRecord>();
        static void Main(String[] args)
        {
            Utility utility = new Utility();

            while(true)
            {
                Console.WriteLine("1. Add Student : ");
                Console.WriteLine("2. Group Student by subject : ");
                Console.WriteLine("3. Show average score per subject : ");
                Console.WriteLine("4. Show topScore score : ");
                Console.WriteLine("5. Filter student by minimum score : ");
                Console.WriteLine("6. Exit : ");

                Console.Write("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter student name : ");
                        string name = Console.ReadLine();
                        
                        Console.WriteLine("Enter subject : ");
                        string subject = Console.ReadLine();
                        
                        Console.WriteLine("Enter score : ");
                        int score = Convert.ToInt32(Console.ReadLine());

                        utility.AddStudentRecord(name, subject, score);
                        
                        Console.WriteLine("Student added successfully");
                        break;
                    
                    case 2:
                        // group by subject
                        var group = utility.GroupBySubject();
                        foreach(var item in group)
                        {
                            Console.WriteLine($"{item.Key}");

                            foreach(var i in item.Value)
                            {
                                Console.WriteLine($"{i.StudentName} ---> {i.Score}");
                            }
                        }
                        break;
                    
                    case 3:
                        var avg = utility.GetAverageScorePerSubject();
                        Console.WriteLine("Average Score : ");
                        foreach(var item in avg)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value:F1}");
                        }
                        break;

                    case 4:
                        var topScore = utility.GetTopScorer();

                        if (topScore != null)
                            Console.WriteLine($"Top Scorer:\n{topScore.StudentName} - {topScore.Score}");
                        break;

                    case 5:
                        // Filter by score
                        Console.WriteLine("Enter minimum score");
                        int min = int.Parse(Console.ReadLine());

                        var list = utility.FilterStudentsByScore(min);

                        Console.WriteLine($"Students with score >= {min}:");
                        foreach (var r in list)
                        {
                            Console.WriteLine($"{r.StudentName} - {r.Score}");
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
