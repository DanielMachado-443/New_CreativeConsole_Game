using System;
using System.Threading;
using GameBesta.Controllers;
using GameBesta.View;

namespace GameBesta.LogicServices {
    class MainLoop {

        private AController Controller1 = new AController();
        private GameLogics GameLogics = new GameLogics();
        private InputLayer thisInputLayer = new InputLayer();
        private bool gameWhile = true;
        public bool Bonus { get; set; } = false;
        public int BonusAcc { get; set; } = 0;             

        public MainLoop(AController controller) {
            Controller1 = controller;
            thisInputLayer.Controller1 = controller;
            GameLogics.thatController = controller;
        }

        public void Loop() {

            int A_verifier = 0; // restoring the neutral value outside of the if scoope
            int D_verifier = 0; // restoring the neutral value outside of the if scoope
            int W_verifier = 0; // restoring the neutral value outside of the if scoope
            int S_verifier = 0; // restoring the neutral value outside of the if scoope

            while (gameWhile) {
                Console.Clear();
                if(!GameLogics.gameOver) {
                    RenderConsole.RenderGame(RenderConsole.MakeTheObjectsAppearInTheActualPosition(Controller1), Controller1, Bonus, BonusAcc);

                    if (A_verifier <= 3 && D_verifier <= 3 && W_verifier <= 3 && S_verifier <= 3) {
                        Thread.Sleep(100);
                        
                        Controller1.PosAndChar = GameLogics.MovingThePlayer(thisInputLayer.OnClicks());   // MovingThePlayer method gets a char as parameter, while OnClicks returns a char || NOW IT RETURNS A PLAYER                          
                        Bonus = Controller1.PosAndChar.Bonus;
                        BonusAcc = RenderConsole.Score(Controller1, Bonus, BonusAcc).AccBonus;
                        char thatChar = Controller1.PosAndChar.Character;

                        if (thatChar == 'a') {
                            A_verifier++;
                        }
                        if (thatChar == 'd') {
                            D_verifier++;
                        }
                        if (thatChar == 'w') {
                            W_verifier++;
                        }
                        if (thatChar == 'a') {
                            S_verifier++;
                        }

                        //==========================================================

                        if (A_verifier == 4) {
                            Thread.Sleep(100);
                            A_verifier = 0;
                        }
                        if (D_verifier == 4) {
                            Thread.Sleep(100);
                            D_verifier = 0;
                        }
                        if (W_verifier == 4) {
                            Thread.Sleep(100);
                            W_verifier = 0;
                        }
                        if (S_verifier == 4) {
                            Thread.Sleep(100);
                            S_verifier = 0;
                        }
                    }

                    GameLogics.MovingTheSpyders();                    
                    Controller1.Table1 = Controller1.RefreshTable(); //<< Should it be here?
                    RenderConsole.MakeTheObjectsAppearInTheActualPosition(Controller1);
                }
                else {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n                                             GAME OVER !!! " // << OUT OF PLACE
                        +"\n                                            Final Score: "
                        +RenderConsole.Score(Controller1, Bonus, BonusAcc).Score
                        +"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                    Console.Beep(750, 1000);
                    gameWhile = false;
                }
            }                
        }
    }
}
