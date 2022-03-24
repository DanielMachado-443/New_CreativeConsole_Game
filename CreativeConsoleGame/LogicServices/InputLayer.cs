using System;
using GameBesta.Controllers;
using GameBesta.Model; // It SHOULDN'T BE HERE

namespace GameBesta.LogicServices {
    class InputLayer {
        public AController Controller1 { get; set; }
        public CommandAndClickTime commandAndClickTime { get; set; }

        public InputLayer() {
        }

        public InputLayer(AController controller) {
            Controller1 = controller;
        }

        public CommandAndClickTime OnClicks() {
            
            DateTime now = DateTime.Now;
            ConsoleKeyInfo whatKey = Console.ReadKey();            
            var whatKeyChar = whatKey.KeyChar;

            if (whatKeyChar == 'a' || whatKeyChar == 'A') {
                TimeSpan t = DateTime.Now - now;
                int clickTime = Convert.ToInt32(t.TotalSeconds);
                return new CommandAndClickTime('a', clickTime);
            }
            else if (whatKeyChar == 'd' || whatKeyChar == 'D') {
                TimeSpan t = DateTime.Now - now;
                int clickTime = Convert.ToInt32(t.TotalSeconds);
                return new CommandAndClickTime('d', clickTime);
            }
            else if (whatKeyChar == 'w' || whatKeyChar == 'W') {
                TimeSpan t = DateTime.Now - now;
                int clickTime = Convert.ToInt32(t.TotalSeconds);
                return new CommandAndClickTime('w', clickTime);
            }
            else if (whatKeyChar == 's' || whatKeyChar == 'S') {
                TimeSpan t = DateTime.Now - now;
                int clickTime = Convert.ToInt32(t.TotalSeconds);
                return new CommandAndClickTime('s', clickTime);
            }            
            return new CommandAndClickTime('f', 0);
        }
    }
}
