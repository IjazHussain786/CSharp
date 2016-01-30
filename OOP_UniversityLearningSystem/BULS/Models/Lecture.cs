using System;

namespace Buls.Models
{
    public class Lecture
    {
        private const int LectureNameDefaultLength = 3;
        
        public string lectureName;

        public Lecture(string lectureName)
        {
            this.Name = lectureName;
        }

        public string Name
        {
            get
            {
                return this.lectureName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The lecture name cannot be empty.");
                }

                if (value.Length < LectureNameDefaultLength)
                {
                    throw new ArgumentException(string.Format("The lecture name must be at least {0} symbols long.",
                        LectureNameDefaultLength));
                }
                
                this.lectureName = value;
            }
        }
    }
}
