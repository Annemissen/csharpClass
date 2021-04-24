namespace TestingBirthdate
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int getCenturyFromCPR(int CPR)
        {
            int digit7 = (CPR % 10000) / 1000;
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
        }
    }
}
