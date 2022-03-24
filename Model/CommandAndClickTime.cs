namespace GameBesta.Model {
    class CommandAndClickTime {
        public char letter { get; set; }
        public int clickTime { get; set; }

        public CommandAndClickTime (char letter, int clickTime) {
            this.letter = letter;
            this.clickTime = clickTime;
        }
    }
}
