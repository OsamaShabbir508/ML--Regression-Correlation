using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorelationsAndRegression
{
    class CorelationsRegression
    {
        List<Double> x = new List<Double>();
        List<Double> y = new List<Double>();
        List<Double> ybr = new List<Double>();
        double numerator, denomerator; double xmean, ymean; double Rss, Tss, R2,RS,TS;

        int nofobs;double b, a;
        double SallXSallY;
        double sumofXintoY;
        double sumofX; double sumofY; double SquareSumofX; double SquareSumofY; double sumofYsquare;
        double sumofXsquare;
        double corelation;
        public void Addinlist()
        {
            Console.WriteLine("plz tell me the size of observations::");
            nofobs = int.Parse(Console.ReadLine());
            Console.WriteLine("PLZ GIVE THE THE NUMBER OF OBSERVATIONS AT X:::");

            for (int i = 0; i < nofobs; i++)
            { double value;
                value = Convert.ToDouble(Console.ReadLine());
                x.Add(value); }

            Console.WriteLine("PLZ GVIVE THE NUMBER OF OBSERVATIONS AT Y:::");
            for (int i = 0; i < nofobs; i++)
            {
                double value;
                value = Convert.ToDouble(Console.ReadLine());
                y.Add(value);
            }
            for (int i = 0; i < nofobs; i++)
            {
                sumofX += x.ElementAt(i);
                sumofY += y.ElementAt(i);

            }

            SallXSallY = sumofX * sumofY;
            for (int i = 0; i < nofobs; i++)
            {
                sumofXintoY += (x.ElementAt(i)) * (y.ElementAt(i));

            }
            SquareSumofX = Math.Pow(sumofX, 2);
            SquareSumofY = Math.Pow(sumofY, 2);
            for (int i = 0; i < nofobs; i++)
            {
                sumofXsquare += Math.Pow((x.ElementAt(i)), 2);
                sumofYsquare += Math.Pow((y.ElementAt(i)), 2);

            }
            Console.WriteLine(" CONGRATZ ALL THE NECESSARY STEPS AND CALCULATIONS DONE::");
        }
        public double FindCorelation() {

            numerator = (nofobs * sumofXintoY) - (SallXSallY);
            denomerator = (Math.Sqrt((nofobs * sumofXsquare) - SquareSumofX)) * (Math.Sqrt((nofobs * sumofYsquare) - SquareSumofY));
            double r = numerator / denomerator;
            corelation = r;
            return r;
        }
        public void LeastSquareRegression ()
            {
            if (corelation < .50)
            {
                Console.WriteLine("It can be concluded that there is very low relations between the two sets:: no need to further calculations");
               // return 0.0;
            }
            else
            {
                Console.WriteLine(" You can calculate because relation is gretaer than .50:  ");
                b = corelation * (Math.Sqrt(sumofYsquare / sumofXsquare));
                xmean = (sumofX / nofobs);
                ymean = (sumofY / nofobs);
                a = ymean - b * xmean;
                Console.WriteLine("b: "+b);
                Console.WriteLine("a :"+a);
                Console.WriteLine("this is all the Y Values after least square regression Equatins  Y'=bX+a  :");
                for (int i = 0; i < nofobs; i++)
                {
                    double ybr = (b * x.ElementAt(i)) + a;
                    this.ybr.Add(ybr);
                    Console.WriteLine("Y'= b( " + x.ElementAt(i) + " ) + a= " + this.ybr.ElementAt(i));
                    RS = y.ElementAt(i) - this.ybr.ElementAt(i);
                    Rss += Math.Pow(RS, 2);
                    TS = y.ElementAt(i) - ymean;
                    Tss += Math.Pow(TS, 2);
                }

                    R2 = 1 - (Rss / Tss);
                    if (R2 > .5)
                    {
                        Console.WriteLine("Your R-Square is : " + R2 + " It shows that this is the best fit model. best relation");

                    }
                    else
                    {
                        Console.WriteLine("Your R-Square is : " + R2 +" This shows the thinner relations,so not best fit Line");
                    }



                        

                

                


            }
            
           
            }




    }
}
