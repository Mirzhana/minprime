using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }
        static bool IsPrime(string s)
        {   //convert from string to integer
            int x = int.Parse(s);
            //initial counter
            int cnt = 0;

            for (int j = 2; j <= Math.Sqrt(x); j++)
            {
                if (x % j == 0)
                {
                    cnt++;//if number is divided to some another number without reminder, counter increase 
                }
            }

            return cnt == 0 && x != 1; //IsPrime is true in case counter is still 0
        }
        private static void F1()
        {
            //Create new file where we will input our numbers
            FileStream fsread = new FileStream("input1.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //Create new file where result will be written
            FileStream fswrite = new FileStream("result.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fsread); //read numbers from input.txt 
            StreamWriter sw = new StreamWriter(fswrite);//write result to result.txt
            //Make a string from written numbers
            string line = sr.ReadLine();
            string[] array = line.Split(' ');// split numbers in an array with the Space sign

            int min = 10000; //initial value for comparison
            //Run by each element of an array
            for (int i = 0; i < array.Length; i++)
            {   //For all prime numbers check is it minimum or not
                if (IsPrime(array[i]))
                {
                    int Element = int.Parse(array[i]);//convert from string to integer
                    if (Element < min)// if number is less than min value, then it is minimum
                        min = Element;
                }
            }
            //Write the result to result.txt that was created
            sw.WriteLine(min);
            //Close all files
            sr.Close();
            sw.Close();
            fsread.Close();
            fswrite.Close();
        }
    }
}