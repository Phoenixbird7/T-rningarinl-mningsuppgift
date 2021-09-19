using System;

namespace Inlämningsuppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            int wallet = 500;
            int minimumbet = 50;
            var rnd = new Random();

            while (true)
            {
                if (wallet < minimumbet)
                {
                    Console.WriteLine("you lose");
                    break;
                }

                Console.WriteLine($"you have {wallet} pix");
                Console.Write($"Write your bet, minimum bet is {minimumbet} pix:");

                int bet;
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out bet))
                    {
                        Console.WriteLine("Bet has to be a numeric value!");
                        continue;
                    }

                    if (bet < minimumbet)
                    {
                        Console.WriteLine($"Minimum bet is {minimumbet} pix");
                        continue;
                    }

                    if (bet > wallet)
                    {
                        Console.WriteLine("You can't bet more than you have");
                        continue;
                    }

                    break;
                }



                wallet -= bet;

                Console.Write("Write your luckyNumber(1-6):");
                int luckyNumber;
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out luckyNumber))
                    {
                        Console.WriteLine("Please enter a numeric value!");
                        continue;
                    }

                    if (luckyNumber < 1 || luckyNumber > 6)
                    {
                        Console.WriteLine("The lucky number can only be 1-6");
                        continue;
                    }

                    break;
                }

                var randomNumber1 = rnd.Next(1, 7);
                var randomNumber2 = rnd.Next(1, 7);
                var randomNumber3 = rnd.Next(1, 7);

                var correctNumbers = 0;
                if (randomNumber1 == luckyNumber)
                    correctNumbers++;
                if (randomNumber2 == luckyNumber)
                    correctNumbers++;
                if (randomNumber3 == luckyNumber)
                    correctNumbers++;

                Console.WriteLine($"The random numbers are: {randomNumber1}, {randomNumber2}, {randomNumber3}");

                if (correctNumbers == 0)
                {
                    Console.WriteLine($"You lost {bet} pix");
                }
                else
                {
                    var multiplier = 1 + correctNumbers;
                    var result = bet * multiplier;

                    wallet += result;

                    Console.WriteLine($"You won {result} pix");
                }

                Console.Write("Do you want to play another round? (yes/no)");
                while (true)
                {
                    string answer = Console.ReadLine().Trim();
                    if (answer == "yes")
                    {
                        break;
                    }
                    else if (answer == "no")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please only enter yes or no!");
                    }
                }
            }
        }
    }
}
