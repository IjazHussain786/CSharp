using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    public abstract class Student : Person
    {
        private Dictionary<string, double> grades;
        private int studentNumber;
        public Student(string name, int age, string eMail, int studentNumber)
            : base (name, age, eMail)
        {
            this.grades = new Dictionary<string, double>();
            this.StudentNumber = studentNumber;
        }
        public Student(string name, int age, int studentNumber)
            : base(name, age)
        {
            this.grades = new Dictionary<string, double>();
            this.StudentNumber = studentNumber;
        }
        public double AvgGrade 
        {
            get
            { 
                double avgGrade = this.grades.Values.Average();
                return avgGrade;
            }
        }
        public int StudentNumber 
        {
            get
            {
                return this.studentNumber;
            }
            set
            {
                if (studentNumber < 0)
                {
                    throw new ArgumentException("Student number cannot be negative.");
                }
                this.studentNumber = value;
            }
        }
        public void ListGrades()
        { 
            foreach (var pair in grades)
	        {
		        Console.WriteLine("Course: {0}, grade{1}", pair.Key, pair.Value);
	        }
        }
        public void AddGrade(string courseName, double grade)
        {
            this.grades[courseName] = grade;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}", this.GetType().Name).AppendLine();
            output.AppendFormat("Name: {0}", this.Name).AppendLine();
            output.AppendFormat("Student number: {0}, Average grade: {1}", this.StudentNumber, this.AvgGrade);
            return output.ToString();
        }
    }
}
