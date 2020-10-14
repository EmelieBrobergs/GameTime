using System.Collections.Generic;
using System.Linq; // för OrderBy

namespace GameTime
{
    public class Highscore
    {
        private List<Player> players;

        public List<Player> GetTopList
        {
            get
            {
                return players;
            }
        }

        public Highscore()
        {
            players = new List<Player>();
        }
        public void AddNewHighscore(Player player)
        {
            players.Add(player);
            SortList();
        }

        public void SortList()
        {
            players = players.OrderBy(player => player.Time).ToList();
        }
    }
}