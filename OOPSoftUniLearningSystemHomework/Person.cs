using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniLR
{
    public abstract class Person
    {
        private string name;
        private int age;
        private string eMail;
        public Person(string name, int age, string eMail)
        {
            this.Name = name;
            this.Age = age;
            this.EMail = eMail;
        }
        public Person(string name, int age)
            : this(name, age, null)
        {
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should not be empty!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name should be at least two letters!");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Name should be no more than 50 letters!");
                }
                foreach (char letter in value)
                {
                    if (IsValidName(letter) == false)
                    {
                        throw new ArgumentException("Name should contain letters, space and hyphen only!");
                    }
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Age should be in the inreval [0-100]!");
                }
                this.age = value;
            }
        }
        public string EMail
        {
            get
            {
                return this.eMail;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                value = value.Trim();
                if (value == string.Empty)
                {
                    throw new ArgumentException("Email should not be empty! You could only skip entering it");
                }
                if (value.Contains('@') == false)
                {
                    throw new ArgumentException("Email should contain @");
                }
                if (value.Length < 6)
                {
                    throw new ArgumentException("Email should be at least 6 letters!");
                }
                if (value.Length > 30)
                {
                    throw new ArgumentException("Email should be no more than 30 letters!");
                }
                this.eMail = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}, age: {1}, e-mail: {2}", this.Name, this.Age, this.EMail);
        }
        static bool IsValidName(char letter)
        {
            bool isValidLetter = (char.IsLetter(letter)) || (letter == ' ') || (letter == '-');
            return isValidLetter;
        }
    }
}
