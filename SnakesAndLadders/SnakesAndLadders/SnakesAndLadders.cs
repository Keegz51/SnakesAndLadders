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

            play(1, 2);

        }

        static bool doub = false;
        public static string play(int die1, int die2)
        {

            bool win = false;

            int one_pos_player1 = 0;
            //int two_pos_player2=0;

            Dictionary<int, int> snakeHeads = new Dictionary<int, int>();
            Dictionary<int, int> ladderFeet = new Dictionary<int, int>();

            List<int> board = new List<int>();

            for (int i = 1; i <= 100; i++)
            {

                board.Add(i);

            }

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


            Console.WriteLine("Roll");
            string rollRequest = Console.ReadLine();

            while (rollRequest == "yes" && win == false)
            {

                doub = false;

                int oneRoll = roll();

                while (doub == true)
                {
                    doub = false;
                    one_pos_player1 = one_pos_player1 + oneRoll;
                    oneRoll = roll();
                }

                Console.WriteLine("Roll");
                rollRequest = Console.ReadLine();
            }

            return "";

        }


        #region Roll
        public static int roll()
        {
            Random rand = new Random();

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
