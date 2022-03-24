namespace GameBesta.Model {
    class ScoreAndBonusAcc {
        public int Score { get; set; }
        public int AccBonus { get; set; }

        public ScoreAndBonusAcc(int score, int accBonus) {
            Score = score;
            AccBonus = accBonus;
        }
    }
}
