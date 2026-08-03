using System;
using System.Collections.Generic;
using System.Text;

namespace SGMS
{
    internal class GradeBook
    {
        public string? ClassName { get; set; }
        public List<Student> Students { get; set; }

        public GradeBook(string className)
        {
            ClassName = className;
            Students = new();
        }

        public void AddStudent(Student student) 
        {
            if (student is null)
            {
                Console.WriteLine("Invaild Student !");
                return;
            }

            Students.Add(student);
        }
        public void RemoveStudent(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                Console.WriteLine("Invaild ID !");
                return;
            }

            foreach (var s in Students)
            {
                if (s.ID == studentId)
                {
                    Students.Remove(s);
                    return;
                }
            }

        }
        public Student? FindStudent(string studentId) 
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                Console.WriteLine("Invaild ID !");
                return null;
            }

            foreach (var s in Students)
            {
                if (s.ID == studentId)
                {
                    return s;
                }
            }
            return null;
        }
        public List<Student>? GetStudentsByLetterGrade(char letterGrade)
        {
            List<Student> result = new();

            if (char.IsWhiteSpace(letterGrade))
            {
                Console.WriteLine("Invalid Letter Grade !");
                return null;
            }

            foreach (var s in Students)
            {
                char letter = s.GetLetterGrade();
                if (letter == letterGrade)
                {
                    result.Add(s);
                }
            }

            return result;
        }
        public double GetClassAverage()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("Empty Class !");
                return -1;
            }

            double sum = 0;

            foreach (var s in Students)
            {
                sum += s.CalculateAverage();
            }

            return sum / Students.Count;
        }

        public List<Student>? GetTopStudents(int count)
        {
            List<Student> result = new(Students);
            if (count > Students.Count || count <= 0)
            {
                Console.WriteLine("Invalid Count !");
                return null;
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i+1; j < result.Count; j++)
                {
                    if (result[j].CalculateAverage() > result[i].CalculateAverage())
                    {
                        (result[i], result[j]) = (result[j], result[i]);
                    }
                }
            }

            return result[..count];
        }
        public void DisplayAllStudents()
        {
            Console.WriteLine($"=== {ClassName} - All Students ===");
            Console.WriteLine($"===================");
            foreach (var s in Students)
            {
                Console.WriteLine($"({s.ID}) - {s.Name}: {s.CalculateAverage().ToString("F2")} ({s.GetLetterGrade()})");
            }
        }

    }
}
