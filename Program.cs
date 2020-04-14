using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace ClubPenguinBot
{
    class Program
    {
        static void Main(string[] args)
        {
            int numAccounts = getNumAccounts();
            CPAccount[] accounts = new CPAccount[numAccounts];

            for (int i = 0; i < numAccounts; i++)
            {
                accounts[i] = new CPAccount(i);
                Console.WriteLine("Created bot number {0}", i);
            }

            while (true)
            {
                foreach (CPAccount acc in accounts)
                {
                    acc.runNextAction();
                }
            }

        }

        static int getNumAccounts()
        {
            Console.WriteLine("How many accounts would you like to bot?");
            string input = Console.ReadLine();
            return Convert.ToInt32(input);
        }
    }
}
