using System.Collections.Generic;
using GameBesta.LogicServices;
using GameBesta.Model;
using System;

namespace GameBesta.Controllers {
    class AController {
        public List<Spyder> Spyders { get; set; } = new List<Spyder>();
        public Mob Spyder { get; set; }
        public List<Food> PiecesOfFood { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public Player Player { get; set; }
        public ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        public string[,] Table1 { get; set; }
        public string[,] auxTable { get; set; } // << FRESH TABLE             
        public PosAndChar PosAndChar { get; set; }
        public ScoreAndBonusAcc ScoreAndBonus { get; set; } = new ScoreAndBonusAcc(0, 0);
        public DateTime startingTime { get; set; }
        public CommandAndClickTime commandAndClickTime { get; set; }

        public AController() {
            Table1 = Table.setTable(); // setTable method returns a string[] array
        }

        public AController(Player player, List<Spyder> spyders, List<Food> piecesOfFood, DateTime startingTime) {
            Spyders = spyders;
            PiecesOfFood = piecesOfFood;
            Player = player;
            this.startingTime = startingTime;

            Table1 = Table.setTable(); // setTable method returns a string[] array
            auxTable = Table.setTable(); // FRESH TABLE
        }        
        
        public void AddNewFood(Position pos) {
            PiecesOfFood.Add(new Food(pos));
        }

        public string[,] RefreshTable() { // << IMPORTANT!!!
            return Table.setTable();
        }        

        public void AddMobs(Spyder mob) { //<< AFTER! this responsability is in the wrong place
            Spyders.Add(mob);
        }

        public void RemoveMobs(Spyder mob) {
            Spyders.Remove(mob);
        }        
    }
}
