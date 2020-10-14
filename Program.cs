using System;
using System.Diagnostics;
using System.Threading;

namespace GameTime
{
    class Program
    {
        static void Main(string[] args)
        {
            InputOutputHandler inputOutputHandler = new CSVHandler(@"HighscoreRecord.csv");
            Highscore highscore = new Highscore();
            ConsoleKey choise;
            string[] highestScores = inputOutputHandler.ReadFile();
            foreach (string player in highestScores) // går att ha som static metod
            {
                string[] values = player.Split(",");
                highscore.AddNewHighscore(new Player(values[1], double.Parse(values[0])));
            }
            Console.WriteLine("HIGH sCORE");
            for (int i = 0; i < 10 && i < highscore.GetTopList.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + highscore.GetTopList[i].Name + "Score: " + highscore.GetTopList[i].Time);
            }

            do
            {
                Stopwatch stopwatch = new Stopwatch();
                Random random = new Random();

                Console.WriteLine("Tryck på en knapp för att starta");
                Console.ReadKey(true); // = skriver ej ut knapptryck
                Console.WriteLine("Vänta lite...");
                Thread.Sleep(random.Next(500, 4000));

                Console.WriteLine("Tryck igen NU! (valfri knapp)");
                stopwatch.Start();

                ClearKeyBuffer();
                Console.ReadKey(true);
                stopwatch.Stop();

                int time = (int) stopwatch.Elapsed.TotalMilliseconds; //konverterar en double till int
                Console.WriteLine($"Din rektionstid var: {time} ms!");

                Console.WriteLine("Vad heter du?");
                string name = Console.ReadLine();
                highscore.AddNewHighscore(new Player(name, time));

                Console.WriteLine("Tryck på en knapp för att börja om, avsluta med Q");
                choise = Console.ReadKey(true).Key;
            } while (ConsoleKey.Q != choise);
            inputOutputHandler.WriteToFile(highscore.GetTopList);
        }
        static void ClearKeyBuffer() // löser fusket med knappslag, tömmer tidigare tryck
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}