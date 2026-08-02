using System;
using System.Collections.Generic;
using System.Text;

namespace SGMS
{
    internal class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Dictionary<string, double> Grades { get; private set; }

        public Student(string id , string name , string email)
        {
            ID = id;
            Name = name;
            Email = email;
            Grades = new();
        }

        public void AddGrade(string subject, double grade)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject can not be null !");
                return;
            }

            if (grade < 0 && grade > 100)
            {
                Console.WriteLine("Invaild Grade !");
                return;
            }

            Grades.Add(subject,grade);
        }

        public double GetGrade(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject can not be null !");
                return -1;
            }

            foreach (var kvp in Grades)
            {
                if (kvp.Key == subject)
                {
                    return kvp.Value;
                }
            }
            return -1;
        }

        public double CalculateAverage()
        {
            int subjectsCount = Grades.Count;

            if (subjectsCount == 0)
            {
                Console.WriteLine("Empty Student Grades");
                return -1;
            }

            double sum = -1;

            foreach (var kvp in Grades)
            {
                sum += kvp.Value;
            }

            return sum / subjectsCount;
        }

        public char GetLetterGrade()
        {
            double average = CalculateAverage();

            switch (average)
            {
                case >= 90:
                    return 'A';
                case >= 80:
                    return 'B';
                case >= 70:
                    return 'C';
                case >= 60:
                    return 'D';
                case >= 50:
                    return 'F';
                default:
                    return 'N';
            }
        }

        /*
        === Student Information ===
        ID: S001
        Name: Alice Johnson
        Email: alice@school.com
        Grades:
          Math: 95.00
          English: 88.00
          Science: 92.00
        Average: 91.67 (A)
         */
        public void GetStudentInfo()
        {
            Console.WriteLine($"=== Student Information ===" +
                $"\nID: {ID}" +
                $"\nName: {Name}" +
                $"\nEmail: {Email}");

            Console.WriteLine("Grades:");
            foreach (var s in Grades)
            {
                Console.WriteLine($"    {s.Key}: {s.Value}");
            }
            Console.WriteLine($"Average ({GetLetterGrade()})");
        }
    }

    
}
