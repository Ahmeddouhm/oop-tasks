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

        public double Attendance { get; set; } = 1.0;

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
                Console.WriteLine("Invalid Grade !");
                return;
            }

            if (weight < 0 || weight > 100)
            {
                Console.WriteLine("Invalid Weight !");
                return;
            }

            weight /= 100;

            Grades.Add(subject,grade);
            GradesWeights.Add(subject,weight);
        }

        // Method Helper O(1) LookUp Instead Of Iterating All the Collection .
        private double GetValueBySubject(string subject, Dictionary<string, double> dictionary) 
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject can not be null !");
                return -1;
            }

            return dictionary.TryGetValue(subject, out double value) ? value : -1;
        }

        public double GetGrade(string subject) => GetValueBySubject(subject, Grades);
        public double GetWeight(string subject) => GetValueBySubject(subject, GradesWeights);

        // This Method To Get Subject Grade | Weight Depending on the Collection that sent as Argument.

        //public double GetSomething(string subject, Dictionary<string,double> keyValuePairs)
        //{
        //    if (string.IsNullOrWhiteSpace(subject))
        //    {
        //        Console.WriteLine("Subject can not be null !");
        //        return -1;
        //    }

        //    foreach (var kvp in keyValuePairs)
        //    {
        //        if (kvp.Key == subject)
        //        {
        //            return kvp.Value;
        //        }
        //    }
        //    return -1;
        //}

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

        public double SetAttendance(double days)
        {
            double totalDays = 55;

            if (days < 0 || days > 55)
            {
                Console.WriteLine("Invalid Attendance Value !");
                return 0;
            }

            Attendance = days / totalDays;

            return Attendance;
        }
        public double CalculateAverage()
        {
            int subjectsCount = Grades.Count;

            if (subjectsCount == 0)
            {
                Console.WriteLine("Empty Student Grades");
                return -1;
            }

            double sum = 0;
            double weightsSum = 0;

            foreach (var kvp in Grades)
            {
                string subject = kvp.Key;
                double grade = kvp.Value;

                sum += grade * GetWeight(subject);
                weightsSum += GetWeight(subject);
            }
            // handling weights entered values
            return sum / weightsSum;
        }

        public double CalculateAverageWithAttendance() 
        {
            return CalculateAverage() * Attendance;
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

        public void ApplyBonus(string subject, double bonus) 
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.WriteLine("Subject can not be null !");
                return;
            }

            if (bonus < 0 || bonus > 50)
            {
                Console.WriteLine("Invalid Bonus Value !");
                return;
            }

            double grade = GetGrade(subject);

            if (grade + bonus > 100)
            {
                Grades[subject] = 100;
                return;
            }

            Grades[subject] = grade + bonus;
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
        public string GetStudentInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"=== Student Information ===" +
                $"\nID: {ID}" +
                $"\nName: {Name}" +
                $"\nEmail: {Email}");

            sb.AppendLine("Grades:");
            foreach (var s in Grades)
            {
                sb.AppendLine($"    {s.Key}: {s.Value}");
            }
            sb.AppendLine($"Average ({GetLetterGrade()})");

            return sb.ToString();
        }
    }


}
