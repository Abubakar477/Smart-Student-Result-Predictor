using System;

namespace student_predication
{
    public abstract class Person
    {
        // Encapsulation using properties
        public string Name { get; set; }
        public int Age { get; set; }

        // Constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Calculation method
        public int CalculateBirthYear()
        {
            return DateTime.Now.Year - Age;
        }

        // Virtual method for Polymorphism
        public virtual string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}, Birth Year: {CalculateBirthYear()}";
        }
    }
}
