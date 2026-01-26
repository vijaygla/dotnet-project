using System.Collections.Generic;
using System.Linq;
using EduResultsRankGenerator.Models;

namespace EduResultsRankGenerator.Services
{
    public class MergeSortService
    {
        public List<Student> MergeSort(List<Student> students)
        {
            if (students.Count <= 1)
                return students;

            int mid = students.Count / 2;
            List<Student> left = MergeSort(students.Take(mid).ToList());
            List<Student> right = MergeSort(students.Skip(mid).ToList());

            return Merge(left, right);
        }

        private List<Student> Merge(List<Student> left, List<Student> right)
        {
            List<Student> result = new();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                // Descending order by Marks
                if (left[i].Marks > right[j].Marks)
                    result.Add(left[i++]);
                else
                    result.Add(right[j++]);
            }

            result.AddRange(left.Skip(i));
            result.AddRange(right.Skip(j));

            return result;
        }
    }
}
