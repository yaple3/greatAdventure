using System;
using System.Reflection.PortableExecutable;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref magic, ref health, r);
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before its completion");

        }

        private static void actions(int num, ref int lives, ref int magic, ref int health)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("You met three bears who were not happy that their porridge was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by flying monkeys and had to be rescued by a young girl and a dog");
                    Console.WriteLine("You lost 2 units of health and magic and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("Your evil stepmother is jealous of your good looks and is forcing you to clean her house.");
                    Console.WriteLine("You lose 2 units of health and 1 unit of magic");
                    health -= 2;
                    magic -= 1;
                    break;
                case 3:
                    Console.WriteLine("You ate a poisoned apple offered by a disguised witch and fell into a deep sleep.");
                    Console.WriteLine("You lose 3 units of health and magic and 1 life");
                    health -= 3;
                    magic -= 3;
                    lives -= 1;
                    break;
                case 4:
                    Console.WriteLine("You were chased by a big bad wolf who wanted to eat you and your grandmother.");
                    Console.WriteLine("You lose 2 units of health and magic and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 5:
                    Console.WriteLine("You saved a fellow traveler from a headless horseman.");
                    Console.WriteLine("The traveler granted you 2 units of health, magic and lives");
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a woman who lived in a smelly house that resembled a shoe (she had a lot of kids).");
                    Console.WriteLine("You gain 3 units of health and magic");
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("Your dream of being a real boy is finally materializing.");
                    Console.WriteLine("You gain 2 units of health and magic and 3 lives");
                    health += 2;
                    magic += 2;
                    lives += 3;
                    break;
                case 8:
                    Console.WriteLine("You found a magic lamp and summoned a genie who granted you three wishes.");
                    Console.WriteLine("You gain 5 units of health, magic and lives");
                    health += 5;
                    magic += 5;
                    lives += 5;
                    break;
                case 9:
                    Console.WriteLine("You climbed down a tower using your long hair and met a charming prince who wanted to marry you.");
                    Console.WriteLine("You gain 4 units of health and magic");
                    health += 4;
                    magic += 4;
                    break;
                default:
                    Console.WriteLine("You saved a unicorn from a mean wizard.");
                    Console.WriteLine("You gain 2 lives and 2 units of magic");
                    magic += 2;
                    lives += 2;
                    break;
            }
        }

        private static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            //1) Add 1 to the round variable
            round++;

            //2) Write out the round number
            Console.WriteLine("*************** Round {0} ***************", round);

            //3) Write out the values for lives, magic and health
            Console.WriteLine("Lives: {0} Magic: {1} Health {2}", lives, magic, health);

            //4) Check to see if the round variable >= 25. 
            if (round >= 25)
            {
                //If it is true, then set win = true
                win = true;
            }

            //5) Return to the main method
            return;
        }

        private static int chooseDirection()
        {
            Console.WriteLine("You have come to a crossroad, enter 1 to travel left or 2 to travel right");
            int direction;
            //prompt user and attempt to parse the input into the 'direction' variable
            while (!int.TryParse(Console.ReadLine(), out direction) || (direction != 1 && direction != 2)) //check if invalid input (not a number or number other than 1 or 2)
            {
                //if invalid entry prompt user to correct mistake
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
            }
            return direction;
        }

        private static void initValues(ref int lives, ref int magic, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            magic = r.Next(15) + 5;
            health = r.Next(14) + 5;
            return;
        }
    }
}
