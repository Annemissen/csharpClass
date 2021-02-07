using System;

namespace ConsoleAppWithError
{
    class Program
    {
        private static void MyMethodWithError(int num = 0)
        {
            throw new Exception("MyMethodWithError: Something went wrong-ish");
        }

        public static void MyNormalMethod(int num = 0)
        {
            try
            {
                MyMethodWithError();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("The 'try catch' is finished.");
            }
        }

        static void Main(string[] args)
        {
            MyNormalMethod();
        }
    }
}
