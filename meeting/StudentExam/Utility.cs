using StudentExam;

namespace StudentExam
{
    public class Utility
    {
        // add student record
        public void AddStudentRecord(string studentName, string subject, int score)
        {
            StudentRecord record = new StudentRecord()
            {
                StudentName = studentName,
                Subject = subject,
                Score = score
            };

            int key = Program.studentRecords.Count + 1;
            Program.studentRecords.Add(key, record);
        }
        
        // method to group student by subject
        public SortedDictionary<string, List<StudentRecord>> GroupBySubject()
        {
            var group = Program.studentRecords.Values.GroupBy(i => i.Subject).ToDictionary(g => g.Key, g => g.ToList());

            return new SortedDictionary<string, List<StudentRecord>>(group);
        }

        // average score
        public Dictionary<string, double> GetAverageScorePerSubject()
        {
            return Program.studentRecords.Values.GroupBy(i => i.Subject).ToDictionary(g => g.Key, g => g.Average(i => i.Score));
        }


        //  Get top scorer
        public StudentRecord GetTopScorer()
        {
            return Program.studentRecords.Values.OrderByDescending(r => r.Score).FirstOrDefault();
        }


        // Filter students by minimum score
        public List<StudentRecord> FilterStudentsByScore(int minScore)
        {
            return Program.studentRecords.Values.Where(r => r.Score >= minScore).ToList();
        }
    }
}
