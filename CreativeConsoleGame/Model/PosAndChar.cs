namespace GameBesta.Model {
    class PosAndChar {
        public char Character { get; set; }
        public Position Pos { get; set; }
        public bool Bonus { get; set; }

        public PosAndChar(char character, Position pos, bool bonus) {
            Character = character;
            Pos = pos;
            Bonus = bonus;
        }
    }
}
