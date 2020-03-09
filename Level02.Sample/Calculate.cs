using System;
using System.Collections.Generic;
using System.Text;

namespace Level02.Sample
{
    public class Calculate
    {
        private int Add(int a, int b)
        {
            return a + b;
        }

        internal static int AddStatic(int a, int b)
        {
            return a + b;
        }

        internal int Mix(int first, int second, int third)
        {
            return (first + second) / third;
        }
    }
}