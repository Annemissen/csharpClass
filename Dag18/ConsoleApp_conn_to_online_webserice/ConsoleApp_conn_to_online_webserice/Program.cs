using ConsoleApp_conn_to_online_webserice.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_conn_to_online_webserice
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorSoapClient csc = new CalculatorSoapClient();
            int sum = csc.Add(78, 3);
            Console.WriteLine($"Resultat: {sum}");
            Console.ReadKey();
        }
    }
}
