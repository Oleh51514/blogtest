using System;
using System.Collections.Generic;
using System.Text;

namespace blogtest.DAL2.Entities
{
    class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; } // внешний ключ
        public Team Team { get; set; }  // навигационное свойство
    }
}
