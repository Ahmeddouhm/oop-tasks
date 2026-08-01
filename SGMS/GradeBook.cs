using System;
using System.Collections.Generic;
using System.Text;

namespace SGMS
{
    internal class GradeBook
    {
        public string? ClassName { get; set; }
        public List<Student>? Students { get; set; }

        public GradeBook(string className)
        {
            ClassName = className;
            Students = new();
        }
    }
}
