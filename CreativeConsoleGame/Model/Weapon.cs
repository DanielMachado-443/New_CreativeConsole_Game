namespace GameBesta.Model {
    class Weapon {
        public int Damage { get; set; }
        public string Type { get; set; }
        public Player Player { get; set; }

        public Weapon(int damage, string type) {
            Damage = damage;
            Type = type;            
        }

        public void addPlayer(Player player) {
            Player = player;
        }
    }
}
