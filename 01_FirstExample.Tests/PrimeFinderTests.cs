using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace _01_FirstExample.Tests
{
    [TestFixture]
    public class PrimeFinderTests
    {
        [Test]
        public void Returns_False_For_One()
        {
            var primeFinder = new PrimeFinder(); //Arrange

            var result = primeFinder.IsPrime(1); //Act

            Assert.IsFalse(result); //Assert
        }

        #region Negative numbers
        [Test, Timeout(10), Ignore]
        public void Returns_False_For_Negative_One()
        {
            var primeFinder = new PrimeFinder();
            var result = primeFinder.IsPrime(-1);
            Assert.IsFalse(result);
        }
        #endregion

        #region Some Numbers
        [Test]
        public void Test_Some_Prime_Numbers()
        {
            var primes = new List<int> { 2, 3, 5, 7, 11, 13, 17 };
            var primeFinder = new PrimeFinder();

            foreach (var prime in primes)
            {
                Assert.IsTrue(primeFinder.IsPrime(prime));
            }
        }

        [Test]
        public void Returns_True_For_Three()
        {
            var primeFinder = new PrimeFinder();
            var result = primeFinder.IsPrime(3);
            Assert.IsTrue(result);
        }

        [Test]
        public void Returns_False_For_Twelve()
        {
            var primeFinder = new PrimeFinder();
            var result = primeFinder.IsPrime(12);
            Assert.IsFalse(result);
        }
        #endregion
    }
}
