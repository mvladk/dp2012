using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication10
{
    public enum eStudentLevel
    {
        Regular,
        Failed,
        Excellent
    }

    class PartialStudent_
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Age { get; set; }
        public eStudentLevel Level { get; set; }
        public string Phone { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1},   ID = {5},   Email = {6}", 
                FirstName, LastName, Age, Phone, Level, ID, Email);
        }

        public Student()
        {
        }

        public Student(string i_LineToParse)
        {
            string[] parts = i_LineToParse.Split(',');
            ID = parts[1];
            FirstName = parts[0].Split(' ')[0];
            LastName = parts[0].Split(' ')[1];
            Email = parts[2];
        }
    }
}
