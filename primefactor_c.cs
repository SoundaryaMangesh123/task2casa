// could ouput 1222334 in 4 seconds
//upto 9999 <1 second
// works upto 10 power 7

//  using Sieve of Eratosthenes method to first store all the prime factor sof each number and later returns it
// Time Complexity is : O(nloglogn) 
using System;
using System.Collections;
namespace userInput
{
    class myclass
    {
        static int max_value = 100001; //  setting up the maximum value to store all the smallest prime  numbers

        // stores smallest prime factor for every number 
        static int[] spf = new int[max_value];

        // Calculating SPF (Smallest Prime Factor) for every 
        // number till MAXN. 
        // Time Complexity : O(nloglogn) 
        static void sieve_of_eratosthenes()
        {
            spf[1] = 1;
            for (int i = 2; i < max_value; i++)

                // marking smallest prime factor for every 
                // number to be itself. 
                spf[i] = i;

            // separately marking spf for every even 
            // number as 2 
            for (int i = 4; i < max_value; i += 2)
                spf[i] = 2;

            for (int i = 3; i * i < max_value; i++)
            {
                // checking if i is prime 
                if (spf[i] == i)
                {
                    // marking SPF for all numbers divisible by i 
                    for (int j = i * i; j < max_value; j += i)

                        // marking spf[j] if it is not  
                        // previously marked 
                        if (spf[j] == j)
                            spf[j] = i;
                }
            }
        }
        //time complexity  for the above eqn is Ologn
        
        static ArrayList getFactorization(int x)
        {
            ArrayList output_arr = new ArrayList();
            while (x != 1)
            { // calculating the 
                output_arr.Add(spf[x]);
                x = x / spf[x];
            }
            return output_arr;
        }

        // Driver code 
        public static void Main()
        {
            // precalculating Smallest Prime Factor 
            sieve_of_eratosthenes();
            Console.Write("Enter integer value number: ");
            string y = Console.ReadLine();
            // Converting input to integer type 
            int x = Convert.ToInt32(y);

            
            ArrayList ans = getFactorization(x);

            for (int i = 0; i < ans.Count; i++)
                Console.Write(ans[i] + " ");
            Console.WriteLine("");
        }
    }
}