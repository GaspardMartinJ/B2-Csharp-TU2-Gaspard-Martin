using ProjetPourTU.Services;

namespace ProjetPourTU.Tests
{
    public class MathsServiceTest
    {
        private MathsService _testedClass;
        [SetUp]
        public void Setup()
        {
            _testedClass= new MathsService();
        }

        [TestCase(0, 1, 0)]
        [TestCase(10, 2, 5)]
        [TestCase(-6, -2, 3)]
        [TestCase(6, -2, -3)]
        public void MultiplierTest(int expected, int a, int b)
        {
            int res = _testedClass.Multiplier(a, b);
            Assert.That(res, Is.EqualTo(expected), "erreur");
        }
    }
}