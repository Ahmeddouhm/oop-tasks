using System;
using System.Collections.Generic;
using System.Text;

namespace SGMS
{
    internal class Student
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Dictionary<string, double>? Grades { get; set; }

        public Student(string id , string name , string email)
        {
            ID = id;
            Name = name;
            Email = email;
            Grades = new();
        }


    }

    
}
