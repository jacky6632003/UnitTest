using System;
using System.Collections.Generic;
using System.Text;

namespace Level01.Sample
{
    public class Calculator
    {
        public int Add(int first, int second)
        {
            var result = first + second;
            return result;
        }

        public double Mix(int first, int second, int third)
        {
            if ((first + second).Equals(0))
            {
                throw new ArgumentException("first + second 總和不可為零");
            }

            if (third.Equals(0))
            {
                throw new ArgumentException("third 不可為零");
            }

            var result = (first + second) / third;
            return result;
        }
    }
}