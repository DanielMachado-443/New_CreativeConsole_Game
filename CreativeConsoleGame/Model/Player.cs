using System.Collections.Generic;

namespace GameBesta.Model {
    class Player {
        private string name { get; set; }
        public Position Position { get; set; }
        private int Life { get; set; }
        private double speed { get; set; }
        private Weapon Weapon { get; set; }
        private List<Mob> mobs { get; set; } = new List<Mob>();

        public Player(string name, Position position, int life, double speed, Weapon weapon) {
            this.name = name;            
            Life = life;
            this.speed = speed;
            Weapon = weapon;
            Position = position;
        }

        public override string ToString() {
            return "´O`".ToString();
        }
    }
}
