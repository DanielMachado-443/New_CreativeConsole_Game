using System.Collections.Generic;

namespace GameBesta.Model {
    class Food : Mob {
        public Position Position { get; set; }
        
        public Food(Position position) {
            Position = position;
        }

        public void changePosition(Position newPos) {
            Position = newPos;
        }

        public override double Damagee() {
            return 0;
        }

        public override string ToString() {
            return "!$!";
        }
    }
}