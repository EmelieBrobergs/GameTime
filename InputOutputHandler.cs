using System.Collections.Generic;
namespace GameTime
{
    public abstract class InputOutputHandler
    {
        public abstract string[] ReadFile();
        public abstract void WriteToFile(List<Player> dataToSAve);
    }
}