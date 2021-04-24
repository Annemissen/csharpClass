using NUnit.Framework;

namespace TestingBirthdate.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        //[TestCase(19,2112714811)]
        ////[TestCase(, 2112714811)]
        //public void getCenturyFromCPRTest(int expectedCentury, int CPR)
        //{
        //    int result = Program.getCenturyFromCPR(CPR);
        //    Assert.AreEqual(result, expectedCentury);
        //}

        [TestCase(19, 2112713811)]
        public void getCenturyFromCPR_Digit7_LeEq3Test(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }

        [TestCase(20, 2112114811)]
        public void getCenturyFromCPR_Digit56_under36Test(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }

        [TestCase(19, 2112714811)]
        public void getCenturyFromCPR_Digit56_over36Test(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }


        [TestCase(20, 2112718811)]
        public void getCenturyFromCPR_Digit7_LeEq8Test(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }

        [TestCase(20, 2112369811)]
        public void getCenturyFromCPR_Digit56_LeEq36Test(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }

        [TestCase(19, 2112379811)]
        public void getCenturyFromCPR_Digit56_Gr36Test(int expectedCentury, int CPR)
        {
            int result = Program.getCenturyFromCPR(CPR);
            Assert.AreEqual(result, expectedCentury);
        }

    }
}
