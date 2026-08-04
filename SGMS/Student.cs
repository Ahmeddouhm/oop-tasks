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
        public Dictionary<string, double> GradesWeights { get; private set; }

        public Student(string id , string name , string email)
        {
            ID = id;
            Name = name;
            Email = email;
            Grades = new();
            GradesWeights = new();
        }

        public void AddGrade(string subject, double grade, double weight)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject can not be null !");
                return;
            }

            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Invaild Grade !");
                return;
            }

            if (weight < 0 || weight > 100)
            {
                Console.WriteLine("Invaild Weight !");
                return;
            }

            weight /= 100;

            Grades.Add(subject,grade);
            GradesWeights.Add(subject,weight);
        }

        // This Method To Get Subject Grade | Weight Depending on the Collection that sent as Argument.
        public double GetSomething(string subject, Dictionary<string,double> keyValuePairs)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject can not be null !");
                return -1;
            }

            foreach (var kvp in keyValuePairs)
            {
                if (kvp.Key == subject)
                {
                    return kvp.Value;
                }
            }
            return -1;
        }
        //public double GetWeight(string subject)
        //{
        //    if (string.IsNullOrWhiteSpace(subject))
        //    {
        //        Console.WriteLine("Subject can not be null !");
        //        return -1;
        //    }

        //    foreach (var kvp in GradesWeights)
        //    {
        //        if (kvp.Key == subject)
        //        {
        //            return kvp.Value;
        //        }
        //    }
        //    return -1;
        //}

        
        public double CalculateAverage()
        {
            int subjectsCount = Grades.Count;

            if (subjectsCount == 0)
            {
                Console.WriteLine("Empty Student Grades");
                return -1;
            }

            double sum = 0;

            foreach (var kvp in Grades)
            {
                string subject = kvp.Key;
                double grade = kvp.Value;

                sum += grade * GetSomething(subject,GradesWeights);
            }

            return sum ;
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
