using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    class SnakesAndLadders
    {
        static void Main(string[] args)
        {

            Console.WriteLine(play()+" has won!");

        }

        static Random rand = new Random();

        static bool doub = false;
        public static string play()
        {
            string winner = "";
            bool win = false;

            int one_pos_player1 = 0;
            int two_pos_player2=0;

            Dictionary<int, int> snakeHeads = new Dictionary<int, int>();
            Dictionary<int, int> ladderFeet = new Dictionary<int, int>();

            List<int> board = new List<int>();

            for (int i = 1; i <= 100; i++)
            {

                board.Add(i);

            }

            #region Populate Snakes and Ladders
            ladderFeet.Add(2, 38);
            ladderFeet.Add(7, 14);
            ladderFeet.Add(8, 31);
            ladderFeet.Add(15, 26);
            ladderFeet.Add(21, 42);
            ladderFeet.Add(28, 84);
            ladderFeet.Add(36, 44);
            ladderFeet.Add(51, 67);
            ladderFeet.Add(71, 91);
            ladderFeet.Add(78, 98);
            ladderFeet.Add(87, 94);

            snakeHeads.Add(16, 6);
            snakeHeads.Add(46, 25);
            snakeHeads.Add(49, 11);
            snakeHeads.Add(62, 19);
            snakeHeads.Add(64, 60);
            snakeHeads.Add(74, 53);
            snakeHeads.Add(89, 68);
            snakeHeads.Add(92, 88);
            snakeHeads.Add(95, 75);
            snakeHeads.Add(99, 80);

            #endregion

            Console.WriteLine("Roll");
            string rollRequest = Console.ReadLine();

            while (rollRequest == "yes" && win == false)
            {

                doub = false;

                #region Player1
                int oneRoll = roll();
                one_pos_player1 = one_pos_player1 + oneRoll;

                while (doub == true)
                {
                    Console.WriteLine("Player 1 - " + "Double! Roll Again!");
                    oneRoll = roll();
                    one_pos_player1 = one_pos_player1 + oneRoll;
                    doub = false;
                }

                Console.WriteLine("Player 1 - " + one_pos_player1);

                if (ladderFeet.Keys.Contains(one_pos_player1))
                {
                    Console.WriteLine("Player 1 - " + "Ladder UP!");
                    one_pos_player1 = ladderFeet[one_pos_player1];

                    Console.WriteLine("Player 1 - " + one_pos_player1);
                }

                if (snakeHeads.Keys.Contains(one_pos_player1))
                {
                    Console.WriteLine("Player 1 - " + "Slide DOWN!");
                    one_pos_player1 = snakeHeads[one_pos_player1];

                    Console.WriteLine("Player 1 - " + one_pos_player1);
                }

                if(one_pos_player1>100)
                {
                    Console.WriteLine("Player 1 - " + "Overshot - Move back!");
                    one_pos_player1 = 100-(one_pos_player1 - 100);
                    Console.WriteLine("Player 1 - " + one_pos_player1);

                    if (snakeHeads.Keys.Contains(one_pos_player1))
                    {
                        Console.WriteLine("Player 1 - " + "Slide DOWN!");
                        one_pos_player1 = snakeHeads[one_pos_player1];

                        Console.WriteLine("Player 1 - " + one_pos_player1);
                    }

                }
                else if(one_pos_player1==100)
                {
                    winner = "Player 1";
                    win = true;
                }

                #endregion

                #region Player2
                int twoRoll = roll();
                two_pos_player2 = two_pos_player2 + twoRoll;

                while (doub == true)
                {
                    Console.WriteLine("Player 2 - " + "Double! Roll Again!");
                    twoRoll = roll();
                    two_pos_player2 = two_pos_player2 + twoRoll;
                    doub = false;
                }

                Console.WriteLine("Player 2 - "+ two_pos_player2);

                if (ladderFeet.Keys.Contains(two_pos_player2))
                {
                    Console.WriteLine("Player 2 - " + "Ladder UP!");
                    two_pos_player2 = ladderFeet[two_pos_player2];

                    Console.WriteLine("Player 2 - " + two_pos_player2);
                }

                if (snakeHeads.Keys.Contains(two_pos_player2))
                {
                    Console.WriteLine("Player 2 - " + "Slide DOWN!");
                    two_pos_player2 = snakeHeads[two_pos_player2];

                    Console.WriteLine("Player 2 - " + two_pos_player2);
                }

                if (two_pos_player2 > 100)
                {
                    Console.WriteLine("Player 2 - " + "Overshot - Move back!");
                    two_pos_player2 = 100 - (two_pos_player2 - 100);
                    Console.WriteLine("Player 2 - " + two_pos_player2);

                    if (snakeHeads.Keys.Contains(two_pos_player2))
                    {
                        Console.WriteLine("Player 2 - " + "Slide DOWN!");
                        two_pos_player2 = snakeHeads[two_pos_player2];

                        Console.WriteLine("Player 2 - " + two_pos_player2);
                    }
                }
                else if (two_pos_player2 == 100)
                {
                    winner = "Player 2";
                    win = true;
                }

                #endregion

                if (win==false)
                {
                    Console.WriteLine("Roll");
                    rollRequest = Console.ReadLine();
                }
            }

            return winner;

        }


        #region Roll
        public static int roll()
        {

            int roll1 = rand.Next(1, 6);
            int roll2 = rand.Next(1, 6);

            if (roll1 == roll2)
            {
                doub = true;
            }

            return roll1 + roll2;
        }
        #endregion


    }
}
