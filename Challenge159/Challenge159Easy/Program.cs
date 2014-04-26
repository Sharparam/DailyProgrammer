namespace Challenge159Easy
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Move userMove;
            do
            {
                Console.Write("Your move please: ");
            } while (!Move.TryParse(Console.ReadLine(), out userMove));

            Console.WriteLine("Your move was {0}", userMove);
            Move cpuMove = Move.GetRandom();
            Console.WriteLine("Computer's move was {0}", cpuMove);
            var result = userMove.Play(cpuMove);
            var resultString = Move.GetResultString(userMove, cpuMove, result);
            Console.WriteLine("The results are in: {0}", resultString);
            if (result.Result == MoveResultType.Win)
                Console.WriteLine("You win!");
            else if (result.Result == MoveResultType.Loss)
                Console.WriteLine("You lose!");
            Console.ReadLine();
        }
    }
}
