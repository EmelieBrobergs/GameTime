using System.Collections.Generic;
using System.IO;

namespace GameTime
{
    public class CSVHandler : InputOutputHandler
    {
        private string filePath;
        public CSVHandler(string filePath)
        {
            this.filePath = filePath;
        }
        public override string[] ReadFile() //öppna och läs denna fil
        {
            return File.ReadAllLines(filePath);
        }

        public override void WriteToFile(List<Player> dataToSAve)
        {
            //throw new System.NotImplementedException();
            using StreamWriter writer = new StreamWriter(filePath); // using behövs men varför ??
            foreach (Player player in dataToSAve)
            {
                writer.WriteLine(player.Time + ", " + player.Name);
            }
        }
    }
}