using System;

namespace Gold_Lotto_Checker {

    /// <summary>
    /// Menu driven program that searches through all the lotto numbers in several games and 
    /// determines how many winning and supplementary numbers you have drawn in each game.
    /// 
    /// Author Quintus Cardozo April 2017
    /// Student Number: n9703578
    /// </summary>
    class Program {

        /// <summary>
        /// Starts the program and calls all the required methods.
        /// </summary>
        static void Main() {

            int[,] lottoNumbers ={
                                  { 4, 7, 19, 23, 28, 36},
                                  {14, 18, 26, 34, 38, 45},
                                  { 8, 10,11, 19, 28, 30},
                                  {15, 17, 19, 24, 43, 44},
                                  {10, 27, 29, 30, 32, 41},
                                  { 9, 13, 26, 32, 37,  43},
                                  { 1, 3, 25, 27, 35, 41},
                                  { 7, 9, 17, 26, 28, 44},
                                  {17, 18, 20, 28, 33, 38}
                              };

            int[] drawNumbers = new int[] { 44, 9, 17, 43, 26, 7, 28, 19 };

            Welcome();
            ArrayCreator(lottoNumbers, drawNumbers);

            ExitProgram();
        }//end Main

        /// <summary>
        /// Prints the programs tile and welcome message.
        /// </summary>
        static void Welcome() {
            Console.WriteLine(" Welcome to Lotto Checker \n");
            Console.WriteLine(" Your Lotto numbers are \n");
        }

        /// <summary>
        /// Creates arrays for the individual games and call methods to performs a linear search 
        /// to determine the number of winning and supplementary numbers in each game and print them.
        /// </summary>
        /// <param name="lotto_numbers">Two-dimensional array of nine lotto games and their numbers</param>
        /// <param name="draw_numbers">Array of draw numbers</param>
        static void ArrayCreator(int[,] lotto_numbers, int[] draw_numbers) {
            int[] game_count = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            int[] draw_numbers_winning = new int[] { draw_numbers[0], draw_numbers[1], draw_numbers[2],
                draw_numbers[3], draw_numbers[4], draw_numbers[5] };
            int[] draw_numbers_supplementary = new int[] { draw_numbers[6], draw_numbers[7] };

            int[] game1 = new int[] { lotto_numbers[0, 0], lotto_numbers[0, 1], lotto_numbers[0, 2],
                lotto_numbers[0, 3], lotto_numbers[0, 4], lotto_numbers[0,5] };
            int[] game2 = new int[] { lotto_numbers[1, 0], lotto_numbers[1, 1], lotto_numbers[1, 2],
                lotto_numbers[1, 3], lotto_numbers[1, 4], lotto_numbers[1, 5] };
            int[] game3 = new int[] { lotto_numbers[2, 0], lotto_numbers[2, 1], lotto_numbers[2, 2],
                lotto_numbers[2, 3], lotto_numbers[2, 4], lotto_numbers[2, 5] };
            int[] game4 = new int[] { lotto_numbers[3, 0], lotto_numbers[3, 1], lotto_numbers[3, 2],
                lotto_numbers[3, 3], lotto_numbers[3, 4], lotto_numbers[3, 5] };
            int[] game5 = new int[] { lotto_numbers[4, 0], lotto_numbers[4, 1], lotto_numbers[4, 2],
                lotto_numbers[4, 3], lotto_numbers[4, 4], lotto_numbers[4, 5] };
            int[] game6 = new int[] { lotto_numbers[5, 0], lotto_numbers[5, 1], lotto_numbers[5, 2],
                lotto_numbers[5, 3], lotto_numbers[5, 4], lotto_numbers[5, 5] };
            int[] game7 = new int[] { lotto_numbers[6, 0], lotto_numbers[6, 1], lotto_numbers[6, 2],
                lotto_numbers[6, 3], lotto_numbers[6, 4], lotto_numbers[6, 5] };
            int[] game8 = new int[] { lotto_numbers[7, 0], lotto_numbers[7, 1], lotto_numbers[7, 2],
                lotto_numbers[7, 3], lotto_numbers[7, 4], lotto_numbers[7, 5] };
            int[] game9 = new int[] { lotto_numbers[8, 0], lotto_numbers[8, 1], lotto_numbers[8, 2],
                lotto_numbers[8, 3], lotto_numbers[8, 4], lotto_numbers[8, 5] };

            int[] winning_numbers = new int[] {WinSupplementaryCheck(draw_numbers_winning, game1),
                WinSupplementaryCheck(draw_numbers_winning, game2),
                WinSupplementaryCheck(draw_numbers_winning, game3),
                WinSupplementaryCheck(draw_numbers_winning, game4),
                WinSupplementaryCheck(draw_numbers_winning, game5),
                WinSupplementaryCheck(draw_numbers_winning, game6),
                WinSupplementaryCheck(draw_numbers_winning, game7),
                WinSupplementaryCheck(draw_numbers_winning, game8),
                WinSupplementaryCheck(draw_numbers_winning, game9)};
            int[] supplementary_numbers = new int[] {WinSupplementaryCheck(draw_numbers_supplementary, 
                game1), WinSupplementaryCheck(draw_numbers_supplementary, game2),
                WinSupplementaryCheck(draw_numbers_supplementary, game3),
                WinSupplementaryCheck(draw_numbers_supplementary, game4),
                WinSupplementaryCheck(draw_numbers_supplementary, game5),
                WinSupplementaryCheck(draw_numbers_supplementary, game6),
                WinSupplementaryCheck(draw_numbers_supplementary, game7),
                WinSupplementaryCheck(draw_numbers_supplementary, game8),
                WinSupplementaryCheck(draw_numbers_supplementary, game9) };

            PrintGameLottoNumbers(game1, game_count[0]);
            PrintGameLottoNumbers(game2, game_count[1]);
            PrintGameLottoNumbers(game3, game_count[2]);
            PrintGameLottoNumbers(game4, game_count[3]);
            PrintGameLottoNumbers(game5, game_count[4]);
            PrintGameLottoNumbers(game6, game_count[5]);
            PrintGameLottoNumbers(game7, game_count[6]);
            PrintGameLottoNumbers(game8, game_count[7]);
            PrintGameLottoNumbers(game9, game_count[8]);
            PrintGameLottoNumbers(draw_numbers);

            for (int i = 0; i < 9; i++) {
                Console.WriteLine(" Game {0} has {1} winning numbers and {2} supplementary numbers. \n", 
                    i+1,winning_numbers[i], supplementary_numbers[i]);
            }
        }

        /// <summary>
        /// Performs linear seach to determine the winning and supplementary numbers in each game.
        /// </summary>
        /// <param name="win_or_supplementary_numbers">Array of winning numbers or 
        /// array of supplementary numbers</param>
        /// <param name="game">Array of each lotto game</param>
        /// <returns></returns>
        static int WinSupplementaryCheck(int[] win_or_supplementary_numbers, int[] game) {
            int win_or_supplementary_count = 0;

            for (int i = 0; i < win_or_supplementary_numbers.Length; i++) {
                int winning_number = win_or_supplementary_numbers[i];

                for (int j = 0; j < 6; j++) {

                    if (winning_number == game[j]) {
                        win_or_supplementary_count = win_or_supplementary_count + 1;
                    }
                }
            }
            return win_or_supplementary_count;
        }

        /// <summary>
        /// Prints the draw numbers and the lotto numbers for each game.
        /// </summary>
        /// <param name="game">Array of each lotto game</param>
        /// <param name="game_count">Count of the lotto game 
        /// If it is equal to 10 it will print the draw number</param>
        static void PrintGameLottoNumbers(int[] game, int game_count = 10) {
            if (game_count < 10) {
                Console.Write(" Game {0}:", game_count);
            } else {
                Console.WriteLine(" Lotto Draw Numbers are");
            }

            for (int i = 0; i < game.Length; i++) {
                Console.Write("{0,5}", game[i]);
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Prints an exit message and exits the program gracefully.
        /// </summary>
        static void ExitProgram() {
            Console.Write(" Thanks for using Lotto Checker");
            Console.Write("\n\n Press any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram



    }//end class
}//end namespace
