﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        public static int CountVowels(string s)
        {
            if (s == null)
                throw new ArgumentNullException("В метод передан null");
            s.ToLower(); // перевод символов строки в нижний регистр для более быстрого поиска символов
            char[] vowelCharsArray = { 'a', 'o', 'u', 'i', 'e' }; // массив символов, с которым нужно ставнить символы заданной строки
            int counter = 0; // счётчик
            foreach(char ch in s)
            {
                if (vowelCharsArray.Contains(ch))
                    counter++;
            }
            return counter;
        }

        // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

        static void Main(string[] args)
        {
            Console.WriteLine("Task is done when all test cases are correct:");

            int testCaseNumber = 1;

            TestReturnedValues(testCaseNumber++, "", 0);
            TestReturnedValues(testCaseNumber++, " ", 0);
            TestReturnedValues(testCaseNumber++, "a", 1);
            TestReturnedValues(testCaseNumber++, "b", 0);
            TestReturnedValues(testCaseNumber++, "ab", 1);
            TestReturnedValues(testCaseNumber++, "ba", 1);
            TestReturnedValues(testCaseNumber++, "aba", 2);
            TestReturnedValues(testCaseNumber++, "bab", 1);
            TestReturnedValues(testCaseNumber++, "aeiou", 5);
            TestReturnedValues(testCaseNumber++, "bacedifoguh", 5);
            TestReturnedValues(testCaseNumber++, "Lorem ipsum dolor sit amet", 9);
            TestException<ArgumentNullException>(testCaseNumber++, null);
            Console.ReadKey();
        }
        private static void TestReturnedValues(int testCaseNumber, string s, int expectedResult)
        {
            try
            {
                if (CountVowels(s) == expectedResult)
                {
                    Console.WriteLine(correctCaseTemplate, testCaseNumber);
                }
                else
                {
                    Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
            }
        }

        private static void TestException<T>(int testCaseNumber, string s) where T : Exception
        {
            try
            {
                CountVowels(s);
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            catch (Exception)
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }

        private static string correctCaseTemplate = "Case #{0} is correct.";
        private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
        private static int correctTestCaseAmount = 0;
    }
}
