using System;
using System.Collections.Generic;
using System.Text;

//Author:  Qian Chen
// Filename: encryptWord.cs
// Date: April 29, 2018
// Version: 1.2
// References (optional):

//Class Description:
//Driver class is a wrapper of encryptWord class. So the function and use of 
//this class is almost the same as encryptWord calss. The class can encrypt
//and decrypt a word of no less than 4 letters. The class encapulates a shift
//value which can be set to  a positive integer by users when initializing
// an object, or they can use the default shift value: 0.  Also users can
// guess the shift value in an encryptWord instance and related guess
//data is recorded and can be printed out.

//Legal States:
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

namespace chenq5_assignment1
{
    class Driver
    {
        private encryptWord ew;

        /// <summary>
        /// non-argument constructor function with default 
        /// shift as 0.
        /// precondition: none
        /// postcondition: no state change
        /// </summary>
        public Driver()
        {
            this.ew = new encryptWord();
        }

        /// <summary>
        /// a constructor requiring user-given positive
        /// integer shift value, after the function, the state
        /// is turned on.
        /// precondition: parameter shift value should be positive
        /// postcondition: the state changes from "off" to "on"
        /// </summary>
        /// <paramm name="given_shift">user-given positive integer</param>
        public Driver(int given_shift)
        {
             this.ew = new encryptWord(given_shift);
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
        public string EncryptAWord (string input_word)
        {
            string result = "";
            try {
                result = this.ew.encryptAWord(input_word);
            } catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            return result;
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
        public string DecryptAWord(string input_word)
        {
            string result = "";
            try
            {
                result = this.ew.decryptAWord(input_word);
            } catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            return result;          
        }

        /// <summary>
        ///description: the function checks if a user-given value is
        ///equal to the one in use, returning true or false, 
        ///precondition: the state is "on"
        ///postcondition: guess times and guess results will be recorded.
        /// </summary>
        /// <param name="user_guess">user guess shift</param>
        /// <returns>the result of guessing</returns>
        public bool isShiftValue(int guess_value)
        {
           return this.ew.isShiftValue(guess_value);
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
        public void showStats()
        {
            this.ew.showStats();                
        }
    }
}
