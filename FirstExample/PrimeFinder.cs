using System;
using System.Linq;

namespace _01_FirstExample
{
    public class PrimeFinder
    {
        public bool IsPrime(int candidate)
        {
            if (candidate == 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= (int)Math.Sqrt(candidate) - 1; i++)
                {
                    if (candidate % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //public bool IsPrime(int candidate)
        //{
        //    var isPrime = candidate > 1
        //                  && candidate != 1
        //                  && !Enumerable.Range(2, (int)Math.Sqrt(candidate) - 1)
        //                        .Any(i => candidate % i == 0);
        //    return isPrime;
        //}
    }
}
