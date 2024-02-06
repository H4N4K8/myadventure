using System;

namespace myAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int cheese = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your mouse? ");
            string name = Console.ReadLine();
            initValues(ref cheese, ref health, r);
            while (cheese < 5 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref cheese, ref health);
                else
                    actions(r.Next(10), ref cheese, ref health);
                checkResults(ref round, ref cheese, ref health, ref win);
            }
            if(win)
                Console.WriteLine("Congratulations on successfully getting dinner!");
            else if (cheese <= 0)
                Console.WriteLine("You got enough food to feed your family, but not yourself");
            else
                Console.WriteLine("Your lost too much health and ended up in the mouse hospital");
        }
        static void initValues(ref int cheese, ref int health, Random r)
        {
            cheese = r.Next(10) + 1;
            health = r.Next(5, 15) + 1;
        }
        static int chooseDirection()
        {
            Console.WriteLine("You take a step forward, enter 1 to go right and 2 to go left");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }
        static void actions(int num, ref int cheese, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You tripped on a pile of dirt");
                    Console.WriteLine("You lose 1 unit of health");
                    health -= 1;
                    break;
                case 1:
                    Console.WriteLine("You found food in front of a cat and just barley made it past");
                    Console.WriteLine("You lost 2 units of health but got 1 cheese");
                    health -= 1;
                    cheese += 1;
                    break;
                case 2:
                    Console.WriteLine("You dropped a piece of cheese while running");
                    Console.WriteLine("you lose 1 cheese.");
                    cheese -= 1;
                    break;
                case 3:
                    Console.WriteLine("You stop to talk to your ant friend. He had some food!");
                    Console.WriteLine("You gain one cheese");
                    cheese += 1;
                    break;
                case 4:
                    Console.WriteLine("You see a cute fly");
                    Console.WriteLine("You gained 3 health");
                    health += 3;
                    break;
                case 5:
                    Console.WriteLine("You find a whole slice of cheese!");
                    Console.WriteLine("You gain 2 health and cheese");
                    health += 2;
                    cheese += 2;
                    break;
                case 6:
                    Console.WriteLine("You drank some soda from an open can");
                    Console.WriteLine("You gain 3 units of health");
                    health += 3;
                    break;
                case 7:
                    Console.WriteLine("You witness a purse theft");
                    Console.WriteLine("You lose 3 health");
                    health -= 3;
                    break;
                case 8:
                    Console.WriteLine("You are given free cheese from your mouse friend");
                    Console.WriteLine("You gain 1 cheese and 3 health");
                    cheese += 1;
                    health += 3;
                    break;
                case 9:
                    Console.WriteLine("You are almost got caught in a trap");
                    Console.WriteLine("You lose 5 health and 2 cheese");
                    health -= 2;
                    cheese -= 2;
                    break;
                default:
                    Console.WriteLine("Your feet start to hurt");
                    Console.WriteLine("You lose 1 health");
                    health += 1;
                    break;
            }
        }
        private static void checkResults(ref int round, ref int cheese, ref int health, ref bool win)
        {
            round++;
            Console.WriteLine(round);
            Console.WriteLine("Cheese =" + cheese);
            Console.WriteLine("Health =" + health);
            if (cheese >= 5)
            {
                win = true;
            }
        }
    }
}
