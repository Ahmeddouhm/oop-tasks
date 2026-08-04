using SGMS;

var gradeBook = new GradeBook("Computer Science 101");

// Create students
var student1 = new Student("S001", "Alice Johnson", "alice@school.com");
var student2 = new Student("S002", "Bob Smith", "bob@school.com");
var student3 = new Student("S003", "Charlie Brown", "charlie@school.com");

// Add grades for students
student1.AddGrade("Math", 95.0, 60);
student1.AddGrade("English", 88.0, 10);
student1.AddGrade("Science", 92.0, 30);

student2.AddGrade("Math", 78.0, 60);
student2.AddGrade("English", 85.0, 10);
student2.AddGrade("Science", 80.0, 30);

student3.AddGrade("Math", 90.0, 20);
student3.AddGrade("English", 92.0, 60);
student3.AddGrade("Science", 89.0, 20);

// Add students to gradebook
gradeBook.AddStudent(student1);
gradeBook.AddStudent(student2);
gradeBook.AddStudent(student3);

// Display all students
gradeBook.DisplayAllStudents();
Console.WriteLine();

// Get class average
Console.WriteLine("Class Average: " + gradeBook.GetClassAverage().ToString("F2"));
Console.WriteLine();

// Get top students
var topStudents = gradeBook.GetTopStudents(2);
Console.WriteLine("Top 2 Students:");
Console.WriteLine("---------------");
foreach (var student in topStudents) 
{
    Console.WriteLine(student.Name + ": " + student.CalculateAverage().ToString("F2"));
}
Console.WriteLine();

// Get student info
student1.GetStudentInfo();