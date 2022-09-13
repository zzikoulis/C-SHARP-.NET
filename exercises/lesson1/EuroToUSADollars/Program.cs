using System;

namespace EuroToUSADollars
{   
    /// <summary>
    /// Διαβάζει από τον χρήστη ποσό σε ευρώ (αν είναι δεκαδικός χρησιμοποιούμε το ,)
    /// και επιστρέφει το αντίστοιχο ποσό σε Δολλάρια ΗΠΑ
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            const int EXCHANGE_IN_CENTS = 116;

            Console.WriteLine("Please insert amount in Euros and press Enter");
            if (float.TryParse(Console.ReadLine(), out float amount))
            {
                Console.WriteLine("The equivalent amount in USA Dollars is: {0} Dollars and {1} cents", (int)(amount * EXCHANGE_IN_CENTS / 100), (int)(amount * EXCHANGE_IN_CENTS) % 100);
                return;
            }

            Console.WriteLine("Νο acceptable amount. Please try again.");
        }
    }
}