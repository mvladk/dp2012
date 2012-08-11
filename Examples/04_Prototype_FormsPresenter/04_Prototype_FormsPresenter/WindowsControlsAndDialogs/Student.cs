using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsControlsAndDialogs
{
    public enum eStudentLevel
    {
        Failed,
        Regular,
        Excellent
    }

    public class Student
    {
        public event EventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public static Student CreateFromLine(string i_Line)
        {
            Student retStudent = new Student();
            string[] studentParts = i_Line.Split(',');
            string[] nameParts = studentParts[0].Split(' ');
            retStudent.FirstName = nameParts[0];
            retStudent.LastName = nameParts[1];
            retStudent.Phone = studentParts[2];
            retStudent.Age = int.Parse(studentParts[3]);
            retStudent.Level = (eStudentLevel)int.Parse(studentParts[1]);

            return retStudent;
        }

        private string m_FirstName;

        public string FirstName
        {
            get { return m_FirstName; }
            set
            {
                if (m_FirstName != value)
                {
                    m_FirstName = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        private string m_LastName;

        public string LastName
        {
            get { return m_LastName; }
            set
            {

                if (m_LastName != value)
                {
                    m_LastName = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        private string m_Phone;

        public string Phone
        {
            get { return m_Phone; }
            set
            {

                if (m_Phone != value)
                {
                    m_Phone = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        private int m_Age;

        public int Age
        {
            get { return m_Age; }
            set
            {
                if (m_Age != value)
                {
                    m_Age = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }

        private eStudentLevel m_Level;

        public eStudentLevel Level
        {
            get { return m_Level; }
            set
            {
                if (m_Level != value)
                {
                    m_Level = value;
                    OnPropertyChanged(EventArgs.Empty);
                }
            }
        }
    }
}
