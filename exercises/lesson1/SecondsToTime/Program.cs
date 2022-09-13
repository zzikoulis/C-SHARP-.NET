using System;

namespace SecondsToTime
{   
    /// <summary>
    /// Διαβάζει από τον χρήστη έναν αριθμό δευτερολέπτων και εκτυπώνει το
    /// αντίστοιχο διάστημα σε Μέρες, Ώρες, Λεπτά και Δευτερόλεπτα
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DAY_SECONDS = 24 * 60 * 60;
            const int HOUR_SECONDS = 60 * 60;
            const int MINUTE_SECONDS = 60;

            Console.WriteLine("Please insert total seconds and press Enter");
            if (ulong.TryParse(Console.ReadLine(), out ulong totalSeconds))
            {
                Console.WriteLine("Seconds: {0} are Days: {1}, Hours: {2}, Minutes: {3}, Seconds: {4}", totalSeconds, totalSeconds / DAY_SECONDS, (totalSeconds % DAY_SECONDS) / HOUR_SECONDS, (totalSeconds % HOUR_SECONDS) / MINUTE_SECONDS, totalSeconds %  MINUTE_SECONDS);
                return;
            }

            Console.WriteLine("Please insert total seconds as integer. Please try again.");
        }
    }
}