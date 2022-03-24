using System.Collections.Generic;

namespace GameBesta.Model {
    class Spyder : Mob{
        public Position Position { get; set; }        
        private State State { get; set; } = State.Agressive;
        public Spyder(Position position) {
            Position = position;            
        }

        public void changePosition(Position newPos) {
            Position = newPos;
        }

        public void changeState(State state) {
            State = state;
        }

        public override double Damagee() {
            return State == 0 ? Damage * 1.5 : Damage * 0.5;
        }

        public override string ToString() {
            return "!#!";
        }
    }
}
