
namespace GameBesta.Model {
    class Position {
        public int X { get; set; }
        public int Y { get; set; }

        public Position() {
        }

        public Position(int x, int y) {
            X = x;
            Y = y;
        }

        public void changePos(Position pos) {
            X = pos.X;
            Y = pos.Y;
        }
    }
}
