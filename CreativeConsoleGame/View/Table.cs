namespace GameBesta.LogicServices {
    class Table {
        public static string[,] setTable() {

            string[,] Table = new string[18, 19];

            for (int x = 0; x < 18; x++) {
                for (int y = 0; y < 19; y++) {
                    if(x < 17) { // << NOT RENDERIZING THE LAST ROW
                        if (y == 0) {
                            Table[x, y] = "    ##   ";
                        }
                        if (y == 18) {
                            Table[x, y] = "   ## \n\n";
                        }
                        if (y != 0 && y != 18) {
                            if (y % 2 == 0) {
                                if (y != 17) {
                                    Table[x, y] = "   ";
                                }
                            }
                            else {
                                Table[x, y] = "|:::|";
                            }
                        }
                    }                    
                }
            }
            return Table;
        }
    }
}
