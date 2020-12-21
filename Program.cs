using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorelationsAndRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            CorelationsRegression c = new CorelationsRegression();
            c.Addinlist();
            Console.WriteLine("corelation coefficent::  "+ c.FindCorelation());
            c.LeastSquareRegression();
           

            Console.ReadKey();


        }
    }
}
