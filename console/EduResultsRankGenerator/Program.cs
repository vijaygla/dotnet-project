using System;
using System.Collections.Generic;
using EduResultsRankGenerator.Models;
using EduResultsRankGenerator.Services;
using EduResultsRankGenerator.Utils;

namespace EduResultsRankGenerator
{
    class Program
    {
        // ✅ Declare shared data OUTSIDE Main
        static List<List<Student>> districtLists = new();
        static List<Student> finalRankList = new();
        static RankGeneratorService rankService = new RankGeneratorService();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== EduResults – Rank Sheet Generator ===");
                Console.WriteLine("1. Enter District & Student Data");
                Console.WriteLine("2. Generate State-Wise Rank List");
                Console.WriteLine("0. Exit");

                int choice = InputHelper.ReadInt("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        districtLists.Clear();

                        int districtCount = InputHelper.ReadInt("Enter number of districts: ");

                        for (int i = 1; i <= districtCount; i++)
                        {
                            Console.WriteLine($"\n--- District {i} ---");
                            int studentCount = InputHelper.ReadInt("Enter number of students: ");

                            List<Student> students = new();

                            for (int j = 1; j <= studentCount; j++)
                            {
                                Console.WriteLine($"\nStudent {j}");
                                string name = InputHelper.ReadString("Name: ");
                                int marks = InputHelper.ReadInt("Marks: ");

                                students.Add(new Student(name, marks));
                            }

                            districtLists.Add(students);
                        }

                        Console.WriteLine("\nData entry completed successfully.");
                        break;

                    case 2:
                        if (districtLists.Count == 0)
                        {
                            Console.WriteLine("No data found. Please enter student data first.");
                            break;
                        }

                        finalRankList = rankService.GenerateRankList(districtLists);

                        Console.WriteLine("\n=== State-Wise Rank List ===");
                        int rank = 1;
                        foreach (var student in finalRankList)
                        {
                            Console.WriteLine($"Rank {rank++}: {student.Name} - {student.Marks}");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting EduResults System...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
