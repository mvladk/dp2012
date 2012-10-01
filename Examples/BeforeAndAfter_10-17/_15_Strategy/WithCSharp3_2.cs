using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_Strategy
{
    public static class IntArrayExtensionMethods
    {
        public static int Sum(this int[] i_Nums)
        {
            int retVal = 0;
            foreach (int num in i_Nums)
            {
                retVal += num;
            }

            return retVal;
        }

        // This is the more generic and effective version of this method:
        // public static IEnumerable<R> Project<R, S>(this S[] i_Array, Func<S, R> i_ProjectionMedthod)
        public static R[] Project<R, S>(this S[] i_Array, Func<S, R> i_ProjectionMedthod)
        {
            R[] objects = new R[i_Array.Length];
            for (int i = 0; i < i_Array.Length; ++i)
            {
                objects[i] = i_ProjectionMedthod(i_Array[i]);
            }

            return objects;
        }
    }

    class WithCSharp3_2
    {
        public static void Run()
        {
            NumbersManipulator manipulator1 =
              new NumbersManipulator(nums => nums.Sum().ToString());

            NumbersManipulator manipulator2 =
              new NumbersManipulator(nums => string.Join(";", nums.Project(num => num.ToString())));

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(manipulator1.Manipulate(numbers));
            Console.WriteLine(manipulator2.Manipulate(numbers));

            Run2();
        }

        public class NumbersManipulator
        {
            /// generic delegate accepting an int array and returning a string
            private readonly Func<int[], string> r_ManipulateFunction;

            public NumbersManipulator(Func<int[], string> i_ClickFunction)
            {
                r_ManipulateFunction = i_ClickFunction;
            }

            public string Manipulate(int[] i_Nums)
            {
                return r_ManipulateFunction(i_Nums);
            }
        }

        public static void Run2()
        {
            NumbersManipulator2 manipulator1 =
              new NumbersManipulator2(nums => nums.Sum().ToString(), "Sum them!");

            NumbersManipulator2 manipulator2 =
              new NumbersManipulator2(nums => string.Join(" ", nums.Select(num => num.ToString()).ToArray()), "Concatenate");

            IEnumerable<int> numbers = System.Linq.Enumerable.Range(1, 10);
            Console.WriteLine(manipulator1.Manipulate(numbers));
            Console.WriteLine(manipulator2.Manipulate(numbers));
        }

        public class NumbersManipulator2
        {
            /// generic delegate accepting a generic enumerable and returning a string
            private readonly Func<IEnumerable<int>, string> r_ManipulateFunction;
            /// auto-prop with a private setter
            public string Text { get; private set; }

            public NumbersManipulator2(Func<IEnumerable<int>, string> i_ManipulateFunction, string i_Text)
            {
                r_ManipulateFunction = i_ManipulateFunction;
                Text = i_Text;
            }

            public string Manipulate(IEnumerable<int> i_Nums)
            {
                return r_ManipulateFunction(i_Nums);
            }
        }
    }
}
