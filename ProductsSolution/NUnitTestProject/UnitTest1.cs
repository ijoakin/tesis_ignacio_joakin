using NUnit.Framework;

namespace Tests
{

    
    public class Tests
    {
        
        public Tests()
        {

        }
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(11, 2, false)]
        [TestCase(1, 2, false)]
        [TestCase(3, 2, false)]
        [TestCase(2, 2, true)]
        [TestCase(4, 2, false)]
        [TestCase(6, 2, false)]
        public void Test1(int number1, int number2, bool result)
        {
            Assert.AreEqual(number1 == number2, result);
        }

        
    }
}