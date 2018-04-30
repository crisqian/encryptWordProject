using System;
//Author:  Qian Chen
// Filename: encryptWord.cs
// Date: April 29, 2018
// Version: 1.2
// References (optional):

// Class Description and Funcationality:
// This class takes input from users with three major
// modules. First, user should input a positive integer 
// to set shift value, non-positive input requires reentering
// value. Then users can input a word for encryption with 
// the given shift value. Only words more or equal to 4 letters
// can yield valid output and users are asked to continue or exit 
// encryption funcitn. Following this is decryption function test 
//similar to encryption. 

namespace chenq5_assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int shiftVal;
            string input_word;
            string output_word;
            char repeat;

            Console.WriteLine("Welcome to word encryption game.");

            do
            {
                Console.WriteLine("Please enter a positive integer as shift value: ");
                shiftVal = Convert.ToInt32(Console.ReadLine());
            } while (shiftVal <= 0);

            Driver testDriver = new Driver(shiftVal);

            do
            {
                Console.WriteLine("Please type a word for encryption," +
                    " the word should be no less than 4 lettes: ");
                input_word = Console.ReadLine();
                output_word = testDriver.EncryptAWord(input_word);
                Console.WriteLine($"The encrypted word is: {output_word}.");
                Console.WriteLine("Do you want to enter another word for encryption(y for yes, n for no): ");
                repeat = Convert.ToChar(Console.ReadLine());
            } while (repeat != 'n'||input_word.Length < 4);

            do
            {
                Console.WriteLine("Please type a word for decryption," +
                    " the word should be no less than 4 lettes: ");
                input_word = Console.ReadLine();
                output_word = testDriver.DecryptAWord(input_word);
                Console.WriteLine($"The decrypted word is: {output_word}.");
                Console.WriteLine("Do you want to enter another word for decryption(y for yes, n for no): ");
                repeat = Convert.ToChar(Console.ReadLine());
            } while (repeat != 'n' || input_word.Length < 4);

            Console.WriteLine("Press any key to exit the game.");

            Console.ReadKey(true);


        }
    }
}
