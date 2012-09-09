using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;
using System.Collections;

namespace WindowsFormsApplication10
{
    public static class ArrayUtils
    {
        public static IEnumerable<T> FindAllItems<T>(this IEnumerable<T> i_Items, Func<T, bool> i_Predicate)
        {
            foreach (T item in i_Items)
            {
                if (!i_Predicate(item))
                {
                    continue;
                }

                yield return item;
            }
        }

        public static IEnumerable<P> Project<S, P>(this IEnumerable<S> i_ToProject, Func<S, P> i_Projector)
        {
            foreach (S item in i_ToProject)
            {
                yield return i_Projector(item);
            }
        }
    }

    public class Comparer<T> : IComparer<T>
    {
        public Func<T, T, int> CompareFunc { get; set; }
        public int Compare(T x, T y)
        {
            return CompareFunc(x, y);
        }
    }

    public partial class FormMain : Form
    {
        private StudentsDB m_StudentsDB = new StudentsDB();

        public FormMain()
        {
            InitializeComponent();

            m_StudentsDB.LoadFromFile(@".\Resources\MTADPC10StudentsList_.csv");

            var anonymousPartialYoungs =
                m_StudentsDB.Students.FindAll(student => student.Age < 22).ProjectAll(
                regularStudent => new { regularStudent.FirstName, regularStudent.Age });

            foreach (var partial in anonymousPartialYoungs)
            {
                listBoxDB.Items.Add(partial);
            }

            listBoxDB.DataSource = m_StudentsDB.Students;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            dataGridResults.DataSource = null;
            listBoxResult.DataSource = null;
            listBoxResult.Items.Clear();

            Student toFind = m_StudentsDB.Find(student => student.FirstName.StartsWith(textBoxFirstName.Text));
            if (toFind != null)
            {
                listBoxResult.DataSource = new List<Student> { toFind };
            }

            dataGridResults.DataSource = listBoxResult.Items;
        }

        private void buttonFindFast_Click(object sender, EventArgs e)
        {
            listBoxResult.DataSource = null;
            listBoxResult.Items.Clear();

            Student toFind = m_StudentsDB.BinarySearchFind(
                new Student { FirstName = textBoxFirstName.Text },
                (s1, s2) => s1.FirstName.CompareTo(s2.FirstName));

            if (toFind != null)
            {
                listBoxResult.DataSource = new List<Student> { toFind };
            }

            dataGridResults.DataSource = listBoxResult.Items;
        }

        private void buttonFilterBy_Click(object sender, EventArgs e)
        {
            listBoxResult.DataSource = null;
            dataGridResults.DataSource = null;
            listBoxResult.Items.Clear();

            var selected =  m_StudentsDB.Students
                .Where(student => student.FirstName.StartsWith(textBoxFirstName.Text))
                .Select(student => new { FName = student.FirstName, LName = student.LastName });

            foreach (var std in selected)
            {
                listBoxResult.Items.Add(std);
            }

            dataGridResults.DataSource = listBoxResult.Items;
        }

        private void buttonLinqQuery_Click(object sender, EventArgs e)
        {
            listBoxResult.DataSource = null;
            dataGridResults.DataSource = null;
            listBoxResult.Items.Clear();

            var selected = from student in m_StudentsDB.Students
                           where student.FirstName.StartsWith(textBoxFirstName.Text)
                           select new
                           {
                               FName = student.FirstName,                       /// different projection field name
                               EMailAddress = student.Email,                    /// different projection field name
                               IsYoung = (student.Age < 22),                    /// a new, calculated, field
                               student.Age                                      /// same field with the same name
                           };

            foreach (var result in selected)
            {
                listBoxResult.Items.Add(result);
            }

            dataGridResults.DataSource = listBoxResult.Items;
        }
    }


    public class PartialStudent
    {
        public string FirstName { get; set; }
        public float Age { get; set; }

        public override string ToString()
        {
            return FirstName;
        }
    }

    public static class ArrayExtensions
    {
        /// Non-yeilding extension method.
        public static T[] FindAll<T>(this T[] i_Array, Func<T, bool> i_Prdeicate)
        {
            List<T> all = new List<T>();
            foreach (T t in i_Array)
            {
                if (i_Prdeicate(t))
                {
                    all.Add(t);
                }
            }

            return all.ToArray();
        }

        /// Yeilding, generic, extension method.
        public static IEnumerable<T> FindAll<T>(this IEnumerable<T> i_Collection, Func<T, bool> i_Prdeicate)
        {
            foreach (T item in i_Collection)
            {
                if (i_Prdeicate(item))
                {
                    yield return item;
                }
            }
        }

        /// Yeilding extension method.
        //public static IEnumerable<P> ProjectAll<T, P>(this IEnumerable<T> theCollection, Func<T, P> i_ProjectionMethod)
        public static IEnumerable<P> ProjectAll<T, P>(this IEnumerable<T> i_Collection, Func<T, P> i_ProjectionMethod)
        {
            foreach (T t in i_Collection)
            {
                yield return i_ProjectionMethod(t);
            }
        }
    }

    public class StudentsDB
    {
        List<Student> m_Students = new List<Student>();

        public List<Student> Students { get { return m_Students; } }

        public Student Find(Predicate<Student> i_Predicate)
        {
            return m_Students.Find(i_Predicate);
        }

        public Student BinarySerachFind(Student i_ToFind, IComparer<Student> i_Comparer)
        {
            int idx = m_Students.BinarySearch(i_ToFind, i_Comparer);
            if (idx > 0)
            {
                return m_Students[idx];
            }
            else
            {
                return i_ToFind;
            }
        }

        public Student BinarySearchFind(Student i_ToFind, Func<Student, Student, int> i_CompareFunc)
        {
            int idx = m_Students.BinarySearch(i_ToFind, DynamicComparer<Student>.Comparing(i_CompareFunc));
            if (idx > 0)
            {
                return m_Students[idx];
            }
            else
            {
                return i_ToFind;
            }
        }

        public void Sort(Comparison<Student> i_ComparisonFunc)
        {
            m_Students.Sort(i_ComparisonFunc);
        }

        public void LoadFromFile(string i_FileName)
        {
            if (File.Exists(i_FileName))
            {
                m_Students.Clear();
                string[] students = File.ReadAllLines(i_FileName);
                foreach (string studentLine in students)
                {
                    Student currStudent = new Student(studentLine);
                    int idx = m_Students.BinarySearch(currStudent, 
                        DynamicComparer<Student>.Comparing(
                        (x, y) => x.FirstName.CompareTo(y.FirstName)));

                    /// The BinarySearch method returns the inverse of the index
                    /// in case the item is not in the collection
                    idx = idx > 0 ? idx : ~idx; 

                    m_Students.Insert(idx, currStudent);
                }
            }
        }
    }

    public sealed class FirstNameComparerStudent : IComparer<Student>
    {
        /// <summary>
        /// A static copy of the comparer to avoid the GC.
        /// </summary>
        public static readonly FirstNameComparerStudent Default = new FirstNameComparerStudent();

        static FirstNameComparerStudent() { }
        private FirstNameComparerStudent() { }

        public int Compare(Student x, Student y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }

    public sealed class DynamicComparer<T> : IComparer<T>
    {
        /// <summary>
        /// A static copy of the comparer to avoid the GC.
        /// </summary>
        public static readonly DynamicComparer<T> Default = new DynamicComparer<T>();

        static DynamicComparer() { }
        private DynamicComparer() { }

        public Func<T, T, int> CompareFunc { get; set; }

        public int Compare(T x, T y)
        {
            return CompareFunc(x, y);
        }

        public static DynamicComparer<T> Comparing(Func<T, T, int> i_CompareFunc)
        {
            Default.CompareFunc = i_CompareFunc;
            return Default;
        }
    }
}
