namespace TimeToSeconds
{
    /// <summary>
    /// Διαβάζει από τον χρήστη Μέρες, Ώρες, Λεπτά και Δευτερόλεπτα
    /// και επιστρέφει τον συνολικό αριθμό των αντίστοιχων δευτερολέπτων
    /// </summary>
    internal class Program
    {  
        static void Main(string[] args)
        {
            const int DAY_SECONDS = 24 * 60 * 60;
            const int HOUR_SECONDS = 60 * 60;
            const int MINUTE_SECONDS = 60;

            Console.WriteLine("Please insert Days, Hours, Minutes and Seconds as integers and press Enter after every insertion");
            if (int.TryParse(Console.ReadLine(), out int days) && int.TryParse(Console.ReadLine(), out int hours) && int.TryParse(Console.ReadLine(), out int minutes) && int.TryParse(Console.ReadLine(), out int seconds))
            {
                Console.WriteLine("Total Seconds are: {0:N0}", days * DAY_SECONDS + hours * HOUR_SECONDS + minutes * MINUTE_SECONDS + seconds);
                return;
            }

            Console.WriteLine("Please insert only integers. Please try again.");
        }
    }
}