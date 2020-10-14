namespace GameTime
{
    public class Player
    {
        private string name;
        private double time;

        public double Time
        {
            get
            {
                return time;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        public Player(string name, double time)
        {
            this.name = name;
            this.time = time;
        }

    }
}