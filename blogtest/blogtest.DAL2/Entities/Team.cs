using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.DAL2.Entities
{
    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public List<Player> Players { get; set; }
    }
}
