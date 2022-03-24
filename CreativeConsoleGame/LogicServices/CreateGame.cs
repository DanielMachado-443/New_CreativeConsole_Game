using System.Collections.Generic;
using GameBesta.Model;
using GameBesta.Controllers;
using System;

namespace GameBesta.LogicServices {
    class CreateGame {
        public AController CreateAGame() {            

            Player player1 = new Player("Daniel",
                new Position(9, 4),               
                100,
                2,
                new Weapon(10, "Ace"));

            DateTime startingTime = DateTime.Now; // << used to count on the score

            List<Spyder> spyders = new List<Spyder>();
            spyders.Add(new Spyder(new Position(7, 2)));
            spyders.Add(new Spyder(new Position(2, 2)));
            spyders.Add(new Spyder(new Position(15, 4)));
            spyders.Add(new Spyder(new Position(5, 6)));
            spyders.Add(new Spyder(new Position(11, 8)));
            spyders.Add(new Spyder(new Position(3, 6)));
            spyders.Add(new Spyder(new Position(9, 10)));
            spyders.Add(new Spyder(new Position(12, 8)));
            spyders.Add(new Spyder(new Position(8, 6)));
            spyders.Add(new Spyder(new Position(2, 10)));
            spyders.Add(new Spyder(new Position(7, 8)));
            spyders.Add(new Spyder(new Position(2, 4)));
            spyders.Add(new Spyder(new Position(15, 4)));
            spyders.Add(new Spyder(new Position(5, 2)));
            spyders.Add(new Spyder(new Position(11, 6)));
            spyders.Add(new Spyder(new Position(3, 4)));            
            spyders.Add(new Spyder(new Position(12, 2)));
            spyders.Add(new Spyder(new Position(8, 8)));
            spyders.Add(new Spyder(new Position(2, 8)));
            spyders.Add(new Spyder(new Position(2, 16)));
            spyders.Add(new Spyder(new Position(15, 14)));
            spyders.Add(new Spyder(new Position(5, 12)));
            spyders.Add(new Spyder(new Position(11, 10)));
            spyders.Add(new Spyder(new Position(3, 14)));
            spyders.Add(new Spyder(new Position(12, 8)));
            spyders.Add(new Spyder(new Position(8, 16)));
            spyders.Add(new Spyder(new Position(2, 10)));
            spyders.Add(new Spyder(new Position(5, 8)));
            spyders.Add(new Spyder(new Position(9, 12)));
            spyders.Add(new Spyder(new Position(3, 16)));
            spyders.Add(new Spyder(new Position(6, 10)));
            spyders.Add(new Spyder(new Position(9, 14)));
            spyders.Add(new Spyder(new Position(3, 10)));

            List<Food> piecesOfFood = new List<Food>();
            piecesOfFood.Add(new Food(new Position(6, 12)));

            AController thisController = new AController(player1, spyders, piecesOfFood, startingTime);
            thisController.Table1[9, 4] = thisController.Player.ToString();

            for (int x = 0; x < 18; x++) { // iterating within all Table
                for (int y = 0; y < 19; y++) {
                    foreach(Spyder spd in thisController.Spyders) { // iterating within all spyders collection, checking the possible match inside of each table position
                        if(spd.Position.X == x && spd.Position.Y == y) {
                            thisController.Table1[x, y] = spd.ToString(); // << puting the spyders on the table (without render)
                        }
                    }                    
                }
            }

            return thisController;
        }
    }
}
