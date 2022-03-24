using GameBesta.Controllers;
using GameBesta.Model;
using System;

namespace GameBesta.LogicServices {
    class GameLogics {

        public AController thatController = new AController();
        public CommandAndClickTime commandAndClickTime { get; set; } = new CommandAndClickTime('0', 0);
        public bool gameOver { get; set; } = false;
        public bool Bonus { get; set; } = false;

        public GameLogics() {
        }
        public GameLogics(AController controller) {
            thatController = controller;
        }        

        private void killEatenFood(Food fd) {
            for(int i = 0; i < thatController.PiecesOfFood.Count; i++) {
                if(thatController.PiecesOfFood[i].Position.X == fd.Position.X && thatController.PiecesOfFood[i].Position.Y == fd.Position.Y) {
                    thatController.PiecesOfFood.RemoveAt(i);
                }
            }            
        }

        private void createNewFood(Food fd) {            
            Random rnd = new Random();
            int x = rnd.Next(4, 15);
            int y = rnd.Next(2, 16);
            while (y % 2 != 0) {
                y = rnd.Next(2, 16);
            }                      
            Position pos = new Position(x, y);

            bool thatWhile = false;
            if(fd.Position == pos) {
                thatWhile = true;
            }
            while (thatWhile) {
                Random rnd2 = new Random();
                int xx = rnd2.Next(4, 15); 
                int yy = rnd2.Next(2, 16);
                while (yy % 2 != 0) {
                    yy = rnd2.Next(2, 16);
                }
                Position pos2 = new Position(xx, yy);
                if (fd.Position != pos2) {                    
                    thatController.AddNewFood(new Position(xx, yy));
                    thatWhile = false; // << no needed to be here
                    return;
                }                
            }            
            thatController.AddNewFood(new Position(x, y));            
        }

        private bool IsItPossibleToMoveThePlayer(char letter) {
            Bonus = false;

            bool[,] aux = new bool[18, 19];           

            if (letter == 'a') {
                if(commandAndClickTime.clickTime >= 15) {
                    gameOver = true;
                    return false;
                }
                if (thatController.Player.Position.Y - 2 >= 1) {
                    if ((thatController.Player.Position.Y - 2) % 2 == 0) { // just in case verification, not really necessary
                        foreach (Spyder spd in thatController.Spyders) {
                            if (thatController.Player.Position.X == spd.Position.X + 1 && thatController.Player.Position.Y - 2 == spd.Position.Y) {
                                gameOver = true;
                                return false;
                            }                            
                        }
                        foreach (Food fd in thatController.PiecesOfFood) {
                            if (thatController.Player.Position.X == fd.Position.X && thatController.Player.Position.Y - 2 == fd.Position.Y) {
                                Bonus = true;
                                Console.Beep(250, 75);
                                createNewFood(fd);
                                killEatenFood(fd);
                                return true;
                            }
                        }
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            else if (letter == 'd') {
                if (commandAndClickTime.clickTime >= 15) {
                    gameOver = true;
                    return false;
                }
                if (thatController.Player.Position.Y + 2 <= 17) {
                    if ((thatController.Player.Position.Y + 2) % 2 == 0) { // just in case of verification, not really necessary
                        foreach (Spyder spd in thatController.Spyders) {
                            if (thatController.Player.Position.X == spd.Position.X + 1 && thatController.Player.Position.Y + 2 == spd.Position.Y) {
                                gameOver = true;
                                return false;
                            }                            
                        }
                        foreach (Food fd in thatController.PiecesOfFood) {
                            if (thatController.Player.Position.X == fd.Position.X && thatController.Player.Position.Y + 2 == fd.Position.Y) {
                                Bonus = true;
                                Console.Beep(250, 75);
                                createNewFood(fd);
                                killEatenFood(fd);
                                return true;
                            }
                        }
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            else if (letter == 'w') {
                if (commandAndClickTime.clickTime >= 15) {
                    gameOver = true;
                    return false;
                }
                if (thatController.Player.Position.X - 1 >= 0) {
                    foreach (Spyder spd in thatController.Spyders) {
                        if (thatController.Player.Position.X - 1 == spd.Position.X + 1 && thatController.Player.Position.Y == spd.Position.Y) {
                            gameOver = true;
                            return false;
                        }
                    }
                    foreach (Food fd in thatController.PiecesOfFood) {
                        if (thatController.Player.Position.X - 1 == fd.Position.X && thatController.Player.Position.Y == fd.Position.Y) {
                            Bonus = true;
                            Console.Beep(250, 75);
                            createNewFood(fd);
                            killEatenFood(fd);
                            return true;
                        }
                    }
                    return true;
                }
                return false;
            }
            else if (letter == 's') {
                if (commandAndClickTime.clickTime >= 15) {
                    gameOver = true;
                    return false;
                }
                if (thatController.Player.Position.X + 1 <= 16) {
                    foreach (Food fd in thatController.PiecesOfFood) {
                        if (thatController.Player.Position.X + 1 == fd.Position.X && thatController.Player.Position.Y == fd.Position.Y) {
                            Bonus = true;
                            Console.Beep(250, 75);
                            createNewFood(fd);
                            killEatenFood(fd);
                            return true;
                        }
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public PosAndChar MovingThePlayer(CommandAndClickTime commandAndClickTime) {
            this.commandAndClickTime = commandAndClickTime;
            if (IsItPossibleToMoveThePlayer(commandAndClickTime.letter)) {                
                Position pos = new Position(thatController.Player.Position.X, thatController.Player.Position.Y);

                if (commandAndClickTime.letter == 'a') {
                    thatController.Player.Position.Y -= 2;
                    Console.Beep(500, 75);
                    return new PosAndChar(commandAndClickTime.letter, pos, Bonus);                    
                }
                else if (commandAndClickTime.letter == 'd') {
                    thatController.Player.Position.Y += 2;
                    Console.Beep(500, 75);
                    return new PosAndChar(commandAndClickTime.letter, pos, Bonus);
                }
                else if (commandAndClickTime.letter == 'w') {
                    thatController.Player.Position.X -= 1;
                    Console.Beep(500, 75);
                    return new PosAndChar(commandAndClickTime.letter, pos, Bonus);
                }
                else if (commandAndClickTime.letter == 's') {
                    thatController.Player.Position.X += 1;
                    Console.Beep(500, 75);
                    return new PosAndChar(commandAndClickTime.letter, pos, Bonus);
                }
                return new PosAndChar(commandAndClickTime.letter, pos, Bonus);
            }
            return new PosAndChar(commandAndClickTime.letter, thatController.Player.Position, Bonus); // Player stays stopped // << WEIRD
        }

        // SPYDERS RULES BELLOW // SPYDERS RULES BELLOW // SPYDERS RULES BELLOW // SPYDERS RULES BELLOW // SPYDERS RULES BELLOW // SPYDERS RULES BELLOW // SPYDERS RULES BELLOW

        private bool[,] ThereIsNoPlayerInTheSpyderNextPosition() {   // NEED TO BE ANALISED     

            bool[,] aux = new bool[18, 19];

            foreach (Spyder spd in thatController.Spyders) {                
                if (thatController.Player.Position.X == spd.Position.X + 1 && thatController.Player.Position.Y == spd.Position.Y) {
                    aux[spd.Position.X + 1, spd.Position.Y] = false;                    
                }
                else {
                    aux[spd.Position.X + 1, spd.Position.Y] = true;
                }
            }
            return aux;
        }

        private bool[,] IsItPossibleToMoveTheSpyder() {

            bool[,] aux = ThereIsNoPlayerInTheSpyderNextPosition();

            foreach (bool obj in aux) {
                if (obj) {
                    foreach (Spyder spd in thatController.Spyders) {
                        if (spd.Position.X + 1 > 17) {
                            aux[spd.Position.X + 1, spd.Position.Y] = false;
                        } // no need of else because this BOOL obj is ALREADY TRUE;                        
                    }
                }
            }
            return aux;
        }

        public void MovingTheSpyders() {

            bool[,] aux = IsItPossibleToMoveTheSpyder();

            foreach (Spyder spd in thatController.Spyders) {
                if (aux[spd.Position.X + 1, spd.Position.Y]) { // << if this particular bool matrix position is true
                    if (spd.Position.X == 16) {
                        spd.Position.X -= 16; // returns to the top
                    }
                    else {
                        spd.Position.X += 1;
                    }
                }
            }               
        }               
    }
}
