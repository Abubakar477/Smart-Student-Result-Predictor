using System;

namespace student_predication
{
    public class Student : Person
    {
        // Encapsulation using properties
        public string StudentId { get; set; }
        public double Marks { get; set; }

        public Student(string name, int age, string studentId, double marks) : base(name, age)
        {
            StudentId = studentId;
            Marks = marks;
        }

        // Calculation Method for Result
        public string CalculateResult()
        {
            if (Marks >= 50)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }
        }

        // Polymorphism: overriding the base method
        public override string GetDetails()
        {
            return base.GetDetails() + $", Student ID: {StudentId}, Marks: {Marks}, Result: {CalculateResult()}";
        }
    }
}
