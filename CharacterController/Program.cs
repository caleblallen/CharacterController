using System;

namespace CharacterController
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;

            while (!done)
            {
                Console.Clear();
                Console.Write("Enter comm >");
                string cmd = Console.ReadLine();

                Console.Write($"You entered '{cmd}'");

                done = true;
            }
            
        }
    }
}
