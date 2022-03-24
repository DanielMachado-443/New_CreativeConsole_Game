using System;
using GameBesta.Controllers;
using GameBesta.Model; // IT SHOULD NOT BE HERE, ITS HERE ONLY because of the ScoreAndBonusAcc class

namespace GameBesta.View {
    class RenderConsole {        

        public static void RenderGame(string[,] table, AController controller, bool bonus, int bonusAcc) {            

            Console.WriteLine("\n");
            var oriColor = Console.ForegroundColor;

            foreach (string str in table) {
                if(str == "!#!") {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (str == "!$!") {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                if (str == controller.Player.ToString()) {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                if (str == "    ##   " || str == "   ## \n\n") {
                    Console.ForegroundColor = ConsoleColor.Black;
                }                
                Console.Write(str);
                Console.ForegroundColor = oriColor;                
            }

            Console.WriteLine("    Score: " + Score(controller, bonus, bonusAcc).Score); // it will return a ScoreAndBonusAcc type
            bonus = false; // << turning it off again  // it seems to be unecessary
        }

        public static string[,] MakeTheObjectsAppearInTheActualPosition(AController controller) {         // << wrong place to have game mechanics                                  
            
            controller.Table1[controller.Player.Position.X, controller.Player.Position.Y] = controller.Player.ToString();

            for (int i = 0; i < controller.Spyders.Count; i++) {
                controller.Table1[controller.Spyders[i].Position.X, controller.Spyders[i].Position.Y] = controller.Spyders[i].ToString();
            }

            for (int i = 0; i < controller.PiecesOfFood.Count; i++) {
                controller.Table1[controller.PiecesOfFood[i].Position.X, controller.PiecesOfFood[i].Position.Y] = controller.PiecesOfFood[i].ToString();
            }

            return controller.Table1; // THIS RETURN NEEDS TO BE ANALISED           
        }

        public static ScoreAndBonusAcc Score(AController controller, bool bonus, int bonusAcc) {
            TimeSpan t = DateTime.Now - controller.startingTime;
            int intT = Convert.ToInt32(t.TotalSeconds);            
            
            if (intT <= 10) {
                if(bonusAcc > 0) {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT / 2) + 50 * bonusAcc, bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT / 2) + (50 * bonusAcc), bonusAcc + 1);
                }
                else {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT / 2), bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT / 2), bonusAcc + 1);
                }
            }

            if (intT <= 50) {
                if (bonusAcc > 0) {
                    if (!bonus) {
                        return new ScoreAndBonusAcc(intT + 50 * bonusAcc, bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc(intT + (50 * bonusAcc), bonusAcc + 1);
                }
                else {
                    if (!bonus) {
                        return new ScoreAndBonusAcc(intT, bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc(intT, bonusAcc + 1);
                }
            }

            if (intT <= 100) {
                if (bonusAcc > 0) {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT * 2) + 50 * bonusAcc, bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT * 2) + (50 * bonusAcc), bonusAcc + 1);
                }
                else {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT * 2), bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT * 2), bonusAcc + 1);
                }
            }

            if (intT <= 200) {
                if (bonusAcc > 0) {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT * 4) + 50 * bonusAcc, bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT * 4) + (50 * bonusAcc), bonusAcc + 1);
                }
                else {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT * 4), bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT * 4), bonusAcc + 1);
                }
            }

            else {
                if (bonusAcc > 0) {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT * 8) + 50 * bonusAcc, bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT * 8) + (50 * bonusAcc), bonusAcc + 1);
                }
                else {
                    if (!bonus) {
                        return new ScoreAndBonusAcc((intT * 8), bonusAcc);
                    }                    
                    return new ScoreAndBonusAcc((intT * 8), bonusAcc + 1);
                }
            }
        }
    }
}
