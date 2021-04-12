using NUnit.Framework;

namespace TestingBirthdate.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [TestCase(19,2112714811)]
        //[TestCase(, 2112714811)]
        public void getCenturyFromCPRTest(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }
    }
}

/*
 *          int digit7 = (CPR % 10000) / 1000;
            int digit56 = (CPR % 1000000) / 10000;

            if (digit7 <= 3)
                return 19;
            if (digit7 == 4)
                if (digit56 <= 36)
                    return 20;
                else
                    return 19;
            if (digit7 <= 8)
                return 20;
            if (digit56 <= 36)
                return 20;
            else
                return 19;
 */