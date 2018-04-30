///Author:  Qian Chen
// Filename: encryptWord.cs
// Date: April 29, 2018
// Version: 1.2
// References (optional):

// Class Description and Funcationality:
// The class encryptWord contains a shift value with which 
// the letters will be encrypted and decrypted. encryption and 
// decryption accept words of no less than 4 letters. For example,
// with value set as "2", original word "abcd" is encrypted to "cdef ";
// word "Happy" would be decrypted to "Fynnw" with the same shift value.
// Users can set the shift value to a positive integer when initializing
// an object, or they can use the default shift value: 0.  Also users can
// guess the shift value in an encryptWord instance and related guess
//data is recorded and can be printed out.


// Legal States:
// The class has two states: on and off. The "off " state is when a class
// instance has not been created or the instance is created with default
// shift value: 0; The "on" state referes to existence of a positive shift,
// so when a class object is created with user-given positive shift value,
// the state is turned on. Functions of encryptAWord(), decryptAWord(),
// isShiftValue(), showStats() can only be called under the state "on".

// Assumptions:
// * The shift's default value is 0 if user does not set a specific 
//value when creating an object;
// * The cipher shift value should not be negative number;
// * The length of input word in encryption function is no less than 4 letters, 
//otherwise, error will be caught;
// * The input word may contain non-letter string like white space,
//$, %... Those characters won't be encrypted;
// * Yielding statistics refers to printing out guess-related data
//all in a same function.

using System;
using System.Collections.Generic;
using System.Text;

namespace chenq5_assignment1
{
    class encryptWord
    {
        private const int LETTERS_DIVIDEND = 26;
        private const char INIT_LOWER_LETTER = 'a';
        private const char INIT_UPPER_LETTER = 'A';
        private const string LOWER_LETTERS = "abcdefghijklmn" +
            "opqrstuvwxyz";
        private const string UPPER_LETTERS = "ABCDEFGHIJKLM" +
            "NOPQRSTUVWXYZ";

        private int shift;
        private int guessTimes;    
        private int highGuessTimes;
        private int lowGuessTimes;
        private double sumOfGuessValue;
        private double averageGuess;

        /// <summary>
        /// non-argument constructor function with default 
        /// shift as 0.
        /// precondition: none
        /// postcondition: no state change
        /// </summary>
         internal encryptWord()
        {
            shift = 0;
            guessTimes = 0;
            sumOfGuessValue = 0.0;
            highGuessTimes = 0;
            lowGuessTimes = 0;
        }
        /// <summary>
        /// a constructor requiring user-given positive
        /// integer shift value, after the function, the state
        /// is turned on.
        /// precondition: parameter shift value should be positive
        /// postcondition: the state changes from "off" to "on"
        /// </summary>
        /// <param name="given_shift">user-given positive integer</param>
        internal encryptWord(int given_shift)
        {
            shift = given_shift;
            guessTimes = 0;
            sumOfGuessValue = 0.0;
            highGuessTimes = 0;
            lowGuessTimes = 0;
        }

        /// <summary>
        ///the function takes in a word and outputs encrypted
        ///word with shift value;
        ///precondition: valid state should be "on"
        ///and the input word length should be no less than
        ///4 letters;
        ///postcondition: output a decrypted word
        /// </summary>
        /// <param name="input_word">the word to be encrypted</param>
        /// <returns>encrypted word</returns> 
        internal string encryptAWord(string input_word)
        {
            if (input_word.Length < 4)
            {
                throw new System. ArgumentException("Parameter is less" +
                    " than 4 letters, REJECTED",input_word);
            }
            char[] encrypted_word = input_word.ToCharArray();
            return shiftWord(encrypted_word, shift);
        }

        /// <summary>
        /// helper function to encrypt/decrypt word
        /// </summary>
        /// <param name="encrypted_word">char array from input word</param>
        /// <param name="shift">current shift value</param>
        /// <returns>encrypted or decrypted word</returns>
        private string shiftWord(char[] encrypted_word, int shift)
        {
            for (int i = 0; i < encrypted_word.Length; i++)
            {
                char current_char = encrypted_word[i];
                if (LOWER_LETTERS.IndexOf(current_char) >= 0)
                {
                    int new_pos = (current_char - INIT_LOWER_LETTER + shift) % LETTERS_DIVIDEND;
                    encrypted_word[i] = LOWER_LETTERS[new_pos];
                }
                else if (UPPER_LETTERS.IndexOf(current_char) >= 0)
                {
                    int new_pos = (current_char - INIT_UPPER_LETTER + shift) % LETTERS_DIVIDEND;
                    encrypted_word[i] = UPPER_LETTERS[new_pos];
                }
                else
                {
                    encrypted_word[i] = current_char;
                }
            }
            string encrypted = new string(encrypted_word);
            return encrypted;
        }

        /// <summary>
        ///  the function takes in a string and restores 
        ///  the string to original form;
        ///  preconditon: the state is "on"
        ///  and the input word length should be no less than
        ///  4 letters;
        ///  postconditon: none
        /// </summary>
        /// <param name="input_word">the word to be decrypted</param>
        /// <returns>decrypted word</returns> 
        internal string decryptAWord(string input_word)
        {
            if (input_word.Length < 4)
            {
                throw new System.ArgumentException("Parameter is less" +
                    " than 4 letters, REJECTED", input_word);
            }
            int decrypt_shift = LETTERS_DIVIDEND - shift % LETTERS_DIVIDEND;
            char[] decrypted_word = input_word.ToCharArray();
            return shiftWord(decrypted_word, decrypt_shift);
        }

        /// <summary>
        ///description: the function checks if a user-given value is
        ///equal to the one in use, returning true or false, 
        ///precondition: the state is "on"
        ///postcondition: guess times and guess results will be recorded.
        /// </summary>
        /// <param name="user_guess">user guess shift</param>
        /// <returns>the result of guessing</returns>
        internal bool isShiftValue(int user_guess)
        {
            int guess_value = user_guess;
            while (guess_value < 0)
            {
                Console.WriteLine("Only accepts non-negative guess!");
                Console.WriteLine($"{guess_value} is negative number!");
                Console.Write("\nEnter a new guess: ");
                guess_value = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine(guess_value);             
            }
            guessTimes += 1;
            sumOfGuessValue += guess_value;
            
            if (guess_value > shift)
            {
                highGuessTimes += 1;
            } else if(guess_value < shift)
            {
                lowGuessTimes += 1;
            } else
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// the function prints out how many times isShiftValue
        /// function has been called and times of high guess and low guess,
        /// as well as the sum value of total guesses;
        /// preconditon: cannot showStats() before the first guess, in other 
        /// words, function isShiftValue() should be called once before this 
        /// function;
        ///  postcondition: none.
        /// </summary>
        internal void showStats()
        {
            averageGuess = sumOfGuessValue / guessTimes;
            Console.WriteLine("Statistics:");
            Console.WriteLine($"Number of guesses: {guessTimes}");
            Console.WriteLine($"Low guess times: {lowGuessTimes}");
            Console.WriteLine($"High guess times: {highGuessTimes}");
            Console.WriteLine($"Sum of guess values: {sumOfGuessValue}");
            Console.WriteLine($"Average guess value is: {averageGuess}");
        }


    }
}
